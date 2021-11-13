using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    public class tbl_Menu
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int menu_id { get; set; }

        public string nombreMenu { get; set; }

        public ICollection<tbl_Producto> Tbl_Producto { get; set; }

    }
}
