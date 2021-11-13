using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Repository
{
    public class MetodoPagoRepository : IMetodoPago
    {
        private ApplicationDbContext app;

        public MetodoPagoRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Delete(tbl_MetodoPago metodoPago)
        {
            app.tbl_MetodoPago.Remove(metodoPago);
        }

        public void Insert(tbl_MetodoPago metodoPago)
        {
            app.Add(metodoPago);
            app.SaveChanges();
        }

        public ICollection<tbl_MetodoPago> metodoPago()
        {
            return app.tbl_MetodoPago.ToList();
        }

        public void Update(tbl_MetodoPago metodoPago)
        {
            app.Update(metodoPago);
            app.SaveChanges();
        }
    }
}
