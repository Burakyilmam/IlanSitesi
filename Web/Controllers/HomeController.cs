using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
