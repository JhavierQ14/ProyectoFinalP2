using FastFoodRestaurant.Data;
using FastFoodRestaurant.Entidades;
using FastFoodRestaurant.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Repository
{
    public class ComboRepository : ICombo
    {
        private ApplicationDbContext app;

        public ComboRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public ICollection<tbl_Combo> Combo()
        {
            return app.tbl_Combo.ToList();
        }

        public void Delete(tbl_Combo combo)
        {
            app.tbl_Combo.Remove(combo);
        }

        public void Insert(tbl_Combo combo)
        {
            app.Add(combo);
            app.SaveChanges();
        }

        public void Update(tbl_Combo combo)
        {
            app.Update(combo);
            app.SaveChanges();
        }
    }
}
