using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            if (usuario == null) {
                usuario = usuarioRepository.ObterAdmPor (HttpContext.Session.GetString (SESSION_EMAIL));
            }
            ViewData["Usuario"] = usuario;
            RecuperarUserLogado ();
            return View ();
        }

        public IActionResult ListarUsuarios () {
            var usuarios = usuarioRepository.Listar ();
            ViewData["usuarios"] = usuarios;
            System.Console.WriteLine ("USERS: " + usuarios.Count);
            var admins = usuarioRepository.ListarAdmins ();
            ViewData["admins"] = admins;
            System.Console.WriteLine ("ADMS: " + admins.Count);

            if (usuarioRepository.Listar () == null) {
                System.Console.WriteLine ("lista usuarios vindo nula");
            }
            if (usuarioRepository.ListarAdmins () == null) {
                System.Console.WriteLine ("lista admins vindo nula");

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

        public IActionResult ApagarAdmin (string email) {
            var usuarioRetornado = usuarioRepository.ObterAdmPor (ulong.Parse (email));
            usuarioRepository.RemoverUsuario (usuarioRetornado);
            return RedirectToAction ("ListarUsuarios", "Dashboard");
        }
        public IActionResult RetirarAdmin (string email) {
            var usuarioRetornado = usuarioRepository.ObterAdmPor (ulong.Parse (email));
            usuarioRepository.AlterarPermissao (usuarioRetornado);
            return RedirectToAction ("ListarUsuarios", "Dashboard");
        }

        public IActionResult ApagarUsuario (string email) {
            var usuarioRetornado = usuarioRepository.ObterPor (ulong.Parse (email));
            usuarioRepository.RemoverUsuario (usuarioRetornado);
            return RedirectToAction ("ListarUsuarios", "Dashboard");
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