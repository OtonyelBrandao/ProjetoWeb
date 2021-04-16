using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Profissionais.Models.ModelsDb;
using Profissionais.Repositorios;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Profissionais.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuariosRepository usuariosRepository;

        public UsuariosController(IUsuariosRepository usuariosRepository)
        {
            this.usuariosRepository = usuariosRepository;
        }
        [AllowAnonymous]
        private async void Login(Usuarios usuario, bool Lembrar)
        {
            List<Claim> claims;
            claims = new List<Claim> {
                new Claim(ClaimTypes.Name, usuario.Login),
                new Claim(ClaimTypes.Role, "Usuario_Comum")
            };

            var identidadeDeUsuario = new ClaimsIdentity(claims, "Login");

            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeDeUsuario);
            var propriedadesDeAutenticacao = new AuthenticationProperties();
            if (!Lembrar)
            {
                propriedadesDeAutenticacao = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddHours(2),
                    IsPersistent = true
                };
            }
            else if (Lembrar)
            {
                propriedadesDeAutenticacao = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddHours(620),
                    IsPersistent = true
                };
            }


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, propriedadesDeAutenticacao);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Inicio", "Inicio", "");
        }
        [AllowAnonymous]
        public IActionResult LoginPage()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("PaginaDeUsuario");
            }

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult LoginPage([Bind("IDUsuario,Login,Senha")] Usuarios usuario, bool Lembrar)
        {
            try
            {
                if (usuario.Login != null & usuario.Senha != null)
                {
                    if (usuariosRepository.GetUsuario(usuario.Login, usuario.Senha) != null)
                    {
                        Login(usuario, Lembrar);
                        return RedirectToAction("PaginaDeUsuario");
                    }
                    else
                    {
                        ViewBag.Erro = "Usuário e/ou senha incorretos!!";
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Erro = "Ocorreu algum erro ao tentar se logar, tente novamente!";
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar([Bind("IDUsuario,Login,Senha,TipoDeUsuario,Nome,Sobrenome")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                usuariosRepository.AddUsuario(usuarios);
                return RedirectToAction("LoginPage");
            }
            return View(usuarios);
        }
        [Authorize]
        public IActionResult PaginaDeUsuario()
        {
            return View();
        }


    }
}
