using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Data;
using ProjetoWeb.Models;
using ProjetoWeb.Repository;

namespace ProjetoWeb.Controllers
{
    public class LogradouroController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly ILogradouroRepository logradouroRepository;

        public LogradouroController(AplicationDbContext context, ILogradouroRepository logradouroRepository)
        {
            _context = context;
            this.logradouroRepository = logradouroRepository;
        }

        // GET: Logradouroes
        public async Task<IActionResult> Inicio()
        {
            return View(await _context.logradouro.ToListAsync());
        }

        // GET: Logradouroes/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logradouro = await _context.logradouro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logradouro == null)
            {
                return NotFound();
            }

            return View(logradouro);
        }

        // GET: Logradouroes/Create
        public IActionResult Cadastro()
        {
            return View();
        }

        // POST: Logradouroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro([Bind("Rua,CEP,Complemento,Bairro,Cidade,UF,Id")] Logradouro logradouro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logradouro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }
            return View(logradouro);
        }

        // GET: Logradouroes/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logradouro = await _context.logradouro.FindAsync(id);
            if (logradouro == null)
            {
                return NotFound();
            }
            return View(logradouro);
        }

        // POST: Logradouroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Rua,CEP,Complemento,Bairro,Cidade,UF,Id")] Logradouro logradouro)
        {
            if (id != logradouro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logradouro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogradouroExists(logradouro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Inicio));
            }
            return View(logradouro);
        }

        // GET: Logradouroes/Delete/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logradouro = await _context.logradouro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logradouro == null)
            {
                return NotFound();
            }

            return View(logradouro);
        }

        // POST: Logradouroes/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            var logradouro = await _context.logradouro.FindAsync(id);
            _context.logradouro.Remove(logradouro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool LogradouroExists(int id)
        {
            return _context.logradouro.Any(e => e.Id == id);
        }
    }
}
