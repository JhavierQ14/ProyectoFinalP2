using FastFoodRestaurant.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Service
{
    public interface IDetalleCombo
    {
        void Insert(tbl_DetalleCombo detalleCombo);
        void Delete(tbl_DetalleCombo detalleCombo);
        void Update(tbl_DetalleCombo detalleCombo);

        ICollection<tbl_DetalleCombo> detalleCombo();
    }
}
