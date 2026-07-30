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
            // 1. Validar que hayan puesto una dirección
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

            // 2. Confirmación del usuario
            DialogResult resultado = MessageBox.Show("¿Confirmás la realización de este pedido?", "Confirmar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                btnPedir.Enabled = false;

                try
                {
                    // Podés usar 'Integrated Security=True' o tu usuario sa si tenés clave configurada
                    string cadenaConexion = "Data Source=DESKTOP-TGRLC0K\\MSSQLSERVER01;Initial Catalog=BDDigitalFarma;Integrated Security=True;TrustServerCertificate=True";
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
                                
                                string queryPedido = @"INSERT INTO Pedidos (FechaPedido, DireccionEntrega, Total, IdEstado) 
                                               VALUES (@fecha, @direccion, @total, 1); 
                                               SELECT SCOPE_IDENTITY();";

                                using (SqlCommand cmdPedido = new SqlCommand(queryPedido, conexion, transaccion))
                                {
                                    cmdPedido.Parameters.AddWithValue("@fecha", DateTime.Now);
                                    cmdPedido.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                                    cmdPedido.Parameters.AddWithValue("@total", totalPedido);

                                    object res = await cmdPedido.ExecuteScalarAsync();
                                    idPedidoGenerado = Convert.ToInt32(res);
                                }

                                string queryDetalle = @"INSERT INTO DetallePedido (IdPedido, IdProducto, Cantidad, PrecioCosto) 
                                               VALUES (@idPedido, @idProducto, @cantidad, @precio);";

                                foreach (clsDetallePedido detalle in listaLocal)
                                {
                                    using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion))
                                    {
                                        cmdDetalle.Parameters.AddWithValue("@idPedido", idPedidoGenerado);

                                        // Si en la clase tenés el ID del producto usás detalle.IdProducto, de lo contrario usamos 1 de prueba
                                        cmdDetalle.Parameters.AddWithValue("@idProducto", detalle.IdProducto > 0 ? detalle.IdProducto : 1);
                                        cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                                        cmdDetalle.Parameters.AddWithValue("@precio", detalle.Precio);

                                        await cmdDetalle.ExecuteNonQueryAsync();
                                    }
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

                    MessageBox.Show($"¡Pedido realizado con éxito y enviado a la droguería! Orden N° {idPedidoGenerado}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            dgvCompras.ResumeLayout();

            // Calculamos totales una sola vez
            CalcularTotalesCompras();
        }
    }
}
