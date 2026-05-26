using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryTesisVentas
{
    public class Producto
    {
        // Estos nombres deben ser IGUALES a los de tu base de datos
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }

        // Esta es la que usas para ordenar en el ComboBox
        public DateTime FechaVencimiento { get; set; }

        
    }

}
