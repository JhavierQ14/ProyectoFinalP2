using FastFoodRestaurant.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Service
{
    public interface IOrden
    {
        void Insert(tbl_Orden orden);
        void Delete(tbl_Orden orden);
        void Update(tbl_Orden orden);

        ICollection<tbl_Orden> Orden();
    }
}
