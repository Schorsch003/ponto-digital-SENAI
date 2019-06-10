using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ponto_digital_final.Repositories;

namespace ponto_digital_final.Controllers {
    public class DashboardController : Controller {

        private const string SESSION_EMAIL = "_EMAIL-USUARIO";
        private const string SESSION_SENHA = "_SENHA-USUARIO";
        private UsuarioRepository usuarioRepository = new UsuarioRepository ();

        public IActionResult Index () {
            var usuario = usuarioRepository.ObterPor (HttpContext.Session.GetString (SESSION_EMAIL));
            ViewData["Usuario"] = usuario;
            return View ();
        }

        public IActionResult ListarUsuarios () {
            var usuarios = usuarioRepository.Listar ();
            ViewData["usuarios"] = usuarios;
            var admins = usuarioRepository.ListarAdmins ();
            ViewData["admins"] = admins;
            if (usuarioRepository.Listar () == null) {
                System.Console.WriteLine ("lista usuarios vindo nula");
            }
            if (usuarioRepository.ListarAdmins () == null) {
                System.Console.WriteLine ("lista admins vindo nula");

            }
            return View ();
        }

        public IActionResult Depoimentos () {
            return View ();
        }

        public IActionResult ApagarUsuario(ulong id){
            var usuarioRetornado = usuarioRepository.ObterPor(id);
            usuarioRepository.RemoverUsuario(usuarioRetornado);
            return View("ListarUsuarios");
        }

        public IActionResult ApagarAdmin(ulong id){
            var usuarioRetornado = usuarioRepository.ObterPor(id);
            usuarioRepository.RemoverUsuario(usuarioRetornado);
            return View("ListarUsuarios");
        }
    }
}