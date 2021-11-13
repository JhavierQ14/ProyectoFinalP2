using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Repository
{
    public class DomicilioRepository : IDomicilio
    {
        private ApplicationDbContext app;

        public DomicilioRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Delete(tbl_Domicilio domicilio)
        {
            app.tbl_Domicilio.Remove(domicilio);
        }

        public ICollection<tbl_Domicilio> Domicilios()
        {
            return app.tbl_Domicilio.ToList();
        }

        public void Insert(tbl_Domicilio domicilio)
        {
            app.Add(domicilio);
            app.SaveChanges();
        }

        public void Update(tbl_Domicilio domicilio)
        {
            app.Update(domicilio);
            app.SaveChanges();
        }
    }
}
