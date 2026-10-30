using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTesisVentas
{
    public class clsEmailProveedor
    {
        public static bool EnviarYRegistrarNotificacion(int idPedido, int idProveedor, string nombreProveedor, string contenidoMensaje, string remitenteEmail, string emailDestino)
        {
            //  Enviar el correo vía SMTP
            bool enviado = false;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(remitenteEmail, "DigitalFarma - Compras");
                    mail.To.Add(emailDestino);
                    mail.Subject = $"Nuevo Pedido N° {idPedido} - DigitalFarma";
                    mail.Body = contenidoMensaje;
                    mail.IsBodyHtml = false;

                    // Configuración SMTP (ejemplo con Gmail; si usan otro servidor, ajustar host y puerto)
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("tucorreo@gmail.com", "tu_contraseña_o_token_app");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        enviado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo enviar el email al proveedor: " + ex.Message, "Aviso de Envío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Continúa para registrarlo en la BD si se desea
            }

            // Registrar en la tabla MensajesProveedores
            string queryInsert = @"INSERT INTO MensajesProveedores (contenido, fecha, remitente, idPedido, idProveedor)
                                   VALUES (@Contenido, @Fecha, @Remitente, @IdPedido, @IdProveedor)";

            try
            {
                using (SqlConnection conexion = new SqlConnection(clsConsultas.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand(queryInsert, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Contenido", contenidoMensaje);
                        cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Remitente", remitenteEmail);
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                        cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el mensaje en la base de datos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
