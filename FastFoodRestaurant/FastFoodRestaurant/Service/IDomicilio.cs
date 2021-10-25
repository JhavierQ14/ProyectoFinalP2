using FastFoodRestaurant.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Service
{
    public interface IDomicilio
    {
        void Insert(tbl_Domicilio domicilio);
        void Delete(tbl_Domicilio domicilio);
        void Update(tbl_Domicilio domicilio);

        ICollection<tbl_Domicilio> Domicilios();
    }
}
