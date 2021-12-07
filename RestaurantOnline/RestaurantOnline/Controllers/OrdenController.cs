using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Helper;
using RestaurantOnline.Models.ViewModels;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Controllers
{
    [Authorize]
    public class OrdenController : Controller
    {
        private ApplicationDbContext db;
        private IOrden iorden;
        private IDetalleOrden idetalleOrden;
        private IDomicilio idomicilio;
        private ICarrito icarrito;
        private IMetodoPago impago;
        private IDocumento idocumento;


        public int LastID;

        public OrdenController(ApplicationDbContext db, IOrden iorden, IDetalleOrden idetalleOrden, IDomicilio idomicilio, ICarrito icarrito, IMetodoPago impago, IDocumento idocumento)
        {
            this.db = db;
            this.iorden = iorden;
            this.idetalleOrden = idetalleOrden;
            this.idomicilio = idomicilio;
            this.icarrito = icarrito;
            this.impago = impago;
            this.idocumento = idocumento;
        }

        /***************************************************************************************************************************/
        //void LastOrder()
        //{

        //    var order = iorden.LastOfOrder();
        //    int Id = 0;

        //    foreach (var list in order)
        //    {
        //        Id = list.orden_id;
        //    }

        //    Id++;
        //    LastID = Id;

        //}

        /***********************************************************************************************************************/
        public IActionResult Orden()
        {
            var lstPago = impago.metodoPago();
            List<MPagoViewModel> lstMPago = (from p in lstPago
                                             select new MPagoViewModel { metodoPago_id = p.metodoPago_id, nombreMetodo = p.nombreMetodo }).ToList();

            List<SelectListItem> items = lstMPago.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.nombreMetodo.ToString(),
                    Value = x.metodoPago_id.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = items;

            var lstDocumento = idocumento.documento();
            List<DocumentoViewModel> lstDoc = (from d in lstDocumento
                                               select new DocumentoViewModel { documento_id = d.documento_id, nombreDocumento = d.nombreDocumento }).ToList();

            List<SelectListItem> items2 = lstDoc.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.nombreDocumento.ToString(),
                    Value = x.documento_id.ToString(),
                    Selected = false
                };
            });
            ViewBag.items2 = items2;


            if (User.Identity.IsAuthenticated)
            {
                LoginHelper.GetNameIdentifier(User);
                var userId = Convert.ToInt32(LoginHelper.GetNameIdentifier(User));

                var domiciliolist = db.tbl_Domicilio.Where(x => x.usuario_Fk == userId).ToList();
                foreach (var item in domiciliolist)
                {
                    ViewBag.domicilio_id = item.domicilio_id;
                    ViewBag.ubicacion = item.ubicacion;
                    ViewBag.referencia = item.referencia;
                }
                ViewBag.fecha = DateTime.Now;

                var carritolist = db.tbl_Carrito.Include(x => x.TblProducto).Where(x => x.usuario_Fk == userId).ToList();
                var sumaTotales = carritolist.Sum(x => x.totalP * x.cantidadP);
                ViewBag.Total = sumaTotales;

                return View(carritolist);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Venta(VentaViewModel datosOrden, tbl_Domicilio datosDomicilio)
        {
            var Order = new tbl_Orden();
            var Detalle = new tbl_DetalleOrden();
            int idD = datosDomicilio.domicilio_id;

            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    LoginHelper.GetNameIdentifier(User);
                    int usuario = Convert.ToInt32(LoginHelper.GetNameIdentifier(User));

                    if (idD == 0)
                    {
                        var domicilio = new tbl_Domicilio();
                        domicilio.usuario_Fk = usuario;
                        domicilio.ubicacion = datosDomicilio.ubicacion;
                        domicilio.referencia = datosDomicilio.referencia;
                        idomicilio.Insert(domicilio);
                    }
                    else
                    {
                        tbl_Domicilio domicilio = db.tbl_Domicilio.Where(x => x.domicilio_id == idD && x.usuario_Fk == usuario).FirstOrDefault();
                        domicilio.ubicacion = datosDomicilio.ubicacion;
                        domicilio.referencia = datosDomicilio.referencia;
                        idomicilio.Update(domicilio);
                    }

                    Order.fechaOrden = DateTime.Now;
                    Order.estadoOrden = "Procesando";
                    Order.user_FK = usuario;
                    Order.metodoPago_FK = 1;
                    Order.documento_Fk = 1;
                    iorden.Insert(Order);

                    var car = db.tbl_Carrito.Include(x => x.TblProducto).Where(x => x.usuario_Fk == usuario).ToList();
                    foreach (var item in car)
                    {
                        Detalle.cantidad = item.cantidadP;
                        Detalle.totalFinal = item.totalP * item.cantidadP;
                        Detalle.orden_FK = Order.orden_id;
                        Detalle.producto_Fk = item.producto_Fk;

                    }

                    idetalleOrden.Insert(Detalle);
                }
            }
            catch (Exception ex)
            {

            }

            return Redirect("/Home/Index");

        }
        /***********************************************************************************************************************/
    }
}
