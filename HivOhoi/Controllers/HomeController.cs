using HivOhoi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HivOhoi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HivOhoi()
        {
            HivOhoiModel model = new();

            model.HivValue = 3;
            model.OhoiValue = 5;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HivOhoi(HivOhoiModel hivOhoi)
        {
            List<string> hoItems = new();
            
            bool hiv;
            bool ohoi;

            for(int i = 1; i <= 100; i++)
            {
                hiv = (i % hivOhoi.HivValue == 0);
                ohoi = (i % hivOhoi.OhoiValue == 0);

                if (hiv && ohoi)
                {
                    hoItems.Add("HivOhoi");
                }
                else if (ohoi)
                {
                    hoItems.Add("Ohoi");
                }
                else if (hiv)
                {
                    hoItems.Add("Hiv");
                }
                else
                {
                    hoItems.Add(i.ToString());
                }
            }

            hivOhoi.Result = hoItems;

            return View(hivOhoi);
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