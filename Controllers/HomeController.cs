using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoMvc.Models;

namespace todoMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GeneratePrime([Bind("InputNumber")] PrimeModel model)
        {
            model.Numbers = FindFactors(model.InputNumber);
            return View("Index", model);
        }

        private List<long> FindFactors(long num)
        {
            List<long> result = new List<long>();

            while (num % 2 == 0)
            {
                result.Add(2);
                num /= 2;
            }

            long factor = 3;
            while (factor * factor <= num)
            {
                if (num % factor == 0)
                {
                    result.Add(factor);
                    num /= factor;
                }
                else
                {
                    factor += 2;
                }
            }

            if (num > 1) result.Add(num);

            return result;
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
