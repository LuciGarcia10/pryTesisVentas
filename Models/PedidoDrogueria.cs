using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryTesisVentas.Models
{
    // 1. Esta clase vive por sí sola (representa una fila del pedido)
    public class ItemPedido
    {
        public string CodigoBarra { get; set; }
        public int Cantidad { get; set; }
    }

    // 2. Esta clase también vive por sí sola (representa el pedido completo)
    public class PedidoDrogueria
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public List<ItemPedido> Productos { get; set; }

        // Ahora el constructor no dará error porque no hay otra clase envolviéndola
        public PedidoDrogueria()
        {
            Productos = new List<ItemPedido>();
        }
    }
}
