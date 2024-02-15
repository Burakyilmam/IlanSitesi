using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
