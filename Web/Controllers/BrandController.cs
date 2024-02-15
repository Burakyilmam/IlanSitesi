using Business.Abstract;
using Entities;
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
        [HttpGet]
        public IActionResult BrandAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BrandAdd(Brand brand)
        {
            brand.Status = true;
            brand.CreateDate = DateTime.Now;
            _brandService.Add(brand);
            return RedirectToAction("BrandList");
        }
        public IActionResult BrandDelete(int id)
        {
            var value = _brandService.Get(id);
            _brandService.Delete(value);
            return RedirectToAction("BrandList");
        }
        [HttpGet]
        public IActionResult BrandUpdate(int id)
        {
            var value = _brandService.Get(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult BrandUpdate(Brand brand)
        {
            _brandService.Update(brand);
            return RedirectToAction("BrandList");
        }
    }
}
