using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_5.Controllers
{
    public class PointOfSalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}