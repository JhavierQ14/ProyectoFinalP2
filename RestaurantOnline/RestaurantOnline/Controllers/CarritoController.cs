using Microsoft.AspNetCore.Mvc;
using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantOnline.Helper;

namespace RestaurantOnline.Controllers
{
    public class CarritoController : Controller
    {

        private ICarrito icarrito;
        private ApplicationDbContext db;

        public CarritoController(ApplicationDbContext db, ICarrito icarrito)
        {
            this.db = db;
            this.icarrito = icarrito;
        }
        public IActionResult Carrito()
        {
            var carritolist = icarrito.listCarrito();
            //var carritoUnion = (from union in carritolist
            //                    select new
            //                    {  
            //                    union.Tbl_Producto.imageP,
            //                    union.Tbl_Producto.nombreProducto,
            //                    union.cantidadP,
            //                    union.totalP
            //                    }).ToList();

            return View(carritolist);
        }

        public IActionResult Guardar(tbl_Carrito car)
        {
            tbl_Carrito carrito = new tbl_Carrito();

            if (User.Identity.IsAuthenticated)
            {
                LoginHelper.GetNameIdentifier(User);

                carrito.cantidadP = 1;
                carrito.totalP = car.totalP;
                carrito.usuario_Fk = Convert.ToInt32(LoginHelper.GetNameIdentifier(User));
                //carrito.combo_FK = 0;
                carrito.producto_Fk = car.producto_Fk;

                icarrito.Insert(carrito);
            }

            return Redirect("/Products/Menu");
        }

   
      
        
    }
}
