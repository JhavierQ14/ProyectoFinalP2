using RestaurantOnline.Entidades;
using RestaurantOnline.Models.ViewModels;
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

        List<tbl_Producto> ListofP();
        List<tbl_Producto> ListVista();
    }
}
