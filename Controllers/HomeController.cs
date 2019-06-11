using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ponto_digital_final.Models;
using ponto_digital_final.Repositories;
using ponto_digital_SENAI.Models;
using ponto_digital_SENAI.Repositories;

namespace ponto_digital_final.Controllers {
    public class HomeController : Controller {

        private const string SESSION_EMAIL = "_EMAIL-USUARIO";
        private const string SESSION_SENHA = "_SENHA-USUARIO";
        private UsuarioRepository usuarioRepository = new UsuarioRepository ();

        public IActionResult Index () {
            RecuperarUserLogado();
            return View ();
        }

        public IActionResult Pacotes () {
            RecuperarUserLogado();
            return View ();
        }

        public IActionResult QuemSomos () {
            RecuperarUserLogado();
            return View ();
        }

        public IActionResult ComoUsar () {
            RecuperarUserLogado();
            return View ();
        }

        public IActionResult Faq () {
            RecuperarUserLogado();
            return View ();
        }

        public IActionResult Avaliacoes () {
            RecuperarUserLogado();
            return View ();
        }

        [HttpPost]
        public IActionResult RetornarAvaliacao (IFormCollection form) {
            var depoimentoRepository = new DepoimentoRepository();
            var depoimento = new Depoimento();

            depoimento.NomeUsuario = form["nome"];
            depoimento.Nota = uint.Parse(form["rating"]);
            depoimento.Conteudo = form["comentario"];
            depoimentoRepository.Inserir(depoimento);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Sac () {
            RecuperarUserLogado();
            return View ();
        }


        void RecuperarUserLogado(){
            var email = HttpContext.Session.GetString (SESSION_EMAIL) == null ? "" : HttpContext.Session.GetString (SESSION_EMAIL);
            var usuario = usuarioRepository.ObterPor (email);
            // System.Console.WriteLine (HttpContext.Session.GetString (SESSION_EMAIL));
            ViewData["Usuario"] = usuario;
            PacotesRepository pacotesRepository = new PacotesRepository ();
            ViewData["pacotes"] = pacotesRepository.Listar ();
        }
    }
}