using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Profissionais.Data;
using Profissionais.Models.ModelsDb;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissionais.Controllers
{
    [Authorize]
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
            return View(await _context.Especialidades.ToListAsync());
        }
        // GET: Especialidades/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var especialidades = await _context.Especialidades
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
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidades = await _context.Especialidades.FindAsync(id);
            if (especialidades == null)
            {
                return NotFound();
            }
            return View(especialidades);
        }
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
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidades = await _context.Especialidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidades == null)
            {
                return NotFound();
            }
            return View(especialidades);

        }
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            var especialidades = await _context.Especialidades.FindAsync(id);
            _context.Especialidades.Remove(especialidades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }
        private bool EspecialidadesExists(int id)
        {
            return _context.Especialidades.Any(e => e.Id == id);
        }
    }
}
