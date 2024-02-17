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

        public IActionResult BrandList(int page = 1, int pageSize = 10)
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
            TempData["SuccessMessage"] = "Marka başarıyla silindi.";
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
        public IActionResult SortById(int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll().OrderBy(b => b.Id);
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = pagedBrands.Count(x => x.Status == true);
            var False = pagedBrands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands);
        }
        public IActionResult SortByIdDescending(int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll().OrderByDescending(b => b.Id);
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = pagedBrands.Count(x => x.Status == true);
            var False = pagedBrands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands);
        }
        public IActionResult SortByName(int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll().OrderBy(b => b.Name);
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = pagedBrands.Count(x => x.Status == true);
            var False = pagedBrands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands);
        }
        public IActionResult SortByNameDescending(int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll().OrderByDescending(b => b.Name);
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = pagedBrands.Count(x => x.Status == true);
            var False = pagedBrands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands);
        }
        public IActionResult SortByDate(int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll().OrderBy(b => b.CreateDate);
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = pagedBrands.Count(x => x.Status == true);
            var False = pagedBrands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands);
        }
        public IActionResult SortByDateDescending(int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll().OrderByDescending(b => b.CreateDate);
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = pagedBrands.Count(x => x.Status == true);
            var False = pagedBrands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands);
        }
        public IActionResult SortByStatus(int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll().OrderBy(b => b.Status);
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = pagedBrands.Count(x => x.Status == true);
            var False = pagedBrands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands);
        }
        public IActionResult SortByStatusDescending(int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll().OrderByDescending(b => b.Status);
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = pagedBrands.Count(x => x.Status == true);
            var False = pagedBrands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands);
        }
            
    }
}

