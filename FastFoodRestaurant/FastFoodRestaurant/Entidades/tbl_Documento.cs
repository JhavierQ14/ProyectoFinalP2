using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Entidades
{
    public class tbl_Documento
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int documento_id { get; set; }

        public string nombreDocumento { get; set; }



        public ICollection<tbl_Orden> tbl_Orden { get; set; }


    }
}
