using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    //[Table("tbl_User")]
    public class tbl_User
    {

        //public tbl_User()
        //{
        //    this.TblCarritoes = new List<tbl_Carrito>();
        //    this.TblDomicilios = new List<tbl_Domicilio>();
        //    this.TblOrdens = new List<tbl_Orden>();
        //}


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int usuario_id { get; set; }

        [Display(Name = "nombreU")]
        [Required(ErrorMessage = "Campo requerido")]
        public string nombreU  { get; set; }

        [Display(Name = "apellidoU")]
        [Required(ErrorMessage = "Campo requerido")]
        public string apellidoU { get; set; }

        public int? telefonoU { get; set; }

        [Display(Name = "correoU")]
        [Required(ErrorMessage = "Campo requerido")]
        [EmailAddress (ErrorMessage ="Debe ingresar un correo")]
        public string correoU { get; set; }

        [Display(Name = "contraU")]
        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(8, ErrorMessage = "Escriba al menos 8 caracteres.")]
        [MaxLength(50, ErrorMessage = "Escriba un máximo de 50 caracteres.")]
        public string contraU { get; set; }

        public string encryptionU { get; set; }

        public int rolUser_Fk { get; set; }

        //public tbl_RolUsuario TblRolUsuario { get; set; }

        //public List<tbl_Carrito> TblCarritoes { get; set; }
        //public List<tbl_Domicilio> TblDomicilios { get; set; }
        //public List<tbl_Orden> TblOrdens { get; set; }
    }
}
