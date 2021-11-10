using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Entidades
{
    public class tbl_Domicilio
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int domicilio_id { get; set; }

        public string ubicacion { get; set; }

        public string referencia { get; set; }

        public int usuario_Fk { get; set;}

        public ICollection<tbl_User> Tbl_User { get; set; }

    }
}
