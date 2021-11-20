using Microsoft.AspNetCore.Mvc;
using RestaurantOnline.Data;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Controllers
{
    public class OrdenController : Controller
    {
        private IOrden iorden;
        private IDetalleOrden idetalleOrden;
        private ApplicationDbContext db;

        int LastID;

        void ultimocorrelativoventa()
        {

            var consultaultimaventa = iorden.LastOfOrder();
            int lista = 0;

            foreach (var list in consultaultimaventa)
            {
                lista = list.orden_id;
            }



            lista++;
            LastID = lista;


        }

        public OrdenController(ApplicationDbContext db, IOrden iorden, IDetalleOrden idetalleOrden)
        {
            this.db = db;
        }

        public IActionResult Orden()
        {
            return View();
        }

        public IActionResult Venta()
        {
            return View();

        }

        public IActionResult DetalleVenta()
        {
            return View();

        }
    }
}
