using RestaurantOnline.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Service
{
    public interface IMetodoPago
    {
        void Insert(tbl_MetodoPago metodoPago);
        void Delete(tbl_MetodoPago metodoPago);
        void Update(tbl_MetodoPago metodoPago);

        ICollection<tbl_MetodoPago> metodoPago();
    }
}
