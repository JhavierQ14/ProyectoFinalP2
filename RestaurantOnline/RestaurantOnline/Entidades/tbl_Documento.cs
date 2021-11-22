using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    [Table("tbl_Documento")]
    public class tbl_Documento
    {
        public tbl_Documento()
        {
            this.TblOrdens = new List<tbl_Orden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int documento_id { get; set; }
        [MaxLength]
        public string nombreDocumento { get; set; }

        public List<tbl_Orden> TblOrdens { get; set; }
    }
}
