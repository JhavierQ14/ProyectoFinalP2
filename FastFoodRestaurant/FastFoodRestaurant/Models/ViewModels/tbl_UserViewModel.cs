using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodRestaurant.Models.ViewModels
{
    public class tbl_UserViewModel
    {

        public int usuario_id { get; set; }

        public string nombreU { get; set; }

        public string apellidoU { get; set; }

        [Required(ErrorMessage ="Escriba su correo")]
        public string correoU { get; set; }

        [Required(ErrorMessage = "Escriba su password")]
        public string contraU { get; set; }

        public int? telefonoU { get; set; }

        public int rolUser_Fk { get; set; }
    }
}
