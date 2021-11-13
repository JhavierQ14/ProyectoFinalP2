using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    public class tbl_User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int usuario_id { get; set; }

        public string nombreU  { get; set; }

        public string apellidoU { get; set; }

        public int? telefonoU { get; set; }

        public string correoU { get; set; }

        public string contraU { get; set; }

        public string encryptionU { get; set; }

        public int rolUser_Fk { get; set; }

        public tbl_RolUsuario Tbl_RolUsuario { get; set; }

        public ICollection<tbl_Orden> Tbl_Orden { get; set; }
        public ICollection<tbl_Carrito> Tbl_Carrito { get; set; }
    }
}
