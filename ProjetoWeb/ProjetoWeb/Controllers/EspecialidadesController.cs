using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Data;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    public class EspecialidadesController : Controller
    {
        private readonly AplicationDbContext _context;

        public EspecialidadesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Especialidades
        public async Task<IActionResult> Inicio()
        {
            return View(await _context.especialidades.ToListAsync());
        }

        // GET: Especialidades/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidades = await _context.especialidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidades == null)
            {
                return NotFound();
            }

            return View(especialidades);
        }

        // GET: Especialidades/Create
        public IActionResult Cadastro()
        {
            return View();
        }

        // POST: Especialidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro([Bind("Codigo,NomeDaEspecialidade,Id")] Especialidades especialidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }
            return View(especialidades);
        }

        // GET: Especialidades/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidades = await _context.especialidades.FindAsync(id);
            if (especialidades == null)
            {
                return NotFound();
            }
            return View(especialidades);
        }

        // POST: Especialidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Codigo,NomeDaEspecialidade,Id")] Especialidades especialidades)
        {
            if (id != especialidades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadesExists(especialidades.Id))
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
            return View(especialidades);
        }

        // GET: Especialidades/Deletar/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidades = await _context.especialidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidades == null)
            {
                return NotFound();
            }

            return View(especialidades);
        }

        // POST: Especialidades/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            var especialidades = await _context.especialidades.FindAsync(id);
            _context.especialidades.Remove(especialidades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool EspecialidadesExists(int id)
        {
            return _context.especialidades.Any(e => e.Id == id);
        }
    }
}
