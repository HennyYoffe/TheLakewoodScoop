using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson63_WebScraping_TheLakewoodScoop_May13.Models;
using ClassLibrary1;

namespace Lesson63_WebScraping_TheLakewoodScoop_May13.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var mgr = new ScoopManager();
            List<NewsItem> items = mgr.ScrapeLS();
            return View(items);
        }

       
    }
}
