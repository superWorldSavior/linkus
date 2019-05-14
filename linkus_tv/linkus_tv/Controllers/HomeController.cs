using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using linkus_tv.Models;
using Microsoft.EntityFrameworkCore;

namespace linkus_tv.Controllers
{
    public class HomeController : Controller
    {
        private readonly linkus_tvContext _context;

        public HomeController(linkus_tvContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Carte.ToListAsync());
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
