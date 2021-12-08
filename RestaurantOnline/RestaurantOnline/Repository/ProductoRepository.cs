using Microsoft.EntityFrameworkCore;
using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Models.ViewModels;
using RestaurantOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Repository
{
    public class ProductoRepository : IProducto
    {
        private ApplicationDbContext app;

        public ProductoRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Delete(tbl_Producto producto)
        {
            app.tbl_Producto.Remove(producto);
        }

        public void Insert(tbl_Producto producto)
        {
            app.Add(producto);
            app.SaveChanges();
        }

        public List<tbl_Producto> ListofP()
        {
            var union = app.tbl_Producto.Include(x => x.TblMenu).ToList();
            return union;
        }


        public List<tbl_Producto> ListVista()
        {
            var ProductoList = app.tbl_Producto.Where(x => x.estadoProducto == "activo").ToList();
            return ProductoList;
        }

        public void Update(tbl_Producto producto)
        {
            app.Update(producto);
            app.SaveChanges();
        }
    }
}
