using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    [Table("tbl_Carrito")]
    public class tbl_Carrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int carrito_id { get; set; }
        public int? cantidadP { get; set; }
        public decimal? totalP { get; set; }
        public int usuario_Fk { get; set; }
        //public int combo_FK { get; set; }
        public int producto_Fk { get; set; }

        [ForeignKey("usuario_Fk")]
        public tbl_User TblUser { get; set; }

        //[ForeignKey("combo_FK")]
        //public tbl_Combo TblCombo { get; set; }

        [ForeignKey("producto_Fk")]
        public tbl_Producto TblProducto { get; set; }
    }
}
