using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantOnline.Entidades;

namespace RestaurantOnline.Models.ViewModels
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            Menus = new List<tbl_Menu>();

        }

        public List<tbl_Menu> Menus { get; set; }
    }
}
