using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Controllers
{
    public class CopyrightController : Controller
    {
        public IActionResult Terminos()
        {
            return View();
        }
    }
}
