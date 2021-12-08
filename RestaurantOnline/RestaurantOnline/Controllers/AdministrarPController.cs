using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Controllers
{
    public class AdministrarPController : Controller
    {

        private ApplicationDbContext db;
        private IProducto iproducto;
        private IMenu imenu;

        public AdministrarPController(ApplicationDbContext db, IProducto iproducto, IMenu imenu)
        {
            this.db = db;
            this.iproducto = iproducto;
            this.imenu = imenu;

        }

        public IActionResult AgregarProductos()
        {
            var productos = iproducto.ListofP();
            return View(productos);
        }

        public IActionResult Save(tbl_Producto productos)
        {

            tbl_Producto producto = new tbl_Producto();


            if (productos.producto_id == 0)
            {
                producto.nombreProducto = productos.nombreProducto;
                producto.precioP = productos.precioP;
                producto.fechaCreacionP = DateTime.Now;
                producto.estadoProducto = "activo";
                producto.imageP = productos.imageP;
                producto.menu_Fk = productos.menu_Fk;

                iproducto.Insert(producto);
            }
            else
            {
                int update = productos.producto_id;
                tbl_Producto editar = db.tbl_Producto.Where(x => x.producto_id == update).FirstOrDefault();
                editar.nombreProducto = productos.nombreProducto;
                editar.precioP = productos.precioP;
                editar.estadoProducto = productos.estadoProducto;
                editar.imageP = productos.imageP;
                editar.menu_Fk = productos.menu_Fk;

                iproducto.Update(editar);
            }

     
                return Redirect("/Administracion/Products");
           
            

        }

        public IActionResult DatosProductos( tbl_Producto productos)
        {
            ViewBag.productoid = productos.producto_id;
            ViewBag.nombreProducto = productos.nombreProducto;
            ViewBag.preciop = productos.precioP;
            ViewBag.fechaProducto = productos.fechaCreacionP;
            ViewBag.estadoProducto = productos.estadoProducto;
            ViewBag.imageP = productos.imageP;
            ViewBag.menuFK = productos.menu_Fk;

            var cbxMenu = imenu.ListMenu();

            List<SelectListItem> listMenu = new List<SelectListItem>();

            foreach (var item in cbxMenu)
            {
                listMenu.Add(
                    new SelectListItem
                    {
                        Text = item.nombreMenu,
                        Value = Convert.ToString(item.menu_id)
                    });

                ViewBag.MList = listMenu;
            }

            return View("DatosProductos");
        }

        public IActionResult DeleteProduts(tbl_Producto producto)
        {
            int codId = producto.producto_id;
            tbl_Producto deleteL = db.tbl_Producto.Where(x => x.producto_id == codId).FirstOrDefault();
            deleteL.estadoProducto = "inactivo";

            iproducto.Update(deleteL);

            return Redirect("/Administracion/Products");
        }

        public IActionResult ComboProducts(tbl_Producto pro)
        {

            return View("DatosProductos");
        }


    }
}