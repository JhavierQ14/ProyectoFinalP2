using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    [Table("tbl_DetalleOrden")]
    public class tbl_DetalleOrden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int detalleOden_id { get; set; }
        public int? cantidad { get; set; }
        public decimal? totalFinal { get; set; }
        public int orden_FK { get; set; }
        public int combo_FK { get; set; }
        public int producto_Fk { get; set; }

        [ForeignKey("orden_FK")]
        public tbl_Orden TblOrden { get; set; }

        [ForeignKey("combo_FK")]
        public tbl_Combo TblCombo { get; set; }

        [ForeignKey("producto_Fk")]
        public tbl_Producto TblProducto { get; set; }
    }
}
