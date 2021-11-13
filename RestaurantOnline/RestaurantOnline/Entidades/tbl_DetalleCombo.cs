using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    public class tbl_DetalleCombo
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int detalleCombo_id { get; set; }

        public string descripcion { get; set; }

        public int  cantidadP { get; set; }

        public int producto_Fk { get; set; }

        public int combo_FK { get; set; }

        public tbl_Producto Tbl_Producto { get; set; }
        public tbl_Combo Tbl_Combo { get; set; }



    }
}
