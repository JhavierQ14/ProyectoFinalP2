using RestaurantOnline.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Service
{
    public interface IDocumento
    {
        void Insert(tbl_Documento documento);
        void Delete(tbl_Documento documento);
        void Update(tbl_Documento documento);

        ICollection<tbl_Documento> documento();
    }
}
