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
    public partial class FrmEditarProducto : Form
    {
        public Producto ProductoSeleccionado { get; set; }
        public FrmEditarProducto()
        {
            InitializeComponent();
        }
        public FrmEditarProducto(Producto prod) : this()
        {
            ProductoSeleccionado = prod;
            CargarDatosDelProducto();
        }

        private void CargarDatosDelProducto()
        {
            if (ProductoSeleccionado != null)
            {
                txtNombre.Text = ProductoSeleccionado.Nombre;
                // cboCategoria.Text = ProductoSeleccionado.Categoria;
                // numStock.Value = ProductoSeleccionado.Stock;
                // txtPrecio.Text = ProductoSeleccionado.Precio.ToString();
                // dtpVencimiento.Value = ProductoSeleccionado.FechaVencimiento;
            }
        }
        private void FrmEditarProducto_Load(object sender, EventArgs e)
        {
            CargarComboCategorias();

            if (ProductoSeleccionado != null)
            {
                txtNombre.Text = ProductoSeleccionado.Nombre;
                nudStock.Value = ProductoSeleccionado.Cantidad;
                txtPrecio.Text = ProductoSeleccionado.Precio.ToString("N2");
                dtpVencimiento.Value = ProductoSeleccionado.FechaVencimiento > DateTime.MinValue
                                       ? ProductoSeleccionado.FechaVencimiento
                                       : DateTime.Today;

                // Seleccionar la categoría actual
                cmbCategoria.SelectedIndex = cmbCategoria.FindStringExact(ProductoSeleccionado.Categoria);
            }

        }
        private void CargarComboCategorias()
        {
            string query = "SELECT IdCategoria, Nombre FROM Categorias ORDER BY Nombre";

            using (SqlConnection conexion = new SqlConnection(clsConsultas.cadena))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader lector = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(lector);

                            cmbCategoria.DataSource = dt;
                            cmbCategoria.DisplayMember = "Nombre";
                            cmbCategoria.ValueMember = "IdCategoria";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            string precioLimpio = txtPrecio.Text.Replace("$", "").Trim();
            if (!decimal.TryParse(precioLimpio, out decimal precioNuevo) || precioNuevo <= 0)
            {
                MessageBox.Show("Ingrese un precio válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Actualizar en SQL Server
            string query = @"
                UPDATE Productos 
                SET Nombre = @nombre,
                    StockActual = @stock,
                    PrecioVenta = @precio,
                    IdCategoria = @idCategoria
                WHERE IdProducto = @id";

            using (SqlConnection conexion = new SqlConnection(clsConsultas.cadena))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@stock", (int)nudStock.Value);
                        cmd.Parameters.AddWithValue("@precio", precioNuevo);
                        cmd.Parameters.AddWithValue("@idCategoria", cmbCategoria.SelectedValue);
                        cmd.Parameters.AddWithValue("@id", ProductoSeleccionado.Id);

                        cmd.ExecuteNonQuery();
                    }

                    // 3. Actualizar el objeto en memoria
                    ProductoSeleccionado.Nombre = txtNombre.Text.Trim();
                    ProductoSeleccionado.Cantidad = (int)nudStock.Value;
                    ProductoSeleccionado.Precio = precioNuevo;
                    ProductoSeleccionado.Categoria = cmbCategoria.Text;
                    ProductoSeleccionado.FechaVencimiento = dtpVencimiento.Value;

                    MessageBox.Show("Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el producto: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
