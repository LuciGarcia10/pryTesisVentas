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
        // 1. Cambiamos 'Producto' por 'clsDetallePedido'
        private List<clsDetallePedido> listaLocal;

        // 2. Aquí también cambiamos el tipo en el constructor
        public frmCarrito(List<clsDetallePedido> carritoRecibido)
        {
            InitializeComponent();

            this.listaLocal = carritoRecibido;

            // Mostramos los datos en la tabla de tu interfaz
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = listaLocal;
        }

        private void frmCarrito_Load(object sender, EventArgs e)
        {
            // Esto se ejecuta apenas se abre la ventana
            txtFechaEntrega.Text = DateTime.Now.AddDays(1).ToString("dd/MM/yy");

        }
        private void CalcularTotalesCarrito()
        {
            int totalCantidad = 0;
            decimal totalDinero = 0;

            // Recorremos la lista de productos que cargamos en el carrito
            foreach (clsDetallePedido detalle in listaLocal)
            {
                totalCantidad += detalle.Cantidad;
                // Multiplicamos cantidad por precio de cada medicamento
                totalDinero += (detalle.Cantidad * detalle.Precio);
            }

            // Mostramos los resultados en tus TextBox (ajustá los nombres si son distintos)
            txtCantProd.Text = totalCantidad.ToString();

            // "C0" le pone el signo $ y los puntos de miles automáticamente sin decimales
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
            txtPrecioTotal.Text = totalDinero.ToString("C2"); // C2 le da formato de moneda $
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Pregunta al usuario si realmente quiere salir
            DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas cancelar el pedido? Se perderán los datos ingresados.", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                this.Close(); // Cierra el formulario si responde "Sí"
            }
        }

        private void btnPedir_Click(object sender, EventArgs e)
        {
            // 1. Validar que hayan puesto una dirección
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, ingresá una dirección de entrega.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Confirmación del usuario
            DialogResult resultado = MessageBox.Show("¿Confirmás la realización de este pedido?", "Confirmar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // --- AQUÍ CONECTAMOS CON TU BASE DE DATOS ---
                    // Reemplaza con tu cadena de conexión real de SQL Server
                    string cadenaConexion = "Data Source=.;Initial Catalog=DigitalFarmaBD;Integrated Security=True";

                    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        // Iniciamos una transacción para asegurarnos de que se guarde TODO o NADA
                        using (SqlTransaction transaccion = conexion.BeginTransaction())
                        {
                            try
                            {
                                // PASO A: Insertar en la tabla de Pedidos (Maestro)
                                // Ajustá los nombres de las columnas a como estén en tu BD
                                string queryPedido = "INSERT INTO Pedidos (Fecha, DireccionEntrega, Total) VALUES (@fecha, @direccion, @total); SELECT SCOPE_IDENTITY();";

                                int idPedidoGenerado;
                                using (SqlCommand cmdPedido = new SqlCommand(queryPedido, conexion, transaccion))
                                {
                                    cmdPedido.Parameters.AddWithValue("@fecha", DateTime.Now);
                                    cmdPedido.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                                    // Convertimos el total del TextBox a decimal (quitando el '$')
                                    decimal total = Convert.ToDecimal(txtPrecioTotal.Text.Replace("$", ""));
                                    cmdPedido.Parameters.AddWithValue("@total", total);

                                    // SCOPE_IDENTITY() nos devuelve el ID (autonumérico) que se le asignó a este pedido
                                    idPedidoGenerado = Convert.ToInt32(cmdPedido.ExecuteScalar());
                                }

                                // PASO B: Recorrer el carrito e insertar cada producto en DetallePedidos
                                string queryDetalle = "INSERT INTO DetallePedidos (IdPedido, NombreProducto, Cantidad, Precio) VALUES (@idPedido, @nombre, @cantidad, @precio);";

                                foreach (clsDetallePedido detalle in listaLocal)
                                {
                                    using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion))
                                    {
                                        cmdDetalle.Parameters.AddWithValue("@idPedido", idPedidoGenerado);
                                        cmdDetalle.Parameters.AddWithValue("@nombre", detalle.Producto); // Ajustá a las propiedades de tu clsDetallePedido
                                        cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                                        cmdDetalle.Parameters.AddWithValue("@precio", detalle.Precio);
                                        cmdDetalle.Parameters.AddWithValue("@proveedor", detalle.Proveedor);
                                        cmdDetalle.ExecuteNonQuery();
                                    }

                                    // TIP EXTRA: Aquí también podrías meter un UPDATE a tu tabla de Productos 
                                    // para restar el stock (Stock = Stock - detalle.Cantidad) si te lo piden en Ceyad.
                                }

                                // Si todo salió bien, guardamos los cambios en la BD
                                transaccion.Commit();

                                MessageBox.Show("¡Pedido realizado con éxito! Tu orden es la N° " + idPedidoGenerado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Vaciamos la lista original para que el carrito quede limpio
                                listaLocal.Clear();

                                this.Close(); // Cerramos la ventana del carrito
                            }
                            catch (Exception ex)
                            {
                                // Si algo falló en el camino, deshace todo para no dejar datos corruptos
                                transaccion.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al guardar el pedido en la base de datos: " + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
