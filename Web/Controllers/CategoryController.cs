using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult CategoryList(int page = 1, int pageSize = 10)
        {
            var categories = _categoryService.ListAll();
            var totalCount = categories.Count();

            var pagedCategories = categories.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var True = pagedCategories.Count(x => x.Status == true);
            var False = pagedCategories.Count(x => x.Status == false);

            ViewBag.Count = totalCount;
            ViewBag.True = True;
            ViewBag.False = False;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;

            return View(pagedCategories);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            var categoryExist = _categoryService.Check(b => b.Name == category.Name);
            if (categoryExist == false)
            {
                category.Status = true;
                category.CreateDate = DateTime.Now;
                _categoryService.Add(category);
                return RedirectToAction("CategoryList");
            }
            else
            {
                TempData["ErrorMessage"] = "Kategori Adı Bulunmaktadır. Lütfen Aşağıdaki Alana Veritabanında Bulunmayan Bir Kategori Adı Yazınız.";
                return RedirectToAction("CategoryList");
            }
        }
        public IActionResult CategoryDelete(int id)
        {
            var value = _categoryService.Get(id);
            _categoryService.Delete(value);
            TempData["SuccessMessage"] = "Kategori başarıyla silindi.";
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var value = _categoryService.Get(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            _categoryService.Update(category);
            return RedirectToAction("CategoryList");
        }
        //public IActionResult SortById(int page = 1, int pageSize = 10)
        //{
        //    var brands = _brandService.ListAll().OrderBy(b => b.Id);
        //    var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    var True = pagedBrands.Count(x => x.Status == true);
        //    var False = pagedBrands.Count(x => x.Status == false);
        //    var totalCount = brands.Count();
        //    ViewBag.Count = totalCount;
        //    ViewBag.True = True;
        //    ViewBag.False = False;
        //    ViewBag.PageNumber = page;
        //    ViewBag.PageSize = pageSize;
        //    return View(pagedBrands);
        //}
        //public IActionResult SortByIdDescending(int page = 1, int pageSize = 10)
        //{
        //    var brands = _brandService.ListAll().OrderByDescending(b => b.Id);
        //    var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    var True = pagedBrands.Count(x => x.Status == true);
        //    var False = pagedBrands.Count(x => x.Status == false);
        //    var totalCount = brands.Count();
        //    ViewBag.Count = totalCount;
        //    ViewBag.True = True;
        //    ViewBag.False = False;
        //    ViewBag.PageNumber = page;
        //    ViewBag.PageSize = pageSize;
        //    return View(pagedBrands);
        //}
        //public IActionResult SortByName(int page = 1, int pageSize = 10)
        //{
        //    var brands = _brandService.ListAll().OrderBy(b => b.Name);
        //    var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    var True = pagedBrands.Count(x => x.Status == true);
        //    var False = pagedBrands.Count(x => x.Status == false);
        //    var totalCount = brands.Count();
        //    ViewBag.Count = totalCount;
        //    ViewBag.True = True;
        //    ViewBag.False = False;
        //    ViewBag.PageNumber = page;
        //    ViewBag.PageSize = pageSize;
        //    return View(pagedBrands);
        //}
        //public IActionResult SortByNameDescending(int page = 1, int pageSize = 10)
        //{
        //    var brands = _brandService.ListAll().OrderByDescending(b => b.Name);
        //    var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    var True = pagedBrands.Count(x => x.Status == true);
        //    var False = pagedBrands.Count(x => x.Status == false);
        //    var totalCount = brands.Count();
        //    ViewBag.Count = totalCount;
        //    ViewBag.True = True;
        //    ViewBag.False = False;
        //    ViewBag.PageNumber = page;
        //    ViewBag.PageSize = pageSize;
        //    return View(pagedBrands);
        //}
        //public IActionResult SortByDate(int page = 1, int pageSize = 10)
        //{
        //    var brands = _brandService.ListAll().OrderBy(b => b.CreateDate);
        //    var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    var True = pagedBrands.Count(x => x.Status == true);
        //    var False = pagedBrands.Count(x => x.Status == false);
        //    var totalCount = brands.Count();
        //    ViewBag.Count = totalCount;
        //    ViewBag.True = True;
        //    ViewBag.False = False;
        //    ViewBag.PageNumber = page;
        //    ViewBag.PageSize = pageSize;
        //    return View(pagedBrands);
        //}
        //public IActionResult SortByDateDescending(int page = 1, int pageSize = 10)
        //{
        //    var brands = _brandService.ListAll().OrderByDescending(b => b.CreateDate);
        //    var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    var True = pagedBrands.Count(x => x.Status == true);
        //    var False = pagedBrands.Count(x => x.Status == false);
        //    var totalCount = brands.Count();
        //    ViewBag.Count = totalCount;
        //    ViewBag.True = True;
        //    ViewBag.False = False;
        //    ViewBag.PageNumber = page;
        //    ViewBag.PageSize = pageSize;
        //    return View(pagedBrands);
        //}
        //public IActionResult SortByStatus(int page = 1, int pageSize = 10)
        //{
        //    var brands = _brandService.ListAll().OrderBy(b => b.Status);
        //    var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    var True = pagedBrands.Count(x => x.Status == true);
        //    var False = pagedBrands.Count(x => x.Status == false);
        //    var totalCount = brands.Count();
        //    ViewBag.Count = totalCount;
        //    ViewBag.True = True;
        //    ViewBag.False = False;
        //    ViewBag.PageNumber = page;
        //    ViewBag.PageSize = pageSize;
        //    return View(pagedBrands);
        //}
        //public IActionResult SortByStatusDescending(int page = 1, int pageSize = 10)
        //{
        //    var brands = _brandService.ListAll().OrderByDescending(b => b.Status);
        //    var pagedBrands = brands.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    var True = pagedBrands.Count(x => x.Status == true);
        //    var False = pagedBrands.Count(x => x.Status == false);
        //    var totalCount = brands.Count();
        //    ViewBag.Count = totalCount;
        //    ViewBag.True = True;
        //    ViewBag.False = False;
        //    ViewBag.PageNumber = page;
        //    ViewBag.PageSize = pageSize;
        //    return View(pagedBrands);
        //}

    }
}

