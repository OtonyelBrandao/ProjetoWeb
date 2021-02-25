using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.Repository;

namespace ProjetoWeb.Controllers
{
    public class BuscaTerapeutasController : Controller
    {
        private ITerapeutasReporitory TerapeutasReporitory;

        public BuscaTerapeutasController(ITerapeutasReporitory terapeutasReporitory)
        {
            TerapeutasReporitory = terapeutasReporitory;
        }

        public IActionResult Principal()
        {
            return View(TerapeutasReporitory.GetTerapeutas());
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}