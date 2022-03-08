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

namespace Asp_project.Models
{
    public class LojasController : Controller
    {
        private readonly Context _context;

        private readonly IWebHostEnvironment WebHostEnvironment;

        public LojasController(Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            WebHostEnvironment = webHostEnvironment;
        }

        // GET: Lojas
        public async Task<IActionResult> Index()
        {
            return View(_context.Loja.ToListAsync());
        }

        // GET: Lojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Loja
                .Include(l => l.U)
                .FirstOrDefaultAsync(m => m.id_loja == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // GET: Lojas/Create
        public IActionResult Create(int id)
        {
            LojaType lojaType = new LojaType();
            lojaType.Uid_usuario = id;
            return View(lojaType);
        }

        // POST: Lojas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LojaType lojaType)
        {
            UploadImages uploadImages = new UploadImages(WebHostEnvironment);
            string fileName = uploadImages.UploadFile(lojaType.ShopImage, "ImageShop");

            int idUsuario = lojaType.Uid_usuario;

            var loja = new Loja()
            {
                nome_loja = lojaType.nome_loja,
                descicao = lojaType.descicao,
                cpf_cnpj = lojaType.cpf_cnpj,
                telefone = lojaType.telefone,
                celular = lojaType.celular,
                dias_e_horas_de_funcionamento = lojaType.dias_e_horas_de_funcionamento,
                fotoLoja = lojaType.fotoLoja,
                Uid_usuario = idUsuario,
                Endereco = lojaType.Endereco
            };

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.id_usuario == idUsuario);

            usuario.Loja = loja;

            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                _context.Add(loja);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Usuarios");
            }
            return View(lojaType);
        }

        // GET: Lojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Loja loja = await _context.Loja.FindAsync(id);

            if (loja == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .FirstOrDefaultAsync(m => m.Lid_loja == id);

            if (loja.fotoLoja == null) loja.fotoLoja = "";

            var lojaType = new LojaType()
            {
                id_loja = loja.id_loja,
                nome_loja = loja.nome_loja,
                descicao = loja.descicao,
                cpf_cnpj = loja.cpf_cnpj,
                telefone = loja.telefone,
                celular = loja.celular,
                dias_e_horas_de_funcionamento = loja.dias_e_horas_de_funcionamento,
                fotoLoja = loja.fotoLoja,
                Uid_usuario = loja.Uid_usuario,
                Endereco = loja.Endereco
            };

            return View(lojaType);
        }

        // POST: Lojas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LojaType lojaType)
        {
            var lojaEdit = await _context.Loja.FindAsync(id);
            var enderecoEdit = await _context.Endereco.FirstAsync(x => x.Lid_loja == id);
            UploadImages uploadImages = new UploadImages(WebHostEnvironment);

            if (lojaEdit == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (lojaType.ShopImage != null)
                    {
                        if (lojaType.fotoLoja != null && lojaType.fotoLoja != "")
                        {
                            uploadImages.DeleteFile("ImageShop", lojaType.fotoLoja);
                        }


                        string fileName = uploadImages.UpdateFile(lojaType.ShopImage, "ImageShop");
                        lojaType.fotoLoja = fileName;
                    }


                    lojaEdit.nome_loja = lojaType.nome_loja;
                    lojaEdit.descicao = lojaType.descicao;
                    lojaEdit.cpf_cnpj = lojaType.cpf_cnpj;
                    lojaEdit.telefone = lojaType.telefone;
                    lojaEdit.celular = lojaType.celular;
                    lojaEdit.dias_e_horas_de_funcionamento = lojaType.dias_e_horas_de_funcionamento;
                    lojaEdit.fotoLoja = lojaType.fotoLoja;
                    lojaEdit.Uid_usuario = lojaType.Uid_usuario;
          
                    enderecoEdit = lojaType.Endereco;
                    enderecoEdit.L = lojaEdit;

                    _context.Update(enderecoEdit);

                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LojaExists(lojaEdit.Uid_usuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Usuarios");
            }
            return View(lojaType);
        }

        // GET: Lojas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Loja
                .Include(l => l.U)
                .FirstOrDefaultAsync(m => m.id_loja == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // POST: Lojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loja = await _context.Loja.FindAsync(id);
            var endereco = await _context.Endereco.FirstOrDefaultAsync(e => e.Lid_loja == id);
            UploadImages uploadImages = new UploadImages(WebHostEnvironment);

            loja.Endereco = endereco;

            if (loja.fotoLoja != null && loja.fotoLoja != "")
            {
                uploadImages.DeleteFile("ImageProfile", loja.fotoLoja);
            }

            _context.Loja.Remove(loja);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Usuarios");
        }

        private bool LojaExists(int id)
        {
            return _context.Loja.Any(e => e.id_loja == id);
        }

        public JsonResult GetCidade(int id)
        {
            return this.Json(_context.Endereco.Where(x => x.Lid_loja == id));
        }
    }
}
