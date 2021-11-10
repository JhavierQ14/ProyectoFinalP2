using FastFoodRestaurant.Data;
using FastFoodRestaurant.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db;
        private IUsuario iuser;

        public UserController(ApplicationDbContext db, IUsuario iuser)
        {
            this.db = db;
            this.iuser = iuser;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
