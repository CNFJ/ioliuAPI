using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using admin.ioliu.net.Models;
using Microsoft.EntityFrameworkCore;
using ioliu.Data;
using ioliu.Domain;

namespace admin.ioliu.net.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IoliuContext _context;

        public HomeController(ILogger<HomeController> logger,IoliuContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var user = _context.systemUsers.Where(i=>i.UserName=="df").ToList();
            if (user.Count == 0) { 
            SystemUsers systemUsers = new SystemUsers
            {
                Id = Guid.NewGuid(),
                UserName="df",
                PassWord="df727123."
            };
                _context.systemUsers.Add(systemUsers);
            }
            var df = _context.systemUsers.ToList();
            ViewBag.vuw = df;
            return View(df);
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
