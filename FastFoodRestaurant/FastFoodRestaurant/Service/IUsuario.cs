using FastFoodRestaurant.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Service
{
    
    public interface IUsuario
    {
        void Insert(tbl_User user);
        void Delete(tbl_User user);
        void Update(tbl_User user);

        ICollection<tbl_User> ListarUsuario();
    }
}
