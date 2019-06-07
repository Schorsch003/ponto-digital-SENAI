using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ponto_digital_final.Models;
using ponto_digital_final.Repositories;
using ponto_digital_SENAI.Repositories;

namespace ponto_digital_final.Controllers {
    public class HomeController : Controller {

        private const string SESSION_EMAIL = "_EMAIL-USUARIO";
        private const string SESSION_SENHA = "_SENHA-USUARIO";
        private UsuarioRepository usuarioRepository = new UsuarioRepository ();

        public IActionResult Index () {

            var email = HttpContext.Session.GetString (SESSION_EMAIL) == null ? "" : HttpContext.Session.GetString (SESSION_EMAIL);
            var usuario = usuarioRepository.ObterPor (email);
            // System.Console.WriteLine (HttpContext.Session.GetString (SESSION_EMAIL));
            ViewData["Usuario"] = usuario;
            return View ();
        }

        public IActionResult Pacotes () {
            PacotesRepository pacotesRepository = new PacotesRepository ();
            ViewData["pacotes"] = pacotesRepository.Listar ();
            return View ();
        }

        public IActionResult QuemSomos () {
            return View ();
        }

        public IActionResult ComoUsar () {
            return View ();
        }

        public IActionResult Faq () {
            return View ();
        }

        public IActionResult Avaliacoes () {
            UsuarioRepository usuarioRepository = new UsuarioRepository ();
            var usuario = usuarioRepository.ObterPor (HttpContext.Session.GetString (SESSION_EMAIL) == null ? "" : HttpContext.Session.GetString (SESSION_EMAIL));
            ViewData["Usuario"] = usuario;
            return View ();
        }
        public IActionResult Sac () {
            return View ();
        }
    }
}