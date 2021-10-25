using FastFoodRestaurant.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Service
{
    public interface IMenu
    {
        void Insert(tbl_Menu menu);
        void Delete(tbl_Menu menu);
        void Update(tbl_Menu menu);

        ICollection<tbl_Menu> Menu();
    }
}
