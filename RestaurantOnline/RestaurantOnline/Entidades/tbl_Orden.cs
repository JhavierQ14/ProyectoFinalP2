using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    public class tbl_Orden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int orden_id { get; set; }

        public string codOrden { get; set; }

        public DateTime fechaOrden { get; set; }

        public string estadoOrden { get; set; }


        public int user_FK { get; set; }
        public int metodoPago_FK { get; set; }
        public int documento_Fk { get; set; }

        public tbl_User Tbl_User { get; set; }
        public tbl_MetodoPago Tbl_MetodoPago { get; set; }
        public tbl_Documento Tbl_Documento { get; set; }

        public IEnumerable<tbl_DetalleOrden> Tbl_DetalleOrdens { get; set; }


    }
}
