using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Repository
{
    public class OrdenRepository : IOrden
    {
        private ApplicationDbContext app;

        public OrdenRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Delete(tbl_Orden orden)
        {
            app.tbl_Orden.Remove(orden);
        }

        public void Insert(tbl_Orden orden)
        {
            app.Add(orden);
            app.SaveChanges();
        }

        public List<tbl_Orden> LastOfOrder()
        {
            return app.tbl_Orden.ToList();
        }

        public ICollection<tbl_Orden> Orden()
        {
            return app.tbl_Orden.ToList();
        }

        public void Update(tbl_Orden orden)
        {
            app.Update(orden);
            app.SaveChanges();
        }
    }
}
