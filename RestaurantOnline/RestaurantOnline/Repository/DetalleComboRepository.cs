using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Repository
{
    public class DetalleComboRepository : IDetalleCombo
    {
        private ApplicationDbContext app;

        public DetalleComboRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Delete(tbl_DetalleCombo detalleCombo)
        {
            app.tbl_DetalleCombo.Remove(detalleCombo);
        }

        public ICollection<tbl_DetalleCombo> detalleCombo()
        {
            return app.tbl_DetalleCombo.ToList();
        }

        public void Insert(tbl_DetalleCombo detalleCombo)
        {
            app.Add(detalleCombo);
            app.SaveChanges();
        }

        public void Update(tbl_DetalleCombo detalleCombo)
        {
            app.Update(detalleCombo);
            app.SaveChanges();
        }
    }
}
