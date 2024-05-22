using labrab2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace labrab2.Controllers
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
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult TaskFirst()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TaskFirst(string a, string b, string c)
        {
            if (double.TryParse(a, out double n1) && double.TryParse(b, out double n2) && double.TryParse(c, out double n3))
            {
                double[] numbers = { n1, n2, n3 };
                List<double> result = new List<double>();
                foreach (var number in numbers)
                {
                    if (number > -3 && number <= 9)
                    {
                        result.Add(number);
                    }
                }
                ViewBag.Result = result;
                return View();
            }
            else
            {
                ViewBag.E = "¬ведены некорректные данные, попробуйте еще раз";
                return View();
            }
        }
        public IActionResult TaskSecond()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TaskSecond(string text1)
        {
            int first = text1.IndexOf("€") + 1;
            int last = text1.LastIndexOf("€") + 1;
            if (first == 0)
            {
                ViewBag.Text = $"Ѕукв € нет в предложении: {text1}";
            }
            else
            {
                ViewBag.Text = text1;
                ViewBag.First = first;
                ViewBag.Last = last;
            }
            return View();
        }
        public IActionResult TaskThird()
        {
            int[] array = new int[20];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-15, 41);
            }

            double sum = 0;

            for (int i = 0; i < array.Length; i += 2)
            {
                if (array[i] > 0)
                {
                    sum += array[i];
                }
            }
            ViewBag.Array = array;
            ViewBag.Sum = sum;
            return View();
        }
    }
}