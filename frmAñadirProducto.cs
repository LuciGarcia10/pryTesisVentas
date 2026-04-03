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
    public partial class frmAñadirProducto : Form
    {
        string cadenaConexion = "Server=.\\SQLEXPRESS; Database=DigitalFarma; Integrated Security=True";
        public frmAñadirProducto()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAñadirproducto_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completa el nombre y la categoría.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Captura de datos
            string nombre = txtNombre.Text;
            string categoria = cmbCategoria.SelectedItem.ToString();
            int cantidad = (int)numCantidad.Value;
            DateTime vencimiento = dtpVencimiento.Value;

            // 3. Insertar en la Base de Datos
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "INSERT INTO Productos (Nombre, Categoria, Cantidad, FechaVencimiento) " +
                                   "VALUES (@nom, @cat, @cant, @fec)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        // Parámetros de seguridad (evita Inyección SQL)
                        comando.Parameters.AddWithValue("@nom", nombre);
                        comando.Parameters.AddWithValue("@cat", categoria);
                        comando.Parameters.AddWithValue("@cant", cantidad);
                        comando.Parameters.AddWithValue("@fec", vencimiento);

                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("¡Producto cargado con éxito!", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cerramos la ventana y avisamos al formulario principal que hubo éxito
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void frmAñadirProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
