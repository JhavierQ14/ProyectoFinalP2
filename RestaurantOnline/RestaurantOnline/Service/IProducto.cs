using RestaurantOnline.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Service
{
    public interface IProducto
    {
        void Insert(tbl_Producto producto);
        void Delete(tbl_Producto producto);
        void Update(tbl_Producto producto);

        ICollection<tbl_Producto> producto();
    }
}
