using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Models.ViewModels
{
    public class LogInViewModels
    {


        //[Display(Name = "correoU")]
        //[Required(ErrorMessage = "Campo requerido")]
        //[EmailAddress(ErrorMessage = "Debe ingresar un correo")]
        //public string correoUser { get; set; }


        //[Display(Name = "contraU")]
        //[Required(ErrorMessage = "Campo requerido")]
        //public string contraUser { get; set; }

        /***************************************************************************************************************************************/
        [Display(Name = "nombreU")]
        [Required(ErrorMessage = "Campo requerido")]
        public string nombreU { get; set; }

        [Display(Name = "apellidoU")]
        [Required(ErrorMessage = "Campo requerido")]
        public string apellidoU { get; set; }

        public int? telefonoU { get; set; }

        [Display(Name = "correoU")]
        [Required(ErrorMessage = "Campo requerido")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo")]
        public string correoU { get; set; }

        [Display(Name = "contraU")]
        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(8, ErrorMessage = "Escriba al menos 8 caracteres.")]
        [MaxLength(50, ErrorMessage = "Escriba un máximo de 50 caracteres.")]
        public string contraU { get; set; }

        public string encryptionU { get; set; }

        public int rolUser_Fk { get; set; }
    }
}
