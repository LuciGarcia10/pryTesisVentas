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
                    string cadenaConexion = "Data Source=DESKTOP-TGRLC0K\\MSSQLSERVER01;Initial Catalog=BDDigitalFarma;User ID=sa;Password=TU_CLAVE;TrustServerCertificate=True";
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
                                // Insertar en la tabla de Pedidos (Maestro)
                                string queryPedido = "INSERT INTO Pedidos (Fecha, DireccionEntrega, Total) VALUES (@fecha, @direccion, @total); SELECT SCOPE_IDENTITY();";

                                using (SqlCommand cmdPedido = new SqlCommand(queryPedido, conexion, transaccion))
                                {
                                    cmdPedido.Parameters.AddWithValue("@fecha", DateTime.Now);
                                    cmdPedido.Parameters.AddWithValue("@direccion", txtDireccion.Text);

                                    cmdPedido.Parameters.AddWithValue("@total", totalPedido);

                                    object res = await cmdPedido.ExecuteScalarAsync();
                                    idPedidoGenerado = Convert.ToInt32(res);
                                }

                                // Recorrer la lista e insertar cada producto en DetallePedidos
                                string queryDetalle = "INSERT INTO DetallePedidos (IdPedido, NombreProducto, Cantidad, Precio, Proveedor) VALUES (@idPedido, @nombre, @cantidad, @precio, @proveedor);";

                                foreach (clsDetallePedido detalle in listaLocal)
                                {
                                    using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion))
                                    {
                                        cmdDetalle.Parameters.AddWithValue("@idPedido", idPedidoGenerado);
                                        cmdDetalle.Parameters.AddWithValue("@nombre", detalle.Producto);
                                        cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                                        cmdDetalle.Parameters.AddWithValue("@precio", detalle.Precio);
                                        cmdDetalle.Parameters.AddWithValue("@proveedor", detalle.Proveedor);

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

                    // EJECUTAMOS LA AUTOMATIZACIÓN WEB POST-GUARDADO EN BD
                    try
                    {
                        await clsAutomatizacionDrogueria.CargarPedidoEnWeb(proveedorDestino, listaLocal);
                    }
                    catch (Exception exBot)
                    {
                        MessageBox.Show($"El pedido se guardó en el sistema pero falló la carga automática en la web: {exBot.Message}",
                                        "Aviso de Automatización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Sincronización con la grilla del formulario principal de pedidos (frmPedidos) si está abierto
                    frmPedidos formularioPadre = (frmPedidos)Application.OpenForms["frmPedidos"];
                    if (formularioPadre != null)
                    {
                        clsPedido nuevoPedido = new clsPedido();
                        nuevoPedido.IdPedido = idPedidoGenerado;
                        nuevoPedido.Fecha = DateTime.Now;
                        nuevoPedido.Proveedor = proveedorDestino;
                        nuevoPedido.Estado = "Pendiente";
                        nuevoPedido.Detalles = new List<clsDetallePedido>(this.listaLocal);
                        nuevoPedido.Total = totalPedido;

                        formularioPadre.listaPedidos.Add(nuevoPedido);
                        formularioPadre.ActualizarGrilla(formularioPadre.listaPedidos);
                    }

                    MessageBox.Show("¡Pedido realizado con éxito en el sistema y enviado a la droguería! Orden N° " + idPedidoGenerado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
