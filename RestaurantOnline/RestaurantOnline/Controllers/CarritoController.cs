using Microsoft.AspNetCore.Mvc;
using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantOnline.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantOnline.Controllers
{
    [Authorize]
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
            if (User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32(LoginHelper.GetNameIdentifier(User));

                var carritolist = db.tbl_Carrito.Include(x => x.TblProducto).Where(x => x.usuario_Fk == userId).ToList();
                var sumaTotales = carritolist.Sum(x => x.totalP * x.cantidadP);
                ViewBag.Total = sumaTotales;

                return View(carritolist);
            }

            return View();
        }

        public IActionResult Guardar(tbl_Carrito car)
        {
            tbl_Carrito carrito = new tbl_Carrito();

                int usuario = Convert.ToInt32(LoginHelper.GetNameIdentifier(User));
                var repeticion = db.tbl_Carrito.Where(a => a.producto_Fk.Equals(car.producto_Fk) && a.usuario_Fk == usuario).FirstOrDefault();

            if (repeticion == null)
            {
                carrito.cantidadP = 1;
                carrito.totalP = car.totalP;
                carrito.usuario_Fk = usuario;
                carrito.producto_Fk = car.producto_Fk;

                icarrito.Insert(carrito);

                return Redirect("/Products/Menu");
            }
            else
            {
                return Redirect("/Products/Menu");
            }

                
        }

        public IActionResult Eliminar(int id)
        {

            int IdCar = id;
            tbl_Carrito deleteI = db.tbl_Carrito.Where(x => x.carrito_id == IdCar).FirstOrDefault();


            icarrito.Delete(deleteI);

            return Redirect("/Carrito/Carrito");
        }

        [HttpPost]
        public IActionResult Actualizar(int carrito_id, int cantidadP)
        {
            if (User.Identity.IsAuthenticated)
            {
                int usuario = Convert.ToInt32(LoginHelper.GetNameIdentifier(User));
                int idD = carrito_id;

                tbl_Carrito carrito = db.tbl_Carrito.Where(x => x.carrito_id == idD && x.usuario_Fk == usuario).FirstOrDefault();
                carrito.cantidadP = cantidadP;
                icarrito.Update(carrito);
            }

            return Redirect("/Carrito/Carrito");
        }
        public IActionResult Regresar()
        {
            return Redirect("/Products/Menu");
        }


        public IActionResult Validar()
        {
            List<tbl_Carrito> carritolist;
            var userId = Convert.ToInt32(LoginHelper.GetNameIdentifier(User));
            carritolist = db.tbl_Carrito.Include(x => x.TblProducto).Where(x => x.usuario_Fk == userId).ToList();

            if (carritolist.Count() > 0)
            {
               
                return Redirect("/Orden/Orden");
            }
            else
            {
                ViewBag.mensaje = "Debes agregar Comidas para relizar tu orden";
                return Redirect("/Carrito/Carrito");
            }        
        }

    }
}
