using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    public class tbl_Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int producto_id { get; set; }

        public string codProducto { get; set; }

        public string nombreProducto { get; set; }

        public string precioP { get; set; }

        public DateTime fechaCreacionP  { get; set; }

        public string estadoProducto { get; set; }

        public int menu_Fk { get; set; }

        public tbl_Menu Tbl_Menu { get; set; }

        public IEnumerable<tbl_DetalleCombo> Tbl_DetalleCombos { get; set; }
        public IEnumerable<tbl_Carrito> Tbl_Carritos { get; set; }
        public IEnumerable<tbl_DetalleOrden> Tbl_DetalleOrdens { get; set; }




    }
}
