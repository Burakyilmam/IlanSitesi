using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
