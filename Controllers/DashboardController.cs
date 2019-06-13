using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ponto_digital_final.Models;
using ponto_digital_final.Repositories;
using ponto_digital_SENAI.Repositories;

namespace ponto_digital_final.Controllers {
    public class DashboardController : Controller {

        private const string SESSION_EMAIL = "_EMAIL-USUARIO";
        private const string SESSION_SENHA = "_SENHA-USUARIO";
        private UsuarioRepository usuarioRepository = new UsuarioRepository ();
        private DepoimentoRepository depoimentoRepository = new DepoimentoRepository ();

        public IActionResult Index () {
            var usuario = usuarioRepository.ObterPor (HttpContext.Session.GetString (SESSION_EMAIL));
            ViewData["Usuario"] = usuario;
            ViewData["usuarios"] = usuarioRepository.Listar ();
            ViewData["depoimentos"] = depoimentoRepository.Listar ();
            RecuperarUserLogado ();
            return View ();
        }

        public IActionResult ListarUsuarios () {
            var usuarios = usuarioRepository.Listar ();
            var admins = new List<Usuario> ();
            ViewData["usuarios"] = usuarios;
            foreach (var item in usuarios) {
                if (item.EhAdmin) {
                    admins.Add (item);
                }
            }

            ViewData["admins"] = admins;
            System.Console.WriteLine ("USERS: " + (usuarios.Count - admins.Count));
            System.Console.WriteLine ("ADMS: " + admins.Count);

            if (usuarioRepository.Listar () == null) {
                System.Console.WriteLine ("lista usuarios vindo nula");
            }

            RecuperarUserLogado ();
            return View ();
        }

        public IActionResult Depoimentos () {
            var listaDepoimentos = depoimentoRepository.Listar ();
            ViewData["depoimentos"] = listaDepoimentos;
            RecuperarUserLogado ();
            return View ();
        }

        public IActionResult AlterarPermissao (string id) {
            var usuarioRetornado = usuarioRepository.ObterPor (ulong.Parse (id));
            usuarioRepository.AlterarPermissao (usuarioRetornado);
            return RedirectToAction ("ListarUsuarios", "Dashboard");
        }

        public IActionResult ApagarUsuario (string id) {
            var usuarioRetornado = usuarioRepository.ObterPor (ulong.Parse (id));
            usuarioRepository.RemoverUsuario (usuarioRetornado);
            return RedirectToAction ("ListarUsuarios", "Dashboard");
        }

        public IActionResult AprovarDepoimento (string id) {
            var depoimentoRetornado = depoimentoRepository.ObterPor (ulong.Parse (id));
            depoimentoRepository.AprovarDepoimento (depoimentoRetornado);
            return RedirectToAction ("Depoimentos", "Dashboard");
        }
        public IActionResult ReprovarDepoimento (string id) {
            var depoimentoRetornado = depoimentoRepository.ObterPor (ulong.Parse (id));
            depoimentoRepository.ReprovarDepoimento (depoimentoRetornado);
            return RedirectToAction ("Depoimentos", "Dashboard");
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