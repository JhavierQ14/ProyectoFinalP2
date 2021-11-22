using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{

    //[Table("tbl_RolUsuario")]
    public class tbl_RolUsuario
    {
        //public tbl_RolUsuario()
        //{
        //    this.TblUsers = new List<tbl_User>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rolUser_id { get; set; }

        public string nombreRol { get; set; }


        //public List<tbl_User> TblUsers  { get; set; }
    }
}
