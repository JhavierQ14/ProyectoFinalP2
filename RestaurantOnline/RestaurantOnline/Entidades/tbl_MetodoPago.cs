using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    [Table("tbl_MetodoPago")]
    public class tbl_MetodoPago
    {
        public tbl_MetodoPago()
        {
            this.TblOrdens = new List<tbl_Orden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int metodoPago_id { get; set; }
        [MaxLength]
        public string nombreMetodo { get; set; }

        public List<tbl_Orden> TblOrdens { get; set; }
    }
}
