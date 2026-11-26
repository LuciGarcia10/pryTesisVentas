using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTesisVentas
{
    public partial class FrmPedidoWhatsApp : Form
    {

        private readonly string _nombreProveedor;
        private readonly string _telefonoProveedor;
        private readonly string _productoInicial;
        private readonly DataTable dtProductos = new DataTable();

        public FrmPedidoWhatsApp(string nombreProveedor, string telefonoProveedor, string productoInicial = "")
        {
            InitializeComponent();
            _nombreProveedor = nombreProveedor;
            _telefonoProveedor = telefonoProveedor;
            _productoInicial = productoInicial;
        }

        private void FrmPedidoWhatsApp_Load(object sender, EventArgs e)
        {
            lblNombreProducto.Text = $"Proveedor {_nombreProveedor}";
            ConfigurarTabla();
            CargarProductosDesdeBase();

            // Si ya eligió un producto en frmNuevoPedido, lo dejamos preseleccionado
            if (!string.IsNullOrWhiteSpace(_productoInicial))
            {
                int indice = cmbProductos.FindStringExact(_productoInicial);
                if (indice != -1)
                {
                    cmbProductos.SelectedIndex = indice;
                }
            }
        }

        private void ConfigurarTabla()
        {
            dgvDetallePedido.AllowUserToAddRows = false;
            dgvDetallePedido.ReadOnly = true;
            dgvDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvDetallePedido.Columns.Count == 0)
            {
                dgvDetallePedido.Columns.Add("Cantidad", "Cantidad");
                dgvDetallePedido.Columns.Add("Producto", "Producto");
            }
        }

        private void CargarProductosDesdeBase()
        {
            string cadenaConexion = clsConsultas.cadena;
            string query = "SELECT IdProducto, Nombre FROM Productos ORDER BY Nombre ASC";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    dtProductos.Clear();
                    adaptador.Fill(dtProductos);

                    cmbProductos.DisplayMember = "Nombre";
                    cmbProductos.ValueMember = "IdProducto";
                    cmbProductos.DataSource = dtProductos;

                    cmbProductos.SelectedIndex = -1;
                    cmbProductos.Text = "Elegir Producto...";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los productos: " + ex.Message,
                        "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string producto = cmbProductos.Text.Trim();
            int cantidad = (int)numCantidad.Value;

            if (string.IsNullOrWhiteSpace(producto) || cmbProductos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccioná un producto de la lista.", "DigitalFarma",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show("Ingresá una cantidad mayor a 0.", "DigitalFarma",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si el producto ya está en la grilla, sumamos la cantidad en lugar de repetir la fila
            foreach (DataGridViewRow fila in dgvDetallePedido.Rows)
            {
                if (string.Equals(fila.Cells["Producto"].Value?.ToString(), producto, StringComparison.OrdinalIgnoreCase))
                {
                    int cantidadActual = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    fila.Cells["Cantidad"].Value = cantidadActual + cantidad;
                    LimpiarSeleccionActual();
                    return;
                }
            }

            // Si no estaba, agregamos una fila nueva
            dgvDetallePedido.Rows.Add(cantidad, producto);
            LimpiarSeleccionActual();
        }

        private void LimpiarSeleccionActual()
        {
            cmbProductos.SelectedIndex = -1;
            cmbProductos.Text = "Elegir Producto...";
            numCantidad.Value = 0;
        }

        private void dgvDetallePedido_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string producto = dgvDetallePedido.Rows[e.RowIndex].Cells["Producto"].Value?.ToString() ?? "";
            DialogResult rta = MessageBox.Show(
                $"¿Querés quitar '{producto}' de la lista del pedido?",
                "Quitar producto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rta == DialogResult.Yes)
            {
                dgvDetallePedido.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnEnviarWpp_Click(object sender, EventArgs e)
        {
            var itemsPedido = new List<string>();

            foreach (DataGridViewRow fila in dgvDetallePedido.Rows)
            {
                string cant = fila.Cells["Cantidad"].Value?.ToString() ?? "0";
                string prod = fila.Cells["Producto"].Value?.ToString() ?? "";

                if (!string.IsNullOrWhiteSpace(prod))
                {
                    itemsPedido.Add($"• {cant} x {prod}");
                }
            }

            if (itemsPedido.Count == 0)
            {
                MessageBox.Show("Agregá al menos un producto a la tabla antes de enviar el pedido.",
                    "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string telefonoLimpio = new string((_telefonoProveedor ?? "").Where(char.IsDigit).ToArray());
            if (string.IsNullOrWhiteSpace(telefonoLimpio))
            {
                MessageBox.Show($"El proveedor {_nombreProveedor} no tiene un teléfono de WhatsApp válido configurado.",
                    "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje = $"Hola {_nombreProveedor}, desde la farmacia queremos realizar el siguiente pedido:\n\n" +
                             string.Join("\n", itemsPedido);

            string urlWhatsApp = $"https://api.whatsapp.com/send?phone={telefonoLimpio}&text={Uri.EscapeDataString(mensaje)}";

            Process.Start(new ProcessStartInfo
            {
                FileName = urlWhatsApp,
                UseShellExecute = true
            });

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
