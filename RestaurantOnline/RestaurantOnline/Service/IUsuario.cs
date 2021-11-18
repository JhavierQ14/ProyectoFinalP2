using RestaurantOnline.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Service
{
    
    public interface IUsuario
    {
        void Insert(tbl_User user);
        void Delete(tbl_User user);
        void Update(tbl_User user);

        List<tbl_User> ListarUsuario();

        //List<tbl_User> ListEmail(string emailUser);
    }
}
