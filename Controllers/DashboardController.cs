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
    }
}