using FastFoodRestaurant.Data;
using FastFoodRestaurant.Entidades;
using FastFoodRestaurant.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Repository
{
    public class MenuRepository : IMenu
    {
        private ApplicationDbContext app;

        public MenuRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Delete(tbl_Menu menu)
        {
            app.tbl_Menu.Remove(menu);
        }

        public void Insert(tbl_Menu menu)
        {
            app.Add(menu);
            app.SaveChanges();
        }

        public ICollection<tbl_Menu> Menu()
        {
            return app.tbl_Menu.ToList();
        }

        public void Update(tbl_Menu menu)
        {
            app.Update(menu);
            app.SaveChanges();
        }
    }
}
