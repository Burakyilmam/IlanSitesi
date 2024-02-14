using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Home()
        {
            var trueCategories = _categoryService.True();
            return View(trueCategories);
        }
    }
}
