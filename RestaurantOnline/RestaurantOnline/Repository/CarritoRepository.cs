using Microsoft.EntityFrameworkCore;
using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Repository
{
    public class CarritoRepository : ICarrito

    {
        private ApplicationDbContext app;

        public CarritoRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public List<tbl_Carrito> listCarrito()
        {
            var Car = app.tbl_Carrito
                .Include(x => x.TblProducto)
                .ToList();

            //var listado = (from carrito in app.tbl_Carrito
            //               from producto in app.tbl_Producto
            //where (carrito.producto_Fk == producto.producto_id)
            //select new
            //{
            //    producto.imageP,
            //    producto.nombreProducto,
            //    carrito.cantidadP,
            //    carrito.totalP,

            //}).ToList();


            return Car;
        }

        public void Delete(tbl_Carrito carrito)
        {
            app.tbl_Carrito.Remove(carrito);
        }

        public void Insert(tbl_Carrito carrito)
        {
            app.Add(carrito);
            app.SaveChanges();
        }

        public void Update(tbl_Carrito carrito)
        {
            app.Update(carrito);
            app.SaveChanges();
        }

        //var Car = app.tbl_Carrito.Include(x => x.Tbl_Producto).Include(x => x.Tbl_Combo).Where(x=> x.)
        //    .ToList();

    }
}
