using Laboratiorium_1.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laboratiorium_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // @@@Route INDEX
        public IActionResult Index()
        {
            return View();
        }
        // @@@Route PRIVACY
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // @@@Route ERROR
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // @@@Route ABOUT
        public IActionResult About()
        {
            return View();
        }
        // @@@Route Calculator

        public enum Operator
        {
            Unknown, Add, Mul, Sub, Div
        }

        // @@@ACTION Calculator
        public IActionResult Calculator(double? a, Operator op, double? b)
        {
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.op = op;

            if (a == null || b == null)
            {
                ViewData["Message"] = "Number are not correct";
                return View("Error");
            }
              

            switch (op) {
                case Operator.Add: ViewBag.result = a + b; break;
                case Operator.Mul: ViewBag.result = a * b; break;
                case Operator.Sub: ViewBag.result = a - b; break;
                case Operator.Div: ViewBag.result = a / b; break;
                case Operator.Unknown:
                    ViewData["Message"] = "The operator is wrong!";
                    return View("Error");
            }

            return View();
        }
    }
}