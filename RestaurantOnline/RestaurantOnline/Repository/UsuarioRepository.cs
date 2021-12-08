using Microsoft.EntityFrameworkCore;
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

        public List<tbl_User> ListarUsuario()
        {
            var u = app.tbl_User.Include(x => x.TblRolUsuario)/*.Where(x => x.TblRolUsuario.nombreRol == "Administrador")*/.ToList();
            return u;
        }

        //public List<tbl_User> ListEmail(string emailUser)
        //{
        //    var emailU = app.tbl_User.Where(x => x.correoU == emailUser).SingleOrDefault();

        //    return emailU;
        //}

        public void Update(tbl_User user)
        {
            app.Update(user);
            app.SaveChanges();
        }
    }
}
