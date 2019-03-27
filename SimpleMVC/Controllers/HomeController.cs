using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Metrics;
using App.Metrics.Counter;
using Microsoft.AspNetCore.Mvc;
using SimpleMVC.Metrics;
using SimpleMVC.Models;

namespace SimpleMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMetrics _metrics;

        public HomeController(IMetrics metrics)
        {
            _metrics = metrics;
        }

        public IActionResult Index()
        {
            _metrics.Measure.Counter.Increment(MetricsRegistry.HomeCounter);
            _metrics.Measure.Gauge.SetValue(MetricsRegistry.Warning, 1);
            return View();
        }

        public IActionResult Privacy()
        {
            _metrics.Measure.Counter.Increment(MetricsRegistry.PrivacyCounter);
            return View();
        }
        
        public IActionResult Long()
        {
            var rnd = new Random();
            var sleep = rnd.Next(2, 5) * 500;
            Thread.Sleep(sleep);
            
            ViewData["Message"] = $"Job took: {sleep} ms.";
            return View("Index");
        }
        
        public IActionResult ToggleDb()
        {
            
            DbStatus.Toogle();
            ViewData["Message"] = "Database status changed";
            return View("Index");
        }
        
        public IActionResult ToggleDependency()
        {
            DependencyStatus.Toogle();
            ViewData["Message"] = "Dependency status changed";
            return View("Index");
        }

        public IActionResult ThrowError()
        {
            var rnd = new Random();
            var next = rnd.Next(0, 5);

            switch (next)
            {
                case 0:
                    return NotFound();
                
                case 1:
                    return Unauthorized();
                
                case 2:
                    return Forbid();
                
                case 3:
                    return BadRequest();
                
                case 4:
                    return StatusCode(500);
                
                default:
                    throw new Exception("Ugly one");
            }
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}