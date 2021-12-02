using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    [Table("tbl_Orden")]
    public class tbl_Orden
    {
        public tbl_Orden()
        {
            this.TblDetalleOrdens = new List<tbl_DetalleOrden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orden_id { get; set; }
        [MaxLength]
        public string codOrden { get; set; }
        public DateTime? fechaOrden { get; set; }
        [MaxLength]
        public string estadoOrden { get; set; }
        public int user_FK { get; set; }
        public int metodoPago_FK { get; set; }
        public int documento_Fk { get; set; }

        [ForeignKey("user_FK")]
        public tbl_User TblUser { get; set; }

        [ForeignKey("metodoPago_Fk")]
        public tbl_MetodoPago TblMetodoPago { get; set; }

        [ForeignKey("documento_Fk")]
        public tbl_Documento TblDocumento { get; set; }

        public List<tbl_DetalleOrden> TblDetalleOrdens { get; set; }
    }
}
