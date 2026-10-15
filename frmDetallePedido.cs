using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pryTesisVentas
{
    public partial class frmDetallePedido : Form
    {
        private readonly string cadena = clsConsultas.cadena;
        public List<clsPedido> ListaCompleta { get; set; }
        public clsPedido PedidoSeleccionado { get; set; }
        public frmDetallePedido()
        {
            InitializeComponent();
        }

        private void frmDetallePedido_Load(object sender, EventArgs e)
        {
            EstilizarGrillaDetalle();

            if (PedidoSeleccionado != null)
            {
                txtNumeroPedido.Text = PedidoSeleccionado.IdPedido.ToString();
                CargarDetalleDesdeBD(PedidoSeleccionado.IdPedido);
            }
            CalcularTotalGrilla();
        }

        private void EstilizarGrillaDetalle()
        {
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.BackgroundColor = Color.White;
            dgvDetalles.BorderStyle = BorderStyle.None;
            dgvDetalles.RowHeadersVisible = false;
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 250, 245);
            dgvDetalles.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDetalles.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvDetalles.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvDetalles.EnableHeadersVisualStyles = false;
        }
        private void CargarDetalleDesdeBD(int idPedido)
        {
            dgvDetalles.Rows.Clear();
            decimal totalCalculado = 0;

            string query = @"SELECT dp.Cantidad, 
                            ISNULL(p.Nombre, 'Producto #' + CAST(dp.IdProducto AS VARCHAR)) AS Producto, 
                            dp.PrecioCosto AS Precio
                     FROM DetallePedido dp
                     LEFT JOIN Productos p ON dp.IdProducto = p.IdProducto
                     WHERE dp.IdPedido = @IdPedido";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);

                        using (SqlDataReader lector = cmd.ExecuteReader())
                        {
                            bool encontroFilas = false;

                            while (lector.Read())
                            {
                                encontroFilas = true;
                                int cantidad = Convert.ToInt32(lector["Cantidad"]);
                                string producto = lector["Producto"].ToString();
                                decimal precio = Convert.ToDecimal(lector["Precio"]);

                                totalCalculado += (cantidad * precio);

                                int n = dgvDetalles.Rows.Add();
                                dgvDetalles.Rows[n].Cells[0].Value = cantidad;
                                dgvDetalles.Rows[n].Cells[1].Value = producto;
                                dgvDetalles.Rows[n].Cells[2].Value = $"$ {precio:N2}";
                            }

                            if (!encontroFilas)
                            {
                                MessageBox.Show($"El pedido Nº {idPedido} no tiene productos registrados en la base de datos.",
                                                "Sin detalle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    txtPrecioTotal.Text = $"$ {totalCalculado:N2}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar el detalle: " + ex.Message,
                                    "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void lblCerrar_Click(object sender, EventArgs e)
        {
            // Cerramos el formulario de detalle y volvemos a la pantalla de pedidos
            this.Close();
        }

        private void lblCerrar_MouseEnter(object sender, EventArgs e)
        {
            lblCerrar.ForeColor = Color.Red;
        }

        private void lblCerrar_MouseLeave(object sender, EventArgs e)
        {
            lblCerrar.ForeColor = Color.DimGray; // Vuelve al color original
        }

        private void lblPrecioTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumeroPedido.Text))
            {
                MessageBox.Show("Ingrese un número de pedido válido.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(txtNumeroPedido.Text.Trim(), out int idBuscado))
            {
                // 1. Carga los registros del pedido en la grilla
                CargarDetalleDesdeBD(idBuscado);

                // 2. Calcula la suma total y actualiza txtPrecioTotal
                CalcularTotalGrilla();
            }
            else
            {
                MessageBox.Show("El número de pedido debe ser numérico.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioTotal_TextChanged(object sender, EventArgs e)
        {

        }
        private void CalcularTotalGrilla()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila in dgvDetalles.Rows)
            {
                if (fila.IsNewRow) continue;

                // Cantidad (columna 0)
                int cantidad = 0;
                if (fila.Cells[0].Value != null)
                {
                    int.TryParse(fila.Cells[0].Value.ToString(), out cantidad);
                }

                // Precio unitario (columna 2)
                decimal precio = 0;
                if (fila.Cells[2].Value != null)
                {
                    // Limpia signos de moneda o separadores para evitar errores de parseo
                    string textoPrecio = fila.Cells[2].Value.ToString()
                                            .Replace("$", "")
                                            .Replace(".", "")
                                            .Trim();

                    decimal.TryParse(textoPrecio, out precio);
                }

                // Subtotal acumulado
                total += (cantidad * precio);
            }

            // Mostrar el total en el TextBox
            txtPrecioTotal.Text = $"$ {total:N0}";
        }
    }
}
