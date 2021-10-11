using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Entidades
{
    public class tbl_Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int producto_id { get; set; }

        public string codProducto { get; set; }

        public string nombreProducto { get; set; }

        public decimal precioP { get; set; }

        public DateTime fechaCreacionP  { get; set; }

        public string estadoProducto { get; set; }

        public int menu_Fk { get; set; }
      


    }
}
