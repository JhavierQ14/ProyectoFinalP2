using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Models.ViewModels
{
    public class LogInViewModels
    {
        [Key]
        public int usuario_id { get; set; }

        [Required(ErrorMessage = "Escriba su nombre.")]
        public string nombreU { get; set; }

        [Required(ErrorMessage = "Escriba su apellido.")]
        public string apellidoU { get; set; }

        public int? telefonoU { get; set; }

        [Required(ErrorMessage = "Escriba el nombre de usuario.")]
        public string correoU { get; set; }

        [Required(ErrorMessage = "Escriba su clave")]
        [MinLength(8, ErrorMessage = "Escriba al menos 8 caracteres.")]
        [MaxLength(50, ErrorMessage = "Escriba un máximo de 50 caracteres.")]
        public string contraU { get; set; }

        public string encryptionU { get; set; }

        public int rolUser_Fk { get; set; }
    }
}
