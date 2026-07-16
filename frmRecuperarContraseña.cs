using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTesisVentas
{
    public partial class frmRecuperarContraseña : Form
    {
        // Cambiar a nuestra base "BDDigitalFarma"
        private string cadenaConexion = "Server=localhost; Database=BDDigitalFarma; Integrated Security=True";
        public frmRecuperarContraseña()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string mailIngresado = txtMail.Text.Trim();

            // 1. Validar que no esté vacío
            if (string.IsNullOrEmpty(mailIngresado))
            {
                MessageBox.Show("Por favor, ingrese su correo electrónico.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Conectarse y verificar contra tu tabla Usuarios
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // Buscamos en la columna 'mail' de tu tabla real 'Usuarios'
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE mail = @Mail";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Mail", mailIngresado);

                        int existe = (int)comando.ExecuteScalar();

                        if (existe > 0)
                        {
                            // ¡El mail existe en BDDigitalFarma!
                            MessageBox.Show("Se ha enviado un enlace de recuperación a: " + mailIngresado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Cerramos y volvemos al Login
                        }
                        else
                        {
                            // El mail no está registrado
                            MessageBox.Show("El correo ingresado no se encuentra registrado en el sistema.", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
