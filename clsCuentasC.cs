using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryTesisVentas
{
    public class clsCuentasC
    {
        public int NroAfiliado {  get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ObraSocial { get; set; } //Ejemplo: "Apross", "Swiss Medical", etc
        public string Estado { get; set; } // Ejemplo: "Al dia", "Pendiente" o "Vencido"
        public decimal Saldo { get; set; }
        //Acciones??
    }

}
