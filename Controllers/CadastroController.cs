using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ponto_digital_final.Models;
using ponto_digital_final.Repositories;

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

            System.Console.WriteLine (form["nome"]);

            usuarioRepository.InserirUsuario (usuario);
            return RedirectToAction ("Index", "Home");
        }

        public IActionResult Login () {
            return View ();
        }

        [HttpPost]
        public IActionResult RealizarLogin (IFormCollection form) {
            var listaAdmins = usuarioRepository.ListarAdmins ();
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
                if (listaAdmins.Contains (usuarioRetornado)) {
                    return RedirectToAction ("Index", "Dashboard");
                }
                return View ("Sucesso");
            }
            return RedirectToAction ("Index", "Home");
        }

        public IActionResult Deslogar () {
            HttpContext.Session.Clear ();
            return RedirectToAction ("Index", "Home");
        }
    }
}