using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Profissionais.Data;
using Profissionais.Models.ModelsDb;
using Profissionais.Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Profissionais.Controllers
{
    [Authorize]
    public class ProfissionaisController : Controller
    {
        //Dependencias  --------------------------------
        private readonly AplicationDbContext _context;
        private readonly IProfissionaisRepository profissionaisRepository;
        private readonly IEspecialidadesRepository especialidadesRepository;
        private readonly IEnderecosRepository enderecosRepository;
        //Dependencias  --------------------------------

        //Controler     --------------------------------
        public ProfissionaisController(AplicationDbContext context, IProfissionaisRepository profissionaisRepository, IEspecialidadesRepository especialidadesRepository, IEnderecosRepository enderecosRepository)
        {
            _context = context;
            this.profissionaisRepository = profissionaisRepository;
            this.especialidadesRepository = especialidadesRepository;
            this.enderecosRepository = enderecosRepository;
        }
        //Controler     --------------------------------

        //Metodos   ------------------------------------
        [HttpGet]
        public IActionResult GetLogradouro(string CEP)
        {
            var logradouro = enderecosRepository.BuscarCEP(CEP);
            return Json(logradouro);
        }
        //Metodos   ------------------------------------

        // GET: Profissionais
        public async Task<IActionResult> Inicio()
        {
            return View(await profissionaisRepository.GetProfissionais());
        }

        // GET: Profissionais/Detalhes/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int Id = Convert.ToInt32(id);
            var profissionais = await profissionaisRepository.Get(Id);
            var especialidadeprofissionais = especialidadesRepository.GetEspecialidades(profissionais);
            ViewBag.Especialidades = especialidadeprofissionais.ToList();

            if (profissionais == null)
            {
                return NotFound();
            }
            return View(profissionais);
        }

        // GET: Profissionais/Create
        public IActionResult Cadastro()
        {
            var listItems = especialidadesRepository.GetEspecialidades();

            ViewBag.Especialidades = listItems.ToList();
            return View();
        }

        // POST: Profissionais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro([Bind("Nome,Nascimento,Telefone,WhatsApp,Rua,CEP,Complemento,Bairro,Cidade,UF,Id,Sobrenome,Titulo")] ProfissionaisT profissionais,
            List<int> Especialidades, IList<IFormFile> arquivos)
        {
            var listItems = especialidadesRepository.GetEspecialidades();

            ViewBag.Especialidades = listItems.ToList();
            if (ModelState.IsValid)
            {
                IFormFile imagemEnviada = arquivos.FirstOrDefault();
                if (imagemEnviada != null || imagemEnviada.ContentType.ToLower().StartsWith("image/"))
                {
                    MemoryStream ms = new MemoryStream();
                    imagemEnviada.OpenReadStream().CopyTo(ms);
                    profissionais.imagem = ms.ToArray();
                    profissionais.ContentType = imagemEnviada.ContentType;
                }
                _context.Add(profissionais);
                await _context.SaveChangesAsync();
                //Relacionando
                foreach (var especialidade in Especialidades)
                {
                    //Buscando Especialidade Atravez Do ID
                    var Especialidade = await especialidadesRepository.GetEspecialidades(especialidade);
                    //Criando Nova Especilaidade
                    Especialidades EspecialidadesCad = new Especialidades() { Codigo = Especialidade.Codigo, NomeDaEspecialidade = Especialidade.NomeDaEspecialidade, Profissionais = profissionais };
                    //Preenchendo Banco
                    _context.Add(EspecialidadesCad);
                    await _context.SaveChangesAsync();

                }
                //Redirecionando
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
            var profissionais = await profissionaisRepository.Get(id);
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
        public async Task<IActionResult> Editar(int id, [Bind("Titulo,Sobrenome,Nome,Nascimento,Telefone,WhatsApp,Rua,CEP,Complemento,Bairro,Cidade,UF,Id")] ProfissionaisT profissionais)
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
                    if (!ProfissionaisTExists(profissionais.Id))
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

            var profissionaisT = await _context.Profissionais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionaisT == null)
            {
                return NotFound();
            }
            return View(profissionaisT);

        }

        // POST: Profissionais/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            var profissionaisT = await _context.Profissionais.FindAsync(id);
            _context.Profissionais.Remove(profissionaisT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool ProfissionaisTExists(int id)
        {
            return _context.Profissionais.Any(e => e.Id == id);
        }
    }
}
