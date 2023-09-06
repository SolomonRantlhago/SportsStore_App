using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class AdminController : Controller
    {
        private IRepositoryWrapper _repository;
        public AdminController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(new ProductsListViewModel
            {
                Products = _repository.Product.FindAll()
            });
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Add Products";
            PopulateCategoryDDL();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            PopulateCategoryDDL();
            if(_repository.Product.GetById(product.ProductID)==null)
            {
                if (ModelState.IsValid)
                {
                    _repository.Product.Create(product);
                    _repository.Product.Save();
                    TempData["Message"] = $"{product.Name} has been Saved";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(product);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _repository.Product.Update(product);
                    _repository.Product.Save();
                    TempData["Message"] = $"{product.Name} has been Saved";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(product);
                }
                
            }
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Products";
            PopulateCategoryDDL();
            return View("Create",_repository.Product.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            var product = _repository.Product.GetById(id);
            if (product == null)
                return NotFound();
            else
            {
                _repository.Product.Delete(product);
                _repository.Product.Save();
                TempData["Message"] = $"{product.Name} was deleted";
                return RedirectToAction("Index");
            }
        }

        private void PopulateCategoryDDL(object selectedCategory = null)
        {
            ViewBag.CategoryID = new SelectList(_repository.Category.FindAll(),
                "CategoryID", "CategoryName", selectedCategory);
        }

    }
}
