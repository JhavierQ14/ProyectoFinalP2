using FastFoodRestaurant.Data;
using FastFoodRestaurant.Entidades;
using FastFoodRestaurant.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Repository
{
    public class DetalleOrdenRepository : IDetalleOrden
    {
        private ApplicationDbContext app;

        public DetalleOrdenRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Delete(tbl_DetalleOrden detalleOrden)
        {
            app.tbl_DetalleOrden.Remove(detalleOrden);
        }

        public ICollection<tbl_DetalleOrden> detalleOrden()
        {
            return app.tbl_DetalleOrden.ToList();
        }

        public void Insert(tbl_DetalleOrden detalleOrden)
        {
            app.Add(detalleOrden);
            app.SaveChanges();
        }

        public void Update(tbl_DetalleOrden detalleOrden)
        {
            app.Update(detalleOrden);
            app.SaveChanges();
        }
    }
}
