using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    [Table("tbl_User")]
    public class tbl_User
    {
        public tbl_User()
        {
            this.TblCarritoes = new List<tbl_Carrito>();
            this.TblDomicilios = new List<tbl_Domicilio>();
            this.TblOrdens = new List<tbl_Orden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int usuario_id { get; set; }
        //[MaxLength]
        public string nombreU { get; set; }
        //[MaxLength]
        public string apellidoU { get; set; }
        public int? telefonoU { get; set; }
        //[MaxLength(100)]
        public string correoU { get; set; }
        //[MaxLength]
        public string contraU { get; set; }
        //[MaxLength]
        public string encryptionU { get; set; }

        public int? rolUser_Fk { get; set; }

        [ForeignKey("rolUser_Fk")]
        public tbl_RolUsuario TblRolUsuario { get; set; }

        public List<tbl_Carrito> TblCarritoes { get; set; }
        public List<tbl_Domicilio> TblDomicilios { get; set; }
        public List<tbl_Orden> TblOrdens { get; set; }
    }
}
