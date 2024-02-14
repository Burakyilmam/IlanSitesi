using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;

        public HomeController(ICarService carService)
        {
            _carService = carService;
        }
        public IActionResult Home()
        {
            var Included = _carService.Include();
            return View(Included);
        }
    }
}
