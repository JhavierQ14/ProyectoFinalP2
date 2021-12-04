using RestaurantOnline.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Service
{
    public interface IDomicilio
    {
        void Insert(tbl_Domicilio domicilio);
        void Delete(tbl_Domicilio domicilio);
        void Update(tbl_Domicilio domicilio);

        List<tbl_Domicilio> Domicilios();
    }
}
