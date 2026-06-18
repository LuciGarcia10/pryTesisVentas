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
    public partial class frmCarrito : Form
    {
        private List<clsDetallePedido> listaLocal;

        public frmCarrito(List<clsDetallePedido> carritoRecibido)
        {
            InitializeComponent();

            this.listaLocal = carritoRecibido;

            // Mostramos los datos en la tabla de tu interfaz
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = listaLocal;

            // Calculamos los totales inicialmente
            CalcularTotalesCarrito();
        }

        private void frmCarrito_Load(object sender, EventArgs e)
        {
            txtFechaEntrega.Text = DateTime.Now.AddDays(1).ToString("dd/MM/yy");
            CalcularTotalesCarrito();
        }

        private void CalcularTotalesCarrito()
        {
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

        private void CalcularTotales()
        {
            decimal totalDinero = 0;
            int totalItems = 0;

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                if (fila.Cells["Cantidad"].Value != null && fila.Cells["Precio"].Value != null)
                {
                    totalItems += Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    totalDinero += Convert.ToDecimal(fila.Cells["Precio"].Value);
                }
            }

            txtCantProd.Text = totalItems.ToString();
            txtPrecioTotal.Text = totalDinero.ToString("C2");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas cancelar el pedido? Se perderán los datos ingresados.", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // MODIFICACIÓN 1: Cambiamos a "async void" para poder usar "await" con Playwright
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
                // Cambiamos el cursor a modo espera y deshabilitamos el botón para evitar clics duplicados
                this.Cursor = Cursors.WaitCursor;
                btnPedir.Enabled = false;

                try
                {
                    string cadenaConexion = "Data Source=.;Initial Catalog=DigitalFarmaBD;Integrated Security=True";
                    int idPedidoGenerado = 0;
                    string proveedorDestino = listaLocal[0].Proveedor; // Obtenemos el proveedor del carrito

                    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        using (SqlTransaction transaccion = conexion.BeginTransaction())
                        {
                            try
                            {
                                // PASO A: Insertar en la tabla de Pedidos (Maestro)
                                string queryPedido = "INSERT INTO Pedidos (Fecha, DireccionEntrega, Total) VALUES (@fecha, @direccion, @total); SELECT SCOPE_IDENTITY();";

                                using (SqlCommand cmdPedido = new SqlCommand(queryPedido, conexion, transaccion))
                                {
                                    cmdPedido.Parameters.AddWithValue("@fecha", DateTime.Now);
                                    cmdPedido.Parameters.AddWithValue("@direccion", txtDireccion.Text);

                                    decimal total = Convert.ToDecimal(txtPrecioTotal.Text.Replace("$", ""));
                                    cmdPedido.Parameters.AddWithValue("@total", total);

                                    idPedidoGenerado = Convert.ToInt32(cmdPedido.ExecuteScalar());
                                }

                                // PASO B: Recorrer el carrito e insertar cada producto en DetallePedidos
                                // MODIFICACIÓN 2: Se agregó el campo Proveedor al INSERT ya que lo estabas pasando como parámetro abajo
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

                                        cmdDetalle.ExecuteNonQuery();
                                    }
                                }

                                // Si todo salió bien en la base de datos, guardamos los cambios locales
                                transaccion.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaccion.Rollback();
                                throw ex;
                            }
                        }
                    }

                    // MODIFICACIÓN 3: EJECUTAMOS LA AUTOMATIZACIÓN WEB POST-GUARDADO EN BD
                    // Al usar await, la aplicación esperará que el bot trabaje en segundo plano sin congelarse
                    try
                    {
                        await clsAutomatizacionDrogueria.CargarPedidoEnWeb(proveedorDestino, listaLocal);
                    }
                    catch (Exception exBot)
                    {
                        // Si falla la web, avisamos pero el pedido en base de datos ya quedó asentado
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
                        nuevoPedido.Total = Convert.ToDecimal(txtPrecioTotal.Text.Replace("$", ""));

                        formularioPadre.listaPedidos.Add(nuevoPedido);
                        formularioPadre.ActualizarGrilla(formularioPadre.listaPedidos);
                    }

                    MessageBox.Show("¡Pedido realizado con éxito en el sistema y enviado a la droguería! Orden N° " + idPedidoGenerado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Vaciamos la lista original y cerramos
                    listaLocal.Clear();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al guardar el pedido en la base de datos: " + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Restauramos los controles de la pantalla
                    this.Cursor = Cursors.Default;
                    btnPedir.Enabled = true;
                }
            }
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

