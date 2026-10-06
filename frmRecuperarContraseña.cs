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
using System.Net;      // Necesario para las credenciales de red
using System.Net.Mail; // Necesario para armar y enviar el correo

namespace pryTesisVentas
{
    public partial class frmRecuperarContraseña : Form
    {
        // Cambiar a nuestra base "BDDigitalFarma"
        private string cadenaConexion = clsConsultas.cadena;
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

                    // Traemos la contraseña en vez de solo contar si existe
                    string query = "SELECT contrasenia FROM Usuarios WHERE mail = @Mail";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Mail", mailIngresado);

                        // ExecuteScalar trae la primera columna de la primera fila (la contraseña)
                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
                            // ¡El mail existe! Guardamos la contraseña recuperada de la BD
                            string claveRecuperada = resultado.ToString();

                            // 3. ENVIAR EL CORREO
                            try
                            {
                                MailMessage correo = new MailMessage();
                                correo.From = new MailAddress("admin.digitalfarma@gmail.com");
                                correo.To.Add(mailIngresado);

                                correo.Subject = "Recuperación de contraseña - DigitalFarma";
                                correo.Body = $"Hola. Hemos recibido una solicitud para recuperar tu acceso al sistema de la farmacia.\n\nTu contraseña actual es: {claveRecuperada}\n\nPor favor, guardala en un lugar seguro.";

                                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com");
                                clienteSmtp.Port = 587;
                                clienteSmtp.Credentials = new NetworkCredential("admin.digitalfarma@gmail.com", "hyqg cxue jyrd ctoo");
                                clienteSmtp.EnableSsl = true;

                                clienteSmtp.Send(correo);

                                MessageBox.Show("Se ha enviado tu contraseña al correo: " + mailIngresado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close(); // Cerramos y volvemos al Login
                            }
                            catch (Exception exCorreo)
                            {
                                MessageBox.Show("Hubo un problema al enviar el correo: " + exCorreo.Message, "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            // El mail no está registrado (el resultado del SELECT fue nulo)
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

        private void frmRecuperarContraseña_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
