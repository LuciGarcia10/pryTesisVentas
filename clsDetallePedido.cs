using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryTesisVentas
{
    public class clsDetallePedido
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public string Proveedor { get; set; }
    }
}
