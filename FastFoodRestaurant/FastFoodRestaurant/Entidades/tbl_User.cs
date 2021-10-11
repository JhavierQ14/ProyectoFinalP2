using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Entidades
{
    public class tbl_User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int usuario_id { get; set; }

        public string nombreU  { get; set; }

        public string apellidoU { get; set; }

        public string correoU { get; set; }

        public string contraU { get; set; }


        public int domicilio_Fk { get; set; }
        public int rolUsuario_Fk { get; set; }


    }
}
