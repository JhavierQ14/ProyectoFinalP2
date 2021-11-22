using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    [Table("tbl_DetalleCombo")]
    public class tbl_DetalleCombo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int detalleCombo_id { get; set; }
        [MaxLength]
        public string descripcion { get; set; }
        public int? cantidadP { get; set; }
        public int producto_Fk { get; set; }
        public int combo_FK { get; set; }

        [ForeignKey("producto_Fk")]
        public tbl_Producto TblProducto { get; set; }

        [ForeignKey("combo_FK")]
        public tbl_Combo TblCombo { get; set; }
    }
}
