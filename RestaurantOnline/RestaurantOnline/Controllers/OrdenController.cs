using Microsoft.AspNetCore.Mvc;
using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
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

        public int LastID;

        public OrdenController(ApplicationDbContext db, IOrden iorden, IDetalleOrden idetalleOrden)
        {
            this.db = db;
            this.iorden = iorden;
            this.idetalleOrden = idetalleOrden;
        }

/***************************************************************************************************************************/
        void LastOrder()
        {

            var order = iorden.LastOfOrder();
            int Id = 0;

            foreach (var list in order)
            {
                Id = list.orden_id;
            }

            Id++;
            LastID = Id;

        }

/***********************************************************************************************************************/
        public IActionResult Orden()
        {
            return View();
        }

        public IActionResult Venta(tbl_Orden datosOrden, tbl_DetalleOrden datosDetalle)
        {
            var Order = new tbl_Orden();
            var Detalle = new tbl_DetalleOrden();

            try
            {
                Order.fechaOrden = DateTime.Now;
                Order.estadoOrden = datosOrden.estadoOrden;
                Order.user_FK = datosOrden.user_FK;
                Order.metodoPago_FK = datosOrden.metodoPago_FK;
                Order.documento_Fk = datosOrden.documento_Fk;

                iorden.Insert(Order);

                Detalle.cantidad = datosDetalle.cantidad;

                idetalleOrden.Insert(Detalle);

            }
            catch
            {

            }



            return View();

        }

        public IActionResult DetalleVenta()
        {
            return View();

        }


/***********************************************************************************************************************/
    }
}
