using RestaurantOnline.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Service
{
    public interface ICarrito
    {
        void Insert(tbl_Carrito carrito);
        void Delete(tbl_Carrito carrito);
        void Update(tbl_Carrito carrito);

        ICollection<tbl_Carrito> carrito();
    }
}
