using FastFoodRestaurant.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Service
{
    public interface IDetalleOrden
    {
        void Insert(tbl_DetalleOrden detalleOrden);
        void Delete(tbl_DetalleOrden detalleOrden);
        void Update(tbl_DetalleOrden detalleOrden);

        ICollection<tbl_DetalleOrden> detalleOrden();
    }
}
