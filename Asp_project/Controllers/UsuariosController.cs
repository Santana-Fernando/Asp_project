using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asp_project.Models;
using Asp_project.Controllers;
using Asp_project.ViewType;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_project.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public UsuariosController(Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            WebHostEnvironment = webHostEnvironment;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuario = await _context.Usuario.ToListAsync();

            usuario.ForEach(u =>
            {

                var loja = _context.Loja.FirstOrDefault(l => l.Uid_usuario == u.id_usuario);
                if (loja != null)
                {
                    u.Loja = loja;
                } else
                {
                    u.Loja = null;
                }
                
            });
            return View(usuario);
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.id_usuario == id);

            var endereco = await _context.Endereco
                .FirstOrDefaultAsync(m => m.Uid_usuario == id);

            usuario.Endereco = endereco;
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioType usuarioType)
        {
            UploadImages uploadImages = new UploadImages(WebHostEnvironment);
            string fileName = uploadImages.UploadFile(usuarioType.ProfileImage, "ImageProfile");

            if (ModelState.IsValid)
            {

                bool verified = usuarioType.senha == usuarioType.confirmarSenha;
                if (!verified) ModelState.AddModelError("confirmarSenha", "As senhas não batem");

                var usuario = new Usuario()
                {
                    nome = usuarioType.nome,
                    sobrenome = usuarioType.sobrenome,
                    cpf = usuarioType.cpf,
                    telefone = usuarioType.telefone,
                    celular = usuarioType.celular,
                    email = usuarioType.email,
                    senha = BCrypt.Net.BCrypt.HashPassword(usuarioType.senha),
                    foto = fileName,
                    Endereco = usuarioType.Endereco
                };


                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioType);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Usuario usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .FirstOrDefaultAsync(m => m.Uid_usuario == id);

            if (usuario.foto == null) usuario.foto = "";
            var usuarioType = new UsuarioType()
            {
                id_usuario = usuario.id_usuario,
                nome = usuario.nome,
                sobrenome = usuario.sobrenome,
                cpf = usuario.cpf,
                telefone = usuario.telefone,
                email = usuario.email,
                senha = usuario.senha,
                confirmarSenha = usuario.senha,
                celular = usuario.celular,
                foto = usuario.foto,
                Endereco = usuario.Endereco
            };

            return View(usuarioType);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,UsuarioType usuarioType)
        {
            var usuarioEdit = await _context.Usuario.FindAsync(id);
            var enderecoEdit = await _context.Endereco.FirstAsync(x => x.Uid_usuario == id);
            UploadImages uploadImages = new UploadImages(WebHostEnvironment);

            if (usuarioEdit == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (usuarioType.ProfileImage != null)
                    {
                        if (usuarioType.foto != null && usuarioType.foto != "")
                        {
                            uploadImages.DeleteFile("ImageProfile", usuarioType.foto);                            
                        }


                        string fileName = uploadImages.UpdateFile(usuarioType.ProfileImage, "ImageProfile");
                        usuarioType.foto = fileName;
                    }


                    usuarioEdit.nome = usuarioType.nome;
                    usuarioEdit.sobrenome = usuarioType.sobrenome;
                    usuarioEdit.cpf = usuarioType.cpf;
                    usuarioEdit.email = usuarioType.email;
                    usuarioEdit.senha = usuarioType.senha;
                    usuarioEdit.telefone = usuarioType.telefone;
                    usuarioEdit.celular = usuarioType.celular;
                    usuarioEdit.foto = usuarioType.foto;


                    enderecoEdit = usuarioType.Endereco;
                    enderecoEdit.U = usuarioEdit;

                    _context.Update(enderecoEdit);

                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuarioEdit.id_usuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSenha(int id, UsuarioType usuarioType)
        {
            var usuarioEdit = await _context.Usuario.FindAsync(id);

            if (usuarioEdit == null)
            {
                return NotFound();
            }

            bool verified = usuarioType.senha == usuarioType.confirmarSenha;
            if (!verified) ModelState.AddModelError("confirmarSenha", "As senhas não batem");

            if (ModelState.IsValid)
            {
                try
                {
                    
                    usuarioEdit.senha = usuarioType.senha;

                    _context.Update(usuarioEdit);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuarioEdit.id_usuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioType);
        }

        public async Task<IActionResult> ConfirmarSenha(int id)
        {
            var usuarioEdit = await _context.Usuario.FindAsync(id);

            if (usuarioEdit == null)
            {
                return NotFound();
            }

            return View(usuarioEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarSenha(int id, UsuarioType usuarioType)
        {
            var usuarioEdit = await _context.Usuario.FindAsync(id);

            if (usuarioEdit == null)
            {
                return NotFound();
            }

            bool verified = BCrypt.Net.BCrypt.Verify(usuarioType.senha, usuarioEdit.senha);

            if (!verified) ModelState.AddModelError("confirmarSenha", "As senhas não batem");
            else return RedirectToAction("EditSenha", "Usuarios", new { id = id, usuarioType = usuarioType });

            return View(usuarioType);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.id_usuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            UploadImages uploadImages = new UploadImages(WebHostEnvironment);

            if (usuario.foto != null && usuario.foto != "")
            {
                uploadImages.DeleteFile("ImageProfile", usuario.foto);
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.id_usuario == id);
        }
        public JsonResult GetCidade(int id)
        {
            return this.Json(_context.Endereco.Where(x => x.Uid_usuario == id));
        }
    }
}
