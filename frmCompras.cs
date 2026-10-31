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
    public partial class frmCompras : Form
    {
        private List<clsDetallePedido> listaLocal;
        public frmCompras(List<clsDetallePedido> comprasRecibidas)
        {
            InitializeComponent();

            this.listaLocal = comprasRecibidas;

        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            txtFechaEntrega.Text = DateTime.Now.AddDays(1).ToString("dd/MM/yy");
        }
        private void CalcularTotalesCompras()
        {
            if (listaLocal == null) return;

            int totalCantidad = 0;
            decimal totalDinero = 0;

            foreach (clsDetallePedido detalle in listaLocal)
            {
                totalCantidad += detalle.Cantidad;
                totalDinero += (detalle.Cantidad * detalle.Precio);
            }

            txtCantProd.Text = totalCantidad.ToString();
            txtPrecioTotal.Text = totalDinero.ToString("C0");
        }
        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas cancelar la compra? Se perderán los datos ingresados.", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private async void btnPedir_Click(object sender, EventArgs e)
        {
            // Validar que hayan puesto una dirección
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, ingresá una dirección de entrega.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listaLocal == null || listaLocal.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación del usuario
            DialogResult resultado = MessageBox.Show("¿Confirmás la realización de este pedido?", "Confirmar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                btnPedir.Enabled = false;

                try
                {
                    string cadenaConexion = clsConsultas.cadena;
                    int idPedidoGenerado = 0;
                    string proveedorDestino = listaLocal[0].Proveedor;
                    decimal totalPedido = listaLocal.Sum(x => x.Cantidad * x.Precio);

                    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                    {
                        await conexion.OpenAsync();

                        using (SqlTransaction transaccion = conexion.BeginTransaction())
                        {
                            try
                            {
                                // Insertar pedido y recuperar ID generado
                                string queryPedido = @"
                    INSERT INTO Pedidos (FechaPedido, DireccionEntrega, Total, IdEstado, IdProveedor) 
                    VALUES (
                        @fecha, 
                        @direccion, 
                        @total, 
                        1, 
                        (SELECT TOP 1 IdProveedor FROM Proveedores WHERE RazonSocial LIKE '%' + @proveedor + '%')
                    ); 
                    SELECT SCOPE_IDENTITY();";

                                using (SqlCommand cmdPedido = new SqlCommand(queryPedido, conexion, transaccion))
                                {
                                    cmdPedido.Parameters.AddWithValue("@fecha", DateTime.Now);
                                    cmdPedido.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                                    cmdPedido.Parameters.AddWithValue("@total", totalPedido);
                                    cmdPedido.Parameters.AddWithValue("@proveedor", string.IsNullOrEmpty(proveedorDestino) ? (object)DBNull.Value : proveedorDestino.Trim());

                                    object res = await cmdPedido.ExecuteScalarAsync();
                                    idPedidoGenerado = Convert.ToInt32(res);
                                }

                                // Insertar detalle de productos
                                string queryDetalle = @"INSERT INTO DetallePedido (IdPedido, IdProducto, Cantidad, PrecioCosto) 
                                       VALUES (@idPedido, @idProducto, @cantidad, @precio);";

                                foreach (clsDetallePedido detalle in listaLocal)
                                {
                                    using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion))
                                    {
                                        cmdDetalle.Parameters.AddWithValue("@idPedido", idPedidoGenerado);
                                        cmdDetalle.Parameters.AddWithValue("@idProducto", detalle.IdProducto > 0 ? detalle.IdProducto : 1);
                                        cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                                        cmdDetalle.Parameters.AddWithValue("@precio", detalle.Precio);

                                        await cmdDetalle.ExecuteNonQueryAsync();
                                    }
                                }

                                // Enviar y registrar mensaje si el proveedor es Belleza
                                if (!string.IsNullOrEmpty(proveedorDestino) && proveedorDestino.Trim().Equals("Belleza", StringComparison.OrdinalIgnoreCase))
                                {
                                    // Obtener idProveedor y mail de la tabla Proveedores
                                    int idProveedor = 0;
                                    string emailDestino = "pedidos@belleza.com";

                                    using (SqlCommand cmdBuscarProv = new SqlCommand("SELECT TOP 1 IdProveedor, ISNULL(Email, 'pedidos@belleza.com') AS Email FROM Proveedores WHERE RazonSocial LIKE '%Belleza%'", conexion, transaccion))
                                    {
                                        using (SqlDataReader lectorProv = await cmdBuscarProv.ExecuteReaderAsync())
                                        {
                                            if (await lectorProv.ReadAsync())
                                            {
                                                idProveedor = Convert.ToInt32(lectorProv["IdProveedor"]);
                                                emailDestino = lectorProv["Email"].ToString();
                                            }
                                        }
                                    }

                                    // Construir contenido del mensaje
                                    StringBuilder sbContenido = new StringBuilder();
                                    sbContenido.AppendLine($"Orden de Compra N° {idPedidoGenerado} - DigitalFarma");
                                    sbContenido.AppendLine($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}");
                                    sbContenido.AppendLine($"Dirección de Entrega: {txtDireccion.Text.Trim()}");
                                    sbContenido.AppendLine("Productos solicitados:");

                                    foreach (clsDetallePedido item in listaLocal)
                                    {
                                        sbContenido.AppendLine($"• Cantidad: {item.Cantidad} | ID/Prod: {item.IdProducto} | Precio Unit: ${item.Precio}");
                                    }
                                    sbContenido.AppendLine($"Total: ${totalPedido}");

                                    string remitente = "farmaciafunesgarcia@gmail.com";
                                    string contenidoFinal = sbContenido.ToString();

                                    // Registrar en tu tabla Mensaje usando sus columnas reales: Contenido, FechaRemitente, Destinatario, IdPedido, IdProveedor, Estado
                                    string queryMensaje = @"INSERT INTO Mensaje (Contenido, FechaRemitente, Destinatario, IdPedido, IdProveedor, Estado) 
                                                   VALUES (@Contenido, @FechaRemitente, @Destinatario, @IdPedido, @IdProveedor, @Estado);";

                                    using (SqlCommand cmdMsg = new SqlCommand(queryMensaje, conexion, transaccion))
                                    {
                                        cmdMsg.Parameters.AddWithValue("@Contenido", contenidoFinal);
                                        cmdMsg.Parameters.AddWithValue("@FechaRemitente", DateTime.Now);
                                        cmdMsg.Parameters.AddWithValue("@Destinatario", emailDestino);
                                        cmdMsg.Parameters.AddWithValue("@IdPedido", idPedidoGenerado);
                                        cmdMsg.Parameters.AddWithValue("@IdProveedor", idProveedor);
                                        cmdMsg.Parameters.AddWithValue("@Estado", "Enviado");

                                        await cmdMsg.ExecuteNonQueryAsync();
                                    }

                                    // Envío SMTP en segundo plano
                                    _ = Task.Run(() =>
                                    {
                                        try
                                        {
                                            using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
                                            {
                                                mail.From = new System.Net.Mail.MailAddress(remitente, "DigitalFarma - Compras");
                                                mail.To.Add(emailDestino);
                                                mail.Subject = $"Nuevo Pedido N° {idPedidoGenerado} - Proveedor Belleza";
                                                mail.Body = contenidoFinal;
                                                mail.IsBodyHtml = false;

                                                using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                                                {
                                                    smtp.Credentials = new System.Net.NetworkCredential("tu_correo@gmail.com", "tu_contraseña_de_aplicacion");
                                                    smtp.EnableSsl = true;
                                                    smtp.Send(mail);
                                                }
                                            }
                                        }
                                        catch
                                        {
                                            // El mensaje ya quedó registrado en la tabla Mensaje de la base de datos
                                        }
                                    });
                                }

                                transaccion.Commit();
                            }
                            catch (Exception)
                            {
                                transaccion.Rollback();
                                throw;
                            }
                        }
                    }

                    try
                    {
                        await clsAutomatizacionDrogueria.CargarPedidoEnWeb(proveedorDestino, listaLocal);
                    }
                    catch (Exception exBot)
                    {
                        MessageBox.Show($"El pedido N° {idPedidoGenerado} se guardó en el sistema, pero ocurrió una advertencia en la web: {exBot.Message}",
                                        "Aviso de Automatización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    frmPedidos formularioPadre = (frmPedidos)Application.OpenForms["frmPedidos"];
                    if (formularioPadre != null)
                    {
                        clsPedido nuevoPedido = new clsPedido
                        {
                            IdPedido = idPedidoGenerado,
                            Fecha = DateTime.Now,
                            Proveedor = proveedorDestino,
                            Estado = "Pendiente",
                            Detalles = new List<clsDetallePedido>(this.listaLocal),
                            Total = totalPedido
                        };

                        formularioPadre.listaPedidos.Add(nuevoPedido);
                        formularioPadre.ActualizarGrilla(formularioPadre.listaPedidos);
                    }

                    MessageBox.Show($"¡Pedido realizado con éxito! Orden N° {idPedidoGenerado}" +
                                    (proveedorDestino.Equals("Belleza", StringComparison.OrdinalIgnoreCase) ? "\nSe ha registrado el mensaje y emitido la notificación al proveedor Belleza." : " y enviado a la droguería."),
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    listaLocal.Clear();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al guardar el pedido en la base de datos: " + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    btnPedir.Enabled = true;
                }
            }
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCompras_Shown(object sender, EventArgs e)
        {
            // Suspendemos el layout temporalmente para que el DataGridView no redibuje fila por fila
            dgvCompras.SuspendLayout();

            dgvCompras.DataSource = null;
            dgvCompras.DataSource = listaLocal;

            // Ocultar si no querés que se muestren
            if (dgvCompras.Columns["IdProducto"] != null)
                dgvCompras.Columns["IdProducto"].Visible = false;

            dgvCompras.ResumeLayout();

            // Calculamos totales una sola vez
            CalcularTotalesCompras();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
