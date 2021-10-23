using GenericSample.Business.Abstract;
using GenericSample.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericSample.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_productService.GetAllProductsInclude());
        }
        public IActionResult Category(int? id)
        {
            return View(_productService.GetProductsByCategory(id));
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                _productService.Create(model);
                return RedirectToAction(nameof(Create));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Categories = _categoryService.GetAll();
            var updateCategory = _productService.GetById(id);

            if (updateCategory != null)
            {
                return View(updateCategory);
            }
            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(model);
                return RedirectToAction(nameof(Edit));
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            var deleteProduct = _productService.GetById(id);
            if (deleteProduct != null)
            {
                _productService.Delete(deleteProduct);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
