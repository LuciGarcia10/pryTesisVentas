using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryTesisVentas
{

    public class PreguntaFrecuente
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        // 1. Declaras la lista aquí arriba para que el HTML la vea
        public List<PreguntaFrecuente> ListaFaqs { get; set; }

    }
}
