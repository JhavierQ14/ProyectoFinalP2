using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    [Table("tbl_Menu")]
    public class tbl_Menu
    {
        public tbl_Menu()
        {
            this.TblProductoes = new List<tbl_Producto>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int menu_id { get; set; }
        [MaxLength]
        public string nombreMenu { get; set; }

        public List<tbl_Producto> TblProductoes { get; set; }
    }

}
