using FastFoodRestaurant.Data;
using FastFoodRestaurant.Entidades;
using FastFoodRestaurant.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Repository
{
    public class RolUsuarioRepository : IRolUsuario
    {
        private ApplicationDbContext app;

        public RolUsuarioRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Delete(tbl_RolUsuario rolUsuario)
        {
            app.tbl_RolUsuarios.Remove(rolUsuario);
        }

        public void Insert(tbl_RolUsuario rolUsuario)
        {
            app.Add(rolUsuario);
            app.SaveChanges();
        }

        public ICollection<tbl_RolUsuario> rolUsuario()
        {
            return app.tbl_RolUsuarios.ToList();
        }

        public void Update(tbl_RolUsuario rolUsuario)
        {
            app.Update(rolUsuario);
            app.SaveChanges();
        }
    }
}
