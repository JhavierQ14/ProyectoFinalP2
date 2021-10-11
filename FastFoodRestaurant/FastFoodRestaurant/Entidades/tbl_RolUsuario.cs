﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Entidades
{
    public class tbl_RolUsuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int rol_id { get; set; }

        public string nombreRol { get; set; }


        public ICollection<tbl_User> tbl_User  { get; set; }
    }
}
