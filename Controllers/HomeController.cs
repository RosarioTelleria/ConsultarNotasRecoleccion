using ConsultarNotasRecoleccion.DataAccess;
using ConsultarNotasRecoleccion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsultarNotasRecoleccion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; /*esto es una prueba*/
        }

        public IActionResult Index(string codAlumna)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}