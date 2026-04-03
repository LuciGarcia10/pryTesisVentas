using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryTesisVentas
{
    public class clsPedido
    {
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }
        public string Estado { get; set; } // Ejemplo: "Pendiente", "Recibido"
        public decimal Total { get; set; }
        public int CantidadDeProductos
        {
            get { return Detalles.Count; }
        }
        // Esta lista opcional es por si querés guardar qué productos tiene adentro el pedido
        public List<clsDetallePedido> Detalles { get; set; } = new List<clsDetallePedido>();
    }
}
