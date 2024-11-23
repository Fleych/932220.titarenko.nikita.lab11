using System.Diagnostics;
using System.Numerics;
using _932220.titarenko.nikita.lab11.Models;
using Microsoft.AspNetCore.Mvc;
using _932220.titarenko.nikita.lab11.Services;

namespace _932220.titarenko.nikita.lab11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalcService _calcService;
        public HomeController(ILogger<HomeController> logger, ICalcService calcService)
        {
            _logger = logger;
            _calcService = calcService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UsingModelCalc()
        {
            int a = new Random().Next(0, 10);
            int b = new Random().Next(0, 10);
            string d = "Нельзя делить на 0!";

            if (b != 0)
            {
                int temp = a / b;
                d = temp.ToString();
            }

            var viewModel = new CalcModel()
            {
                first = a,
                second = b,
                add = a + b,
                sub = a - b,
                mult = a * b,
                div = d,
            };
            return View(viewModel);
        }

        public IActionResult UsingViewDataCalc() {
            int a = new Random().Next(0, 10);
            int b = new Random().Next(0, 10);

            ViewData["first"] = a;
            ViewData["second"] = b;
            ViewData["add"] = a + b;
            ViewData["sub"] = a - b;
            ViewData["mult"] = a * b;

            if (b == 0)
            {
                ViewData["div"] = "Нельзя делить на 0!";
            }
            else
            {
                ViewData["div"] = a / b;
            }

            return View();
        }

        public IActionResult UsingViewBagCalc()
        {
            int a = new Random().Next(0, 10);
            int b = new Random().Next(0, 10);

            ViewBag.First = a;
            ViewBag.Second = b;
            ViewBag.Add = a + b;
            ViewBag.Sub = a - b;
            ViewBag.Mult = a * b;

            if (b == 0)
            {
                ViewBag.Div = "Нельзя делить на 0!";
            }
            else
            {
                ViewBag.Div = a / b;
            }

            return View();
        }

        public IActionResult UsingServiceInjectionCalc()
        {
            int a = new Random().Next(0, 10);
            int b = new Random().Next(0, 10);

            ViewBag.First = a;
            ViewBag.Second = b;
            ViewBag.Add = _calcService.add(a, b);
            ViewBag.Sub = _calcService.sub(a, b);
            ViewBag.Mult = _calcService.mult(a, b);
            ViewBag.Div = _calcService.div(a, b);

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
