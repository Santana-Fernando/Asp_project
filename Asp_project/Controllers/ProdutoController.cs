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
    public class ProdutoController : Controller
    {
        private readonly Context _context;

        public ProdutoController(Context context)
        {
            _context = context;
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            var context = _context.Produto.Include(p => p.C).Include(p => p.L);
            return View(await context.ToListAsync());
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.C)
                .Include(p => p.L)
                .FirstOrDefaultAsync(m => m.id_produto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        public IActionResult Create(int id)
        {
            ProdutoType produtoType = new ProdutoType();
            produtoType.Lid_loja = id;
            ViewData["Cid_categoria"] = new SelectList(_context.Categoria, "id_categoria", "descricao", produtoType.Cid_categoria);
            return View(produtoType);
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_produto,Lid_loja,nome_produto,descricao_produto,valor,Cid_categoria")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid_categoria"] = new SelectList(_context.Categoria, "id_categoria", "descricao", produto.Cid_categoria);
            ViewData["Lid_loja"] = new SelectList(_context.Loja, "id_loja", "cpf_cnpj", produto.Lid_loja);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["Cid_categoria"] = new SelectList(_context.Categoria, "id_categoria", "descricao", produto.Cid_categoria);
            ViewData["Lid_loja"] = new SelectList(_context.Loja, "id_loja", "cpf_cnpj", produto.Lid_loja);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_produto,Lid_loja,nome_produto,descricao_produto,valor,Cid_categoria")] Produto produto)
        {
            if (id != produto.id_produto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.id_produto))
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
            ViewData["Cid_categoria"] = new SelectList(_context.Categoria, "id_categoria", "descricao", produto.Cid_categoria);
            ViewData["Lid_loja"] = new SelectList(_context.Loja, "id_loja", "cpf_cnpj", produto.Lid_loja);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.C)
                .Include(p => p.L)
                .FirstOrDefaultAsync(m => m.id_produto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.id_produto == id);
        }
    }
}
