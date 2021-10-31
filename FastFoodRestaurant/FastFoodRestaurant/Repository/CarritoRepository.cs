using FastFoodRestaurant.Data;
using FastFoodRestaurant.Entidades;
using FastFoodRestaurant.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Repository
{
    public class CarritoRepository : ICarrito

    {
        private ApplicationDbContext app;

        public CarritoRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public ICollection<tbl_Carrito> carrito()
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
    }
}
