using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Entidades
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


    }
}
