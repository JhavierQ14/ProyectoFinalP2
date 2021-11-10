using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Entidades
{
    public class tbl_Carrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int carrito_id { get; set; }

        public int cantidadP { get; set; }

        public double totalP { get; set; }

        public int usuario_FK { get; set; }
        public int combo_FK { get; set; }
        public int producto_Fk { get; set; }

        public tbl_User Tbl_User { get; set; }
        public tbl_Combo Tbl_Combo { get; set; }
        public tbl_Producto Tbl_Producto { get; set; }
    }
}
