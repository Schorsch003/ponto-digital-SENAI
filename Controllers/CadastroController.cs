using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ponto_digital_final.Models;
using ponto_digital_final.Repositories;
using ponto_digital_SENAI.Repositories;

namespace ponto_digital_final.Controllers {
    public class CadastroController : Controller {

        private const string SESSION_EMAIL = "_EMAIL-USUARIO";
        private const string SESSION_SENHA = "_SENHA-USUARIO";
        UsuarioRepository usuarioRepository = new UsuarioRepository ();
        public IActionResult Index () {
            return View ();
        }

        public IActionResult Cadastrar (IFormCollection form) {
            Usuario usuario = new Usuario ();
            usuario.Nome = form["nome"];
            usuario.Email = form["email"];
            usuario.Senha = form["senha"];
            usuario.DataNascimento = DateTime.Parse (form["dataNascimento"]);
            usuario.EhAdmin = false;

            System.Console.WriteLine (form["nome"]);
            System.Console.WriteLine(usuario.EhAdmin);

            usuarioRepository.InserirUsuario (usuario);
            return RedirectToAction ("Index", "Home");
        }

        public IActionResult Login () {
            return View ();
        }

        [HttpPost]
        public IActionResult RealizarLogin (IFormCollection form) {
            var lista = usuarioRepository.Listar ();
            var email = form["email"];
            var senha = form["senha"];

            var usuarioRetornado = usuarioRepository.ObterPor (email);

            if (usuarioRetornado == null) {
                System.Console.WriteLine ("o usuario ta vindo null");
                usuarioRetornado = usuarioRepository.ObterPor (email);
            }
            if (usuarioRetornado != null && senha == usuarioRetornado.Senha) {
                HttpContext.Session.SetString (SESSION_EMAIL, usuarioRetornado.Email);
                HttpContext.Session.SetString (SESSION_SENHA, usuarioRetornado.Senha);
                System.Console.WriteLine ($"usuario {usuarioRetornado.Nome} logado");
                ViewData["Processo"] = "Login";
                if (usuarioRetornado.EhAdmin) {
                    return RedirectToAction ("Index", "Dashboard");
                }
                RecuperarUserLogado ();
                return View ("Sucesso");
            } else if (usuarioRetornado != null && senha != usuarioRetornado.Senha) {
                ViewData["Processo"] = "Login";
                return View ("Falha");
            }
            return RedirectToAction ("Index", "Home");
        }

        public IActionResult Deslogar () {
            HttpContext.Session.Clear ();
            return RedirectToAction ("Index", "Home");
        }

        void RecuperarUserLogado () {
            var email = HttpContext.Session.GetString (SESSION_EMAIL) == null ? "" : HttpContext.Session.GetString (SESSION_EMAIL);
            var usuario = usuarioRepository.ObterPor (email);
            // System.Console.WriteLine (HttpContext.Session.GetString (SESSION_EMAIL));
            ViewData["Usuario"] = usuario;
            PacotesRepository pacotesRepository = new PacotesRepository ();
            ViewData["pacotes"] = pacotesRepository.Listar ();
        }
    }

}