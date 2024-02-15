using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
