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
        public IActionResult BrandList(string p,int page = 1, int pageSize = 10)
        {
            ViewBag.Search = p;
            var brands = _brandService.ListAll();
            if (!string.IsNullOrEmpty(p))
            {
                brands = brands.Where(x => x.Name.ToLower().Contains(p.ToLower())).ToList();
            }
            var totalCount = brands.Count();

            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = brands.Count(x => x.Status == true);
            var False = brands.Count(x => x.Status == false);

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
        public IActionResult SortById(string p,int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll();
            if (!string.IsNullOrEmpty(p))
            {
                brands = brands.Where(x => x.Name.ToLower().Contains(p.ToLower())).ToList();
            }
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = brands.Count(x => x.Status == true);
            var False = brands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands.OrderBy(b => b.Id));
        }
        public IActionResult SortByIdDescending(string p, int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll();
            if (!string.IsNullOrEmpty(p))
            {
                brands = brands.Where(x => x.Name.ToLower().Contains(p.ToLower())).ToList();
            }
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = brands.Count(x => x.Status == true);
            var False = brands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands.OrderByDescending(b => b.Id));
        }
        public IActionResult SortByName(string p, int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll();
            if (!string.IsNullOrEmpty(p))
            {
                brands = brands.Where(x => x.Name.ToLower().Contains(p.ToLower())).ToList();
            }
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = brands.Count(x => x.Status == true);
            var False = brands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands.OrderBy(b => b.Name));
        }
        public IActionResult SortByNameDescending(string p, int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll();
            if (!string.IsNullOrEmpty(p))
            {
                brands = brands.Where(x => x.Name.ToLower().Contains(p.ToLower())).ToList();
            }
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = brands.Count(x => x.Status == true);
            var False = brands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands.OrderByDescending(b => b.Name));
        }
        public IActionResult SortByDate(string p,int page = 1, int pageSize = 10)
        {
            ViewBag.Search = p;
            var brands = _brandService.ListAll();
            if (!string.IsNullOrEmpty(p))
            {
                brands = brands.Where(x => x.Name.ToLower().Contains(p.ToLower())).ToList();
            }
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = brands.Count(x => x.Status == true);
            var False = brands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands.OrderBy(b => b.CreateDate));
        }
        public IActionResult SortByDateDescending(string p, int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll();
            if (!string.IsNullOrEmpty(p))
            {
                brands = brands.Where(x => x.Name.ToLower().Contains(p.ToLower())).ToList();
            }
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = brands.Count(x => x.Status == true);
            var False = brands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands.OrderByDescending(b => b.CreateDate));
        }
        public IActionResult SortByStatus(string p, int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll();
            if (!string.IsNullOrEmpty(p))
            {
                brands = brands.Where(x => x.Name.ToLower().Contains(p.ToLower())).ToList();
            }
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = brands.Count(x => x.Status == true);
            var False = brands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands.OrderBy(b => b.Status));
        }
        public IActionResult SortByStatusDescending(string p, int page = 1, int pageSize = 10)
        {
            var brands = _brandService.ListAll();
            if (!string.IsNullOrEmpty(p))
            {
                brands = brands.Where(x => x.Name.ToLower().Contains(p.ToLower())).ToList();
            }
            var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = brands.Count(x => x.Status == true);
            var False = brands.Count(x => x.Status == false);
            var totalCount = brands.Count();
            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            return View(pagedBrands.OrderByDescending(b => b.Status));
        }
            
    }
}

