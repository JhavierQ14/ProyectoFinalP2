using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantOnline.Entidades;

namespace RestaurantOnline.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<tbl_RolUsuario> tbl_RolUsuarios { get; set; }

        public DbSet<tbl_Domicilio> tbl_Domicilio { get; set; }

        public DbSet<tbl_Menu> tbl_Menu { get; set; }

        public DbSet<tbl_MetodoPago> tbl_MetodoPago { get; set; }

        public DbSet<tbl_Documento> tbl_Documento { get; set; }

        public DbSet<tbl_User> tbl_User { get; set; }

        public DbSet<tbl_Producto> tbl_Producto { get; set; }

        public DbSet<tbl_Combo> tbl_Combo { get; set; }

        public DbSet<tbl_DetalleCombo> tbl_DetalleCombo { get; set; }

        public DbSet<tbl_Carrito> tbl_Carrito { get; set; }

        public DbSet<tbl_Orden> tbl_Orden { get; set; }

        public DbSet<tbl_DetalleOrden> tbl_DetalleOrden { get; set; }

       

       

        

        
    }
}
