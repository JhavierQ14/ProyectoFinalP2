using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    public class tbl_Combo
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int menu_id { get; set; }

        public string codCombo { get; set; }

        public string nombreCombo { get; set; }

        public double precioC { get; set; }

        public DateTime fechaCreacionC { get; set; }

        public string estadoCombo { get; set; }

        public IEnumerable<tbl_DetalleCombo> Tbl_DetalleCombos { get; set; }

        public IEnumerable<tbl_Carrito> Tbl_Carritos { get; set; }

        public IEnumerable<tbl_DetalleOrden> Tbl_DetalleOrdens { get; set; }

    }
}
