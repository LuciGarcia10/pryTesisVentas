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
    public partial class frmNuevoPedido : Form
    {
        List<clsDetallePedido> carrito = new List<clsDetallePedido>();
        public frmNuevoPedido()
        {
            InitializeComponent();
        }

        private void frmNuevoPedido_Load(object sender, EventArgs e)
        {

        }
        private void CargarProductosDesdeBase()
        {
            // 1. Cadena de conexión a tu base de datos
            string cadenaConexion = "Server=.; Database=BDDigitalFarma; Integrated Security=True;";

            // 2. Consulta SQL: Traemos el ID (clave primaria) y el Nombre de los productos
            string query = "SELECT id_producto, nombre_producto FROM Productos ORDER BY nombre_producto ASC";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();

                    // 3. Adaptador para llenar los datos en memoria
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    // 4. Vincular los datos extraídos de SQL con tu ComboBox
                    // DisplayMember es lo que ve el usuario en la lista (el nombre)
                    cmbProductos.DisplayMember = "nombre_producto";

                    // ValueMember es el ID real del producto que queda oculto en memoria (sirve para registrar el pedido)
                    cmbProductos.ValueMember = "id_producto";

                    // Le pasamos la tabla con los datos reales
                    cmbProductos.DataSource = dt;

                    // 5. Configuración visual inicial
                    cmbProductos.SelectedIndex = -1; // Hace que empiece vacío
                    cmbProductos.Text = "Escribir o elegir producto..."; // Texto de ayuda idéntico a tu diseño
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los productos de la base: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void lblHacerPedido1_Click(object sender, EventArgs e)
        {

        }

      



        private void btnAgregararCarrito_Click(object sender, EventArgs e)
        {
            // Validamos que no esté vacío (usamos el texto del label como referencia)
            if (string.IsNullOrWhiteSpace(cmbProductos.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del producto.");
                return;
            }

            // Creamos un nuevo item de pedido
            clsDetallePedido nuevoItem = new clsDetallePedido();
            nuevoItem.Producto = cmbProductos.Text;
            nuevoItem.Cantidad = (int)numCantidad.Value; // Asumiendo que usás un NumericUpDown
            nuevoItem.Proveedor = cmbProveedores.Text;

            // Lo sumamos a la lista
            carrito.Add(nuevoItem);

            // Limpiamos para el siguiente
            cmbProductos.SelectedIndex = -1;
            numCantidad.Value = 1;
            MessageBox.Show("Producto agregado al carrito temporal.");
        }

        private void btnVerCarrito_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ahora que frmCarrito existe, esto va a compilar de diez:
            frmCarrito ventanaCarrito = new frmCarrito(carrito);
            ventanaCarrito.ShowDialog();
        }
        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Si el carrito tiene productos, avisamos antes de cerrar
            if (carrito.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Tenés productos en el carrito. ¿Estás seguro de que querés cancelar el pedido? Se borrará todo.",
                    "DigitalFarma",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    this.Close(); // Cerramos la ventana
                }
            }
            else
            {
                // Si no hay nada, cerramos directamente
                this.Close();
            }
        }
    }
}
