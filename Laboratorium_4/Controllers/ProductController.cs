using Laboratorium_4.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorium_3.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IDateTimeProvider _timeProvider;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // MAIN VIEW
        // GET: /Product
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }


        // DETAILS
        // GET: /Product/Details/1
        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // ADDING
        // GET: /Product/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }

        // POST: /Product/Create
        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", model);
            }
        }

        // EDITING

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View("Edit", product);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(model.Id, model);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", model);
            }
        }

        // DELETING
        // GET: /Product/Delete/1

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: /Product/DeleteConfirmed/1
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}