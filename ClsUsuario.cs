using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryTesisVentas
{
    public class ClsUsuario
    {
        // Aquí guardaremos los datos del usuario que inició sesión con éxito
        public static int IdUsuario { get; set; }
        public static string UsuarioLogueado { get; set; }
        public static string EmailLogueado { get; set; }
        public static string RolLogueado { get; set; }
    }
}
