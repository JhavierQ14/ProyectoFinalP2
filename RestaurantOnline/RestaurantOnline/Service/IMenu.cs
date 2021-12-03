using RestaurantOnline.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Service
{
    public interface IMenu
    {
        void Insert(tbl_Menu menu);
        void Delete(tbl_Menu menu);
        void Update(tbl_Menu menu);

        List<tbl_Menu> ListMenu();
    }
}
