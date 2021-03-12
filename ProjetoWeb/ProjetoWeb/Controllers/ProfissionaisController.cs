using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.Models;
using ProjetoWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Controllers
{
    public class ProfissionaisController : Controller
    {
        private IProfissionaisRepository ProfissionaisRepository;

        public ProfissionaisController(IProfissionaisRepository profissionaisRepository)
        {
            ProfissionaisRepository = profissionaisRepository;
        }
        [HttpPost]
        public IActionResult Cadastro(string Nome , DateTime Nascimento, string Telefone,string WhatsApp,int IDEspecialidade)
        {
            var profissional = new Profissionais();
            ProfissionaisRepository.Add(profissional);
            return View();
        }
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Atualizar()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Atualizar(int ID)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Deletar(int ID)
        {
            return View();
        }
        public IActionResult Deletar(int ID)
        {
            return View();
        }
        public IActionResult Lista()
        {
            return View(ProfissionaisRepository.GetListProfissionais());
        }
        
    }
}
