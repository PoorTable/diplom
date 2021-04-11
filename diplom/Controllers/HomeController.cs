using diplom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Extensions.Logging;
using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace diplom.Controllers
{
    public class HomeController : Controller
    {
         private AppDBContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDBContext context)
        {
            _logger = logger;
            db = context;
        }

        
        public IActionResult Index()
        {
            ViewBag.Categories = db.categories.ToList();
            return View();
        }
        
        public IActionResult Privacy(string category, int? page)
        {
            var Catalogs = db.product.ToList();
            ViewBag.Categories = db.categories.ToList();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            if (!String.IsNullOrEmpty(category))
            {
                var Cat = db.product.ToList().Where(c => c.category == category);
                ViewData["CID"] = category;
                return View(Cat.ToPagedList(pageNumber, pageSize));
            }
            ViewData["CID"] = "";
            return View(Catalogs.ToPagedList(pageNumber, pageSize));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
