using ConsultarNotasRecoleccion.DataAccess;
using ConsultarNotasRecoleccion.Models;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System.Diagnostics;
using ConsultarNotasRecoleccion.Permisos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

namespace ConsultarNotasRecoleccion.Controllers
{
    [ValidarSession]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; 
        }

        public IActionResult Index(decimal codAlumna)
        {
            HomeDataAccess data = new();
            List<Calificaciones> listCalificacionesPorAlumna = new();
            listCalificacionesPorAlumna = data.ObtenerCalificacionPorAlumno(codAlumna);

            return View(listCalificacionesPorAlumna);
        }
        public IActionResult ViewsIBimensual(decimal codAlumna)
        {
            HomeDataAccess data = new();
            List<Calificaciones> listCalificacionesPorAlumna = new();
            listCalificacionesPorAlumna = data.ObtenerCalificacionPorAlumno(codAlumna);

            return View(listCalificacionesPorAlumna);
        }

        public IActionResult Privacy()
        {
            return View();
        }

		public IActionResult CerrarSesion()
		{
            //Session["usuario"] = null;
           
            return RedirectToAction("login","Acceso");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}