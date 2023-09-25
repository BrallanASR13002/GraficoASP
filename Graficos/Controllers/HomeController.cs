using Graficos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Graficos.Controllers
{
    public class HomeController : Controller
    {
        private VentasContext _ventasContext;

        public HomeController(VentasContext ventasContext)
        {
            _ventasContext = ventasContext;
        }
        public ActionResult ResumenVenta()
        {
            DateTime FechaInicio = DateTime.Now;
            FechaInicio=FechaInicio.AddDays(-5);
            return View();
        }
        public IActionResult Index()
        {
            return View();
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