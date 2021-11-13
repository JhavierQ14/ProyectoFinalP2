using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    public class tbl_DetalleOrden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int detalleOden_id { get; set; }

        public int cantidad { get; set; }

        public double totalFinal { get; set; }

        public int orden_FK { get; set; }
        public int combo_FK { get; set; }
        public int producto_Fk { get; set; }

        public tbl_Orden Tbl_Orden { get; set; }

        public tbl_Combo Tbl_Combo { get; set; }
        public tbl_Producto Tbl_Producto { get; set; }

    }
}
