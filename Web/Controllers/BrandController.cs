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

        public IActionResult BrandList(int page = 1, int pageSize = 5)
        {
            var brands = _brandService.ListAll();
            var totalCount = brands.Count();

            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = pagedBrands.Count(x => x.Status == true);
            var False = pagedBrands.Count(x => x.Status == false);

            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;

            return View(pagedBrands);
        }

        [HttpGet]
        public IActionResult BrandAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BrandAdd(Brand brand)
        {
            var brandExist = _brandService.Check(b => b.Name == brand.Name);
            if (brandExist == false)
            {
                brand.Status = true;
                brand.CreateDate = DateTime.Now;
                _brandService.Add(brand);
                return RedirectToAction("BrandList");
            }
            else
            {
                TempData["ErrorMessage"] = "Marka Adı Bulunmaktadır. Lütfen Aşağıdaki Alana Veritabanında Bulunmayan Bir Marka Adı Yazınız.";
                return RedirectToAction("BrandList");
            }
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
        public IActionResult SortById()
        {
            var brands = _brandService.ListAll().OrderBy(b => b.Id);
            var True = brands.Where(x => x.Status == true).Count();
            var False = brands.Where(x => x.Status == false).Count();
            var Count = brands.Count();
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.Count = Count;
            return View(brands);
        }
        public IActionResult SortByIdDescending()
        {
            var brands = _brandService.ListAll().OrderByDescending(b => b.Id);
            var True = brands.Where(x => x.Status == true).Count();
            var False = brands.Where(x => x.Status == false).Count();
            var Count = brands.Count();
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.Count = Count;
            return View(brands);
        }
        public IActionResult SortByName()
        {
            var brands = _brandService.ListAll().OrderBy(b => b.Name);
            var True = brands.Where(x => x.Status == true).Count();
            var False = brands.Where(x => x.Status == false).Count();
            var Count = brands.Count();
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.Count = Count;
            return View(brands);
        }
        public IActionResult SortByNameDescending()
        {
            var brands = _brandService.ListAll().OrderByDescending(b => b.Name);
            var True = brands.Where(x => x.Status == true).Count();
            var False = brands.Where(x => x.Status == false).Count();
            var Count = brands.Count();
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.Count = Count;
            return View(brands);
        }
        public IActionResult SortByDate()
        {
            var brands = _brandService.ListAll().OrderBy(b => b.CreateDate);
            var True = brands.Where(x => x.Status == true).Count();
            var False = brands.Where(x => x.Status == false).Count();
            var Count = brands.Count();
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.Count = Count;
            return View(brands);
        }
        public IActionResult SortByDateDescending()
        {
            var brands = _brandService.ListAll().OrderByDescending(b => b.CreateDate);
            var True = brands.Where(x => x.Status == true).Count();
            var False = brands.Where(x => x.Status == false).Count();
            var Count = brands.Count();
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.Count = Count;
            return View(brands);
        }
        public IActionResult SortByStatus()
        {
            var brands = _brandService.ListAll().OrderBy(b => b.Status);
            var True = brands.Where(x => x.Status == true).Count();
            var False = brands.Where(x => x.Status == false).Count();
            var Count = brands.Count();
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.Count = Count;
            return View(brands);
        }
        public IActionResult SortByStatusDescending()
        {
            var brands = _brandService.ListAll().OrderByDescending(b => b.Status);
            var True = brands.Where(x => x.Status == true).Count();
            var False = brands.Where(x => x.Status == false).Count();
            var Count = brands.Count();
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.Count = Count;
            return View(brands);
        }
    }
}
