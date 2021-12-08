using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantOnline.Service;
using RestaurantOnline.Data;
using Microsoft.EntityFrameworkCore;
using RestaurantOnline.Entidades;

namespace RestaurantOnline.Controllers
{
    public class AdministracionController : Controller
    {
        private ApplicationDbContext db;
        private IOrden iorden;
        private IProducto iproducto;
        private IUsuario iusuario;


        public AdministracionController(ApplicationDbContext db, IOrden iorden, IProducto iproducto, IUsuario iusuario)
        {
            this.db = db;
            this.iorden = iorden;
            this.iproducto = iproducto;
            this.iusuario = iusuario;
        }
/********************************************************/
        public IActionResult Order()
        {
            var ordenes = iorden.Orden();

            return View(ordenes);
        }
        public IActionResult DetalleOrden(int orden_FK)
        {

            var ordenDetalle = db.tbl_DetalleOrden
                .Include(x => x.TblProducto) 
                .Where(x => x.orden_FK == orden_FK)
                .ToList();

            return View(ordenDetalle);
        }
        public IActionResult Confirmacion(int orden_id)
        {
            var Order = db.tbl_Orden.Where(x => x.orden_id == orden_id).FirstOrDefault();
            Order.estadoOrden = "Enviada";
            iorden.Update(Order);

            return Redirect("/Administracion/Order");
        }
/******************************************************************/
        public IActionResult Products()
        {
            var ListProdducto = iproducto.ListofP();

            return View(ListProdducto);
        }
/*****************************************************************/
        public IActionResult Users()
        {
            var ListUserSystem = iusuario.ListarUsuario();

            return View(ListUserSystem);
        }
        public IActionResult Actualizar(int usuario_id)
        {

            var User = db.tbl_User.Where(x => x.usuario_id == usuario_id).FirstOrDefault();
            User.rolUser_Fk = 2;
            iusuario.Update(User);
            return Redirect("/Administracion/Users");
        }

        /******************************************************************/
        public IActionResult Mas()
        {
            return View();
        }

    }
}
