using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.Models;
using ProjetoWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Controllers
{
    public class EspecialidadesController : Controller
    {
        private IEspecialidadesRepository EspecialidadesRepository;

        public EspecialidadesController(IEspecialidadesRepository especialidadesRepository)
        {
            EspecialidadesRepository = especialidadesRepository;
        }
        //Cadastro ----- ------
        [HttpPost]
        public IActionResult Cadastro(int Codigo ,string NomeDaEspecialidade)
        {
            var especialidade = new Especialidades();
            especialidade.Codigo = Codigo;
            especialidade.NomeDaEspecialidade = NomeDaEspecialidade;
            EspecialidadesRepository.Add(especialidade);

            return View();
        }
        [HttpGet]
        public IActionResult Cadastro()
        {

            return View();
        }
        //Cadastro ----- ------
        //Atualizar ----- ------
        [HttpPost]
        [ActionName("Atualizar")]
        public IActionResult Atualiza(int ID ,int Codigo , string NomeDaEspecialidade)
        {

            var Especialidade = new Especialidades();

            Especialidade.ID = ID;
            Especialidade.Codigo = Codigo;
            Especialidade.NomeDaEspecialidade = NomeDaEspecialidade;

            EspecialidadesRepository.UpdateEspecialidades(Especialidade);

            return View(Especialidade);
        }
        public IActionResult Atualizar(int ID)
        {
            var Especialidade = EspecialidadesRepository.GetEspecialidade(ID);
            //EspecialidadesRepository.UpdateEspecialidades(Especialidade);
            return View(Especialidade);
        }
        //Atualizar ----- ------

        //Deletar ------ ------
        [HttpPost]
        [ActionName("Deletar")]
        public IActionResult Delete(int ID)
        {
            EspecialidadesRepository.DeleteEspecialidades(ID);
            return RedirectToAction("Lista");
        }
        public IActionResult Deletar(int ID)
        {
            return View(EspecialidadesRepository.GetEspecialidade(ID));
        }
        //Deletar ------ ------

        //Lista ------  ------
        [HttpGet]
        public IActionResult Lista()
        {
            var ListaEspecialidades = EspecialidadesRepository.GetListEspecialidades();
            return View(ListaEspecialidades);
        }
        //Lista ------  ------
        public IActionResult Detalhes(int ID)
        {
            return View(EspecialidadesRepository.GetEspecialidade(ID));
        }
    }
}
