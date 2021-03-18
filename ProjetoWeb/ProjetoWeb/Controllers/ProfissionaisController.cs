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
    public class ProfissionaisController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IProfissionaisRepository profissionaisRepository;

        public ProfissionaisController(AplicationDbContext context , IProfissionaisRepository profissionaisRepository)
        {
            _context = context;
            this.profissionaisRepository = profissionaisRepository;
        }

        // GET: Profissionais
        public async Task<IActionResult> Inicio()
        {
            return View(profissionaisRepository.GetProfissionais());
        }

        // GET: Profissionais/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionais = await _context.profissionais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionais == null)
            {
                return NotFound();
            }

            return View(profissionais);
        }

        // GET: Profissionais/Create
        public IActionResult Cadastro()
        {
            return View();
        }

        // POST: Profissionais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro([Bind("Nome,Endereco,Telefone,WhatsApp,Nascimento,Id")] Profissionais profissionais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissionais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }
            return View(profissionais);
        }

        // GET: Profissionais/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionais = await _context.profissionais.FindAsync(id);
            if (profissionais == null)
            {
                return NotFound();
            }
            return View(profissionais);
        }

        // POST: Profissionais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Nome,Endereco,Telefone,WhatsApp,Nascimento,Id")] Profissionais profissionais)
        {
            if (id != profissionais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissionais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissionaisExists(profissionais.Id))
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
            return View(profissionais);
        }

        // GET: Profissionais/Delete/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionais = await _context.profissionais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionais == null)
            {
                return NotFound();
            }

            return View(profissionais);
        }

        // POST: Profissionais/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            var profissionais = await _context.profissionais.FindAsync(id);
            _context.profissionais.Remove(profissionais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool ProfissionaisExists(int id)
        {
            return _context.profissionais.Any(e => e.Id == id);
        }
    }
}
