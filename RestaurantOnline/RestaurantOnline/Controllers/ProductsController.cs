using Microsoft.AspNetCore.Mvc;
using RestaurantOnline.Data;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db;
        private IProducto iproducto;

        public ProductsController(ApplicationDbContext db, IProducto iproducto)
        {
            this.db = db;
            this.iproducto = iproducto;
        }

        public IActionResult Menu()
        {
            var productList = iproducto.ListofP();

            return View(productList);
        }
    }
}
