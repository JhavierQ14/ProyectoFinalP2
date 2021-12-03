using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Repository
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

        public List<tbl_Menu> ListMenu()
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
