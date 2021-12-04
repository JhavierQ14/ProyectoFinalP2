using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOnline.Models.ViewModels
{
    public class VentaViewModel
    {
        public string estadoOrden { get; set; }

        public int metodoPago_FK { get; set; }
        public int documento_Fk { get; set; }

        public List<DetalleViewModel> Detalle { get; set; }
    }

    public class DetalleViewModel
    {

    }
}
