using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Entidades
{
    public class tbl_Combo
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int menu_id { get; set; }

        public string codCombo { get; set; }

        public string nombreCombo { get; set; }

        public decimal precioC { get; set; }

        public DateTime fechaCreacionC { get; set; }

        public string estadoCombo { get; set; }

        public int menu_Fk { get; set; }
    }
}
