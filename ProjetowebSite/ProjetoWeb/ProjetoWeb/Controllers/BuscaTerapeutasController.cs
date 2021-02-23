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

        public IActionResult Busca()
        {
            return View(TerapeutasReporitory.GetTerapeutas());
        }
    }
}