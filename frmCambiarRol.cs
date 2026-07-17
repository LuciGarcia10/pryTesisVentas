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
    public partial class frmCambiarRol : Form
    {
        private int idUsuarioSeleccionado;
        private string cadenaConexion = "Server=localhost; Database=BDDigitalFarma; Integrated Security=True";
        public frmCambiarRol(int idUsuario)
        {
            InitializeComponent();
            idUsuarioSeleccionado = idUsuario;
        }

        private void frmCambiarRol_Load(object sender, EventArgs e)
        {
            // Centra el cartel en el medio de la pantalla principal
            this.StartPosition = FormStartPosition.CenterParent;

            // Evita que el usuario maximice o deforme el tamaño de la ventanita
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ConfigurarComboEstado();
            CargarComboRoles();
            CargarDatosUsuario();
        }
        private void CargarComboRoles()
        {
            string query = "SELECT id_rol, nombre_rol FROM Roles";
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbRoles.DataSource = dt;
                    cmbRoles.DisplayMember = "nombre_rol";
                    cmbRoles.ValueMember = "id_rol";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message);
            }
        }
        private void ConfigurarComboEstado()
        {
            DataTable dtEstado = new DataTable();
            dtEstado.Columns.Add("Texto");
            dtEstado.Columns.Add("Valor", typeof(int));

            // 1 para Activo, 0 para Inactivo (calza con el BIT de tu BD)
            dtEstado.Rows.Add("Activo", 1);
            dtEstado.Rows.Add("Inactivo", 0);

            cmbEstado.DataSource = dtEstado;
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
        }
        private void CargarDatosUsuario()
        {
            string query = "SELECT id_rol, activo FROM Usuarios WHERE id_usuario = @Id";
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", idUsuarioSeleccionado);
                        conexion.Open();
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                cmbRoles.SelectedValue = Convert.ToInt32(lector["id_rol"]);

                                // Lee el BIT (0 o 1) de la BD y selecciona el ítem correcto en el combo
                                int estadoBD = Convert.ToBoolean(lector["activo"]) ? 1 : 0;
                                cmbEstado.SelectedValue = estadoBD;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message);
            }
        }

        private void btnGuardarPermisos_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Usuarios SET id_rol = @IdRol, activo = @Activo WHERE id_usuario = @IdUsuario";
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdRol", cmbRoles.SelectedValue);
                        // Toma el 1 o 0 seleccionado en el ComboBox de estado
                        comando.Parameters.AddWithValue("@Activo", cmbEstado.SelectedValue);
                        comando.Parameters.AddWithValue("@IdUsuario", idUsuarioSeleccionado);

                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar permisos: " + ex.Message);
            }
        }
    }
}
