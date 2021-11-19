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
            return app.tbl_Carrito.ToList();
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
