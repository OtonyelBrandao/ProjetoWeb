using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Data;
using ProjetoWeb.Models;
using ProjetoWeb.Repository;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ProjetoWeb.Controllers
{
    public class ProfissionaisController : Controller
    {
        //Dependencias  --------------------------------
        private readonly AplicationDbContext _context;
        private readonly IProfissionaisRepository profissionaisRepository;
        private readonly IEspecialidadesRepository especialidadesRepository;
        //Dependencias  --------------------------------

        //Construtor    --------------------------------
        public ProfissionaisController(AplicationDbContext context, IProfissionaisRepository profissionaisRepository, IEspecialidadesRepository especialidadesRepository)
        {
            _context = context;
            this.profissionaisRepository = profissionaisRepository;
            this.especialidadesRepository = especialidadesRepository;
        }
        //Construtor    --------------------------------

        //Metodos   ------------------------------------
        private Logradouro GetLogradouro(int CEP)
        {
            //Verificando se o CEP é Valido
            string VerificaCep = Convert.ToString(CEP);

            if(VerificaCep.Length < 8 || VerificaCep.Length > 8)
            {
                return null;
            }
            //Fim da Verificação

            //Instanciando um http client para receber a resposta da requisição
            var cliente = new HttpClient();

            //Formatando o Caminho da Requisição para Receber o CEP indicado no inicio do metodo
            string url = string.Format("/ws/{0}/json/",CEP);

            //Fasendo uma Requisição utilizando a string já formatada
            cliente.BaseAddress = new  Uri("https://viacep.com.br");
            cliente.DefaultRequestHeaders.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

            var response = cliente.GetAsync(url).Result;
            var logradouro = response.Content.ReadAsAsync<Logradouro>().Result;
            return logradouro;
        }
        //Metodos   ------------------------------------

        //CRUD  ----------------------------------------

        // GET: Profissionais
        public async Task<IActionResult> Inicio()
        {
            return View(await profissionaisRepository.GetProfissionais());
        }

        // GET: Profissionais/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            int Id = Convert.ToInt32(id);
            var profissionais = await profissionaisRepository.Get(Id);
            
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
        public async Task<IActionResult> Cadastro([Bind("Id,Nome,CEP,Complemento,Telefone,WhatsApp,Nascimento,EspecialidadeID")] Profissionais profissionais)
        {
            var listItems = especialidadesRepository.GetEspecialidades();
            
            ViewBag.Especialidades = listItems.Select(c => new SelectListItem()
            {
                Text = c.NomeDaEspecialidade,
                Value = c.Id.ToString()

            }).ToList();

            //Teste de Modelstate
            if (ModelState.IsValid)
            {

                //Instanciando Um Logradouro Valido
                Logradouro logradouro;

                //Preenchendo Logradouro Com a Api viacep
                logradouro = GetLogradouro(profissionais.CEP);

                //passando dados recebidos para profissionais
                profissionais.Bairro = logradouro.bairro;
                profissionais.Cidade = logradouro.localidade;
                profissionais.UF = logradouro.uf;
                profissionais.Rua = logradouro.logradouro;

                //Cadastrando profissional na tabela do banco
                //utilizando EF core 
                profissionaisRepository.Add(profissionais);

                //Redirecionando View
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
                    await profissionaisRepository.Edit(profissionais);
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

            var profissionais = await profissionaisRepository.Get(id);
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
            profissionaisRepository.Delete(id);
            return RedirectToAction(nameof(Inicio));
        }

        private bool ProfissionaisExists(int id)
        {
            return _context.profissionais.Any(e => e.Id == id);
        }
        //CRUD  ----------------------------------------
    }
}
