using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult BrandList()
        {
            var brands = _brandService.ListAll();
            var True = brands.Where(x => x.Status == true).Count();
            var False = brands.Where(x => x.Status == false).Count();
            ViewBag.True = True;
            ViewBag.False = False;
            return View(brands);
        }
    }
}
