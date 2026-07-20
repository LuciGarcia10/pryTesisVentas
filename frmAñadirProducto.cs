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
            // 1. Validamos que el usuario no deje campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                cmbCategoria.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos (Nombre, Categoría y Precio).", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Capturamos los datos que escribió el usuario en la pantalla
            string nombre = txtNombre.Text.Trim();
            string categoria = cmbCategoria.SelectedItem.ToString();
            int cantidad = (int)numCantidad.Value;
            DateTime vencimiento = dtpVencimiento.Value;

            // Intentamos convertir el precio a decimal de forma segura para que no se rompa si escriben letras
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Por favor, ingresa un precio válido (ejemplo: 1200 o 350.50).", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Insertamos el producto en SQL Server
            try
            {
                // Usamos la cadena de conexión unificada de tu proyecto (clsConsultas.cadena)
                using (SqlConnection conexion = new SqlConnection(clsConsultas.cadena))
                {
                    conexion.Open();

                    // Consulta estructurada con parámetros de seguridad (evita Inyección SQL)
                    string query = "INSERT INTO Productos (Nombre, Categoria, Cantidad, FechaVencimiento, Precio) " +
                                   "VALUES (@nom, @cat, @cant, @fec, @prec)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        // Enlazamos los datos capturados con los parámetros de la consulta SQL
                        comando.Parameters.AddWithValue("@nom", nombre);
                        comando.Parameters.AddWithValue("@cat", categoria);
                        comando.Parameters.AddWithValue("@cant", cantidad);
                        comando.Parameters.AddWithValue("@fec", vencimiento);
                        comando.Parameters.AddWithValue("@prec", precio);

                        // Ejecutamos la inserción en la base de datos
                        comando.ExecuteNonQuery();
                    }
                }

                // Si todo salió bien, mostramos mensaje de éxito
                MessageBox.Show("¡Producto cargado con éxito!", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Avisamos al formulario principal que la operación fue un éxito (OK) para que recargue la grilla automáticamente
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message, "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAñadirProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
