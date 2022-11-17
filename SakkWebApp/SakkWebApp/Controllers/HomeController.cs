using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SakkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SakkWebApp.Models;

namespace SakkWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly sakkContext _context;

        public HomeController(ILogger<HomeController> logger, sakkContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var Figurak = _context.Figuraks.ToList();
            return View(Figurak);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
