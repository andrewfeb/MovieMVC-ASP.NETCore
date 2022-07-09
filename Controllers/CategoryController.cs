﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMVC.Repositories.Interfaces;
using MovieMVC.Models;
using Microsoft.Extensions.Logging;

namespace MovieMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _category;
        private readonly ILogger _logger;
        public CategoryController(ICategoryRepository category, ILogger<CategoryController> logger)
        {
            _category = category;
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Category> categories = _category.GetAll().ToList();
            _logger.LogInformation("Log message in the Index() method");

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _category.Insert(category);

                return RedirectToAction("index");
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            Category category = _category.GetById(id);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _category.Update(category);
                return RedirectToAction("index");
            }
            return View(category);
        }

        public IActionResult Delete(Category category)
        {
            _category.Delete(category);
            return RedirectToAction("index");
        }

        public IActionResult Detail(int id)
        {
            Category category = _category.GetDetail(id);

            return View(category);
        }
    }
}
