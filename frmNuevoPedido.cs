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
        List<clsDetallePedido> compra = new List<clsDetallePedido>();
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

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Si el carrito tiene productos, avisamos antes de cerrar
            if (compra.Count > 0)
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

        private void btnAgregararCompras_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbProductos.Text))
            {
                MessageBox.Show("Por favor, ingrese o seleccione un producto.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbProveedores.Text))
            {
                MessageBox.Show("Por favor, seleccione un proveedor.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Creamos el detalle
            clsDetallePedido nuevoItem = new clsDetallePedido
            {
                Producto = cmbProductos.Text,
                Cantidad = (int)numCantidad.Value,
                Proveedor = cmbProveedores.Text,
                Precio = 1500.00m // O el precio que traiga tu base de datos
            };

            compra.Add(nuevoItem);

            // Limpiamos los campos
            cmbProductos.SelectedIndex = -1;
            numCantidad.Value = 1;

            MessageBox.Show("Producto agregado a la lista de compras.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVerCompras_Click(object sender, EventArgs e)
        {
            if (compra.Count == 0)
            {
                MessageBox.Show("El carrito de compras está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmCompras ventanaCompras = new frmCompras(compra);
            ventanaCompras.StartPosition = FormStartPosition.CenterParent;
            ventanaCompras.ShowDialog(this);
        }
    }
}
