using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoWeb.Controllers
{
    public class BuscaTerapeutasController : Controller
    {
        public IActionResult Busca()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}