using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Entidades
{
    [Table("tbl_Producto")]
    public class tbl_Producto
    {
        public tbl_Producto()
        {
            this.TblCarritoes = new List<tbl_Carrito>();
            this.TblDetalleOrdens = new List<tbl_DetalleOrden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int producto_id { get; set; }
        [MaxLength]
        public string codProducto { get; set; }
        [MaxLength]
        public string nombreProducto { get; set; }
        public decimal? precioP { get; set; }
        public DateTime? fechaCreacionP { get; set; }
        [MaxLength]
        public string estadoProducto { get; set; }
        [MaxLength]
        public string imageP { get; set; }
        public int menu_Fk { get; set; }

        [ForeignKey("menu_Fk")]
        public tbl_Menu TblMenu { get; set; }
        public List<tbl_Carrito> TblCarritoes { get; set; }
        public List<tbl_DetalleOrden> TblDetalleOrdens { get; set; }
    }
}
