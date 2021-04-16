using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Profissionais.Data;
using Profissionais.Models;
using Profissionais.Models.ModelsDb;
using Profissionais.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Profissionais.Controllers
{
    public class InicioController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IProfissionaisRepository profissionaisRepository;
        private readonly IEspecialidadesRepository especialidadesRepository;
        private readonly IEnderecosRepository enderecosRepository;
        private readonly IBuscaRepository buscaRepository;
        private readonly IGaleriaRepository galeriaRepository;

        public InicioController(AplicationDbContext context, IProfissionaisRepository profissionaisRepository, IEspecialidadesRepository especialidadesRepository,
            IEnderecosRepository enderecosRepository, IBuscaRepository buscaRepository, IGaleriaRepository galeriaRepository)
        {
            _context = context;
            this.profissionaisRepository = profissionaisRepository;
            this.especialidadesRepository = especialidadesRepository;
            this.enderecosRepository = enderecosRepository;
            this.buscaRepository = buscaRepository;
            this.galeriaRepository = galeriaRepository;
        }
        //Metodos
        [HttpGet]
        public IActionResult RecarregarCidadesEsp(string Especialidade, string UF)
        {
            var Cidades = buscaRepository.GetCidades(Especialidade, UF);
            return Json(Cidades);
        }
        [HttpGet]
        public IActionResult RecarregarUFs(string Especialidade)
        {
            var UFS = buscaRepository.GetUFs(Especialidade);
            return Json(UFS);
        }
        [HttpGet]
        public IActionResult RecarregarCidade(string Especialidade)
        {
            var Cidades = buscaRepository.GetCidadesEspecialidade(Especialidade);
            return Json(Cidades);
        }
        [HttpGet]
        public IActionResult RecarregarCidades(string Estado)
        {
            var cidades = buscaRepository.GetCidadesUFs(Estado);
            return Json(cidades);
        }
        [HttpGet]
        public IActionResult RecarregarEspecialidades(string Cidade, string UF)
        {
            IQueryable<Especialidades> especialidadeslista;
            if (UF != null)
            {
                especialidadeslista = especialidadesRepository.GetEspecialidades(UF);
            }
            else
            {
                especialidadeslista = especialidadesRepository.GetEspecialidades(Cidade);
            }
            return Json(especialidadeslista);
        }
        [HttpGet]
        public IActionResult RecarregarProfissionais(string Cidade, string UF, string IDEspecialidade)
        {
            var profissionais = profissionaisRepository.GetProfissionais(UF, Cidade, IDEspecialidade);
            return Json(profissionais);
        }
        [HttpPost, ActionName("Inicio")]
        public async Task<IActionResult> BuscarProfissionais([Bind("Cidade,UF")] Endereco endereco, int Especialidade)
        {
            Especialidades especialidades = await especialidadesRepository.GetEspecialidades(Especialidade);
            var profissionaisLista = await profissionaisRepository.GetProfissionais();
            //Sistema de Busca 
            List<ProfissionaisT> profissionais;

            if (string.IsNullOrEmpty(endereco.Cidade)
                || string.IsNullOrEmpty(endereco.UF)
                && especialidades.Id == 0)
            {
                profissionais = (await _context.Profissionais.ToListAsync());
            }
            else if (string.IsNullOrEmpty(endereco.Cidade)
                || string.IsNullOrEmpty(endereco.UF))
            {
                profissionais = await profissionaisRepository
                    .GetProfissionais(especialidades);
            }
            else if (especialidades.Id == 0)
            {
                profissionais = await profissionaisRepository
                    .GetProfissionais(endereco);
            }
            else
            {
                profissionais = profissionaisRepository
                    .GetProfissionais(especialidades, endereco);
            }
            //Select da pagina
            var enderecosLista = await enderecosRepository.GetEnderecos();
            List<string> Cidade = new List<string>();
            List<string> UF = new List<string>();
            foreach (var item in enderecosLista)
            {
                if (!Cidade.Contains(item.Cidade))
                {
                    Cidade.Add(item.Cidade);
                }
                if (!UF.Contains(item.UF))
                {
                    UF.Add(item.UF);
                }
            }
            //Listas
            var especialidadesLista = especialidadesRepository.GetEspecialidades();

            //Enviando Listas para a View 
            ViewBag.Cidades = Cidade.Select(c => new SelectListItem(
                text: c,
                value: c
                ));
            ViewBag.UFs = UF.Select(uf => new SelectListItem(
                text: uf,
                value: uf
                ));
            ViewBag.Especialidades = especialidadesLista.Select(e => new SelectListItem(
                 text: e.NomeDaEspecialidade,
                 value: e.Id.ToString()
                 ));
            return View(profissionais);

            //Select da pagina
        }
        //Metodos
        // GET: Inicio
        public async Task<IActionResult> Inicio()
        {
            var enderecosLista = await enderecosRepository.GetEnderecos();
            List<string> Rua = new List<string>();
            List<string> Bairro = new List<string>();
            List<string> Cidade = new List<string>();
            List<string> UF = new List<string>();
            foreach (var item in enderecosLista)
            {
                if (!Rua.Contains(item.Rua))
                {
                    Rua.Add(item.Rua);
                }
                if (!Bairro.Contains(item.Bairro))
                {
                    Bairro.Add(item.Bairro);
                }
                if (!Cidade.Contains(item.Cidade))
                {
                    Cidade.Add(item.Cidade);
                }
                if (!UF.Contains(item.UF))
                {
                    UF.Add(item.UF);
                }

            }
            //Listas
            var especialidadesLista = especialidadesRepository.GetEspecialidades();
            //Enviando Listas para a View 
            ViewBag.Ruas = Rua.Select(r => new SelectListItem(
                text: r,
                value: r
                ));
            ViewBag.Bairros = Bairro.Select(b => new SelectListItem(
                text: b,
                value: b
                ));
            ViewBag.Cidades = Cidade.Select(c => new SelectListItem(
                text: c,
                value: c
                ));
            ViewBag.UFs = UF.Select(uf => new SelectListItem(
                text: uf,
                value: uf
                ));
            ViewBag.Especialidades = especialidadesLista.Select(e => new SelectListItem(
                 text: e.NomeDaEspecialidade,
                 value: e.Id.ToString()
                 ));
            return View(await profissionaisRepository.GetProfissionais());
        }
        // GET: Inicio/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissional = await _context.Profissionais
                .FirstOrDefaultAsync(m => m.Id == id);
            var especialidadeprofissionais = especialidadesRepository.GetEspecialidades(profissional);
            ViewBag.Especialidades = especialidadeprofissionais.ToList();

            if (profissional == null)
            {
                return NotFound();
            }
            return View(profissional);
        }
        public IActionResult Galeria()
        {

            return View();
        }
        private bool ProfissionaisTExists(int id)
        {
            return _context.Profissionais.Any(e => e.Id == id);
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
