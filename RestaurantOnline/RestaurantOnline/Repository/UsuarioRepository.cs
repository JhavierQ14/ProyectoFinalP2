using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Repository
{
    public class UsuarioRepository : IUsuario
    {
        private ApplicationDbContext app;

        public UsuarioRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Delete(tbl_User user)
        {
            app.tbl_User.Remove(user);
        }

        public void Insert(tbl_User user)
        {
            app.Add(user);
            app.SaveChanges();
        }

        public ICollection<tbl_User> ListarUsuario()
        {
            return app.tbl_User.ToList();
        }

        public void Update(tbl_User user)
        {
            app.Update(user);
            app.SaveChanges();
        }
    }
}
