using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    [Table("tbl_Combo")]
    public class tbl_Combo
    {
        public tbl_Combo()
        {
            this.TblCarritoes = new List<tbl_Carrito>();
            this.TblDetalleComboes = new List<tbl_DetalleCombo>();
            this.TblDetalleOrdens = new List<tbl_DetalleOrden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int combo_id { get; set; }
        [MaxLength]
        public string codCombo { get; set; }
        [MaxLength]
        public string nombreCombo { get; set; }
        public decimal? precioC { get; set; }
        public DateTime? fechaCreacionC { get; set; }
        [MaxLength]
        public string estadoCombo { get; set; }

        public List<tbl_Carrito> TblCarritoes { get; set; }
        public List<tbl_DetalleCombo> TblDetalleComboes { get; set; }
        public List<tbl_DetalleOrden> TblDetalleOrdens { get; set; }
    }

}
