using Graficos.Models;
using Graficos.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            List<ViewModelVenta> Lista = (from tbventa in _ventasContext.Venta
                                          where tbventa.FechaRegistro.Value.Date >= FechaInicio.Date
                                          group tbventa by tbventa.FechaRegistro.Value.Date
                                          into grupo
                                          select new ViewModelVenta
                                          {
                                              Fecha=grupo.Key.ToString("dd/MM/yyyy"),
                                              Cantidad=grupo.Count(),
                                          }).ToList();
            return StatusCode(StatusCode.Status200Ok,Lista);
        }
        public ActionResult ResumenProductos()
        {
            List<ViewModelProduco> Lista=(from tddetalle ventain _ventasContext.Detall);
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