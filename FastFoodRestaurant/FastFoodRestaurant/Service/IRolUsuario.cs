using FastFoodRestaurant.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Service
{
    public interface IRolUsuario
    {
        void Insert(tbl_RolUsuario rolUsuario);
        void Delete(tbl_RolUsuario rolUsuario);
        void Update(tbl_RolUsuario rolUsuario);

        ICollection<tbl_RolUsuario> rolUsuario();
    }
}
