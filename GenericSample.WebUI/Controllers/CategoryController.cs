using GenericSample.Business.Abstract;
using GenericSample.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericSample.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategoriesInclude());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(model);
                return RedirectToAction(nameof(Create));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var updateCategory = _categoryService.GetById(id);
            if (updateCategory != null)
            {
                return View(updateCategory);
            }
            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(model);
                return RedirectToAction(nameof(Edit));
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            var deleteCategory = _categoryService.GetById(id);
            if (deleteCategory != null)
            {
                _categoryService.Delete(deleteCategory);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
