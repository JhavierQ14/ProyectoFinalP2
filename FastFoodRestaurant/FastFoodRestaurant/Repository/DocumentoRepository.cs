using FastFoodRestaurant.Data;
using FastFoodRestaurant.Entidades;
using FastFoodRestaurant.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Repository
{
    public class DocumentoRepository : IDocumento
    {
        private ApplicationDbContext app;

        public DocumentoRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Delete(tbl_Documento documento)
        {
            app.tbl_Documento.Remove(documento);
        }

        public ICollection<tbl_Documento> documento()
        {
            return app.tbl_Documento.ToList();
        }

        public void Insert(tbl_Documento documento)
        {
            app.Add(documento);
            app.SaveChanges();
        }

        public void Update(tbl_Documento documento)
        {
            app.Add(documento);
            app.SaveChanges();
        }
    }
}
