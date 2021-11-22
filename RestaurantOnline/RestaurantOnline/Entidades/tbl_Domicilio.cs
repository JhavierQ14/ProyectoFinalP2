using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    [Table("tbl_Domicilio")]
    public class tbl_Domicilio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int domicilio_id { get; set; }
        [MaxLength]
        public string ubicacion { get; set; }
        [MaxLength]
        public string referencia { get; set; }
        public int usuario_Fk { get; set; }

        [ForeignKey("usuario_Fk")]
        public tbl_User TblUser { get; set; }
    }

}
