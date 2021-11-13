using RestaurantOnline.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Service
{
    public interface ICombo
    {
        void Insert(tbl_Combo combo);
        void Delete(tbl_Combo combo);
        void Update(tbl_Combo combo);

        ICollection<tbl_Combo> Combo();
    }
}
