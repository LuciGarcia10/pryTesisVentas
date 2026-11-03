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
        private string cadenaConexion = clsConsultas.cadena;
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
            string query = "SELECT id_rol, nombre_rol FROM Roles ORDER BY nombre_rol ASC";
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
                MessageBox.Show("Error al cargar la lista de roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                if (lector["id_rol"] != DBNull.Value)
                                {
                                    cmbRoles.SelectedValue = Convert.ToInt32(lector["id_rol"]);
                                }

                                if (lector["activo"] != DBNull.Value)
                                {
                                    int estado = Convert.ToBoolean(lector["activo"]) ? 1 : 0;
                                    cmbEstado.SelectedValue = estado;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarPermisos_Click(object sender, EventArgs e)
        {
            // Validar que realmente haya una opción seleccionada
            if (cmbRoles.SelectedValue == null || cmbEstado.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un rol y un estado válidos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Usuarios SET id_rol = @IdRol, activo = @Activo WHERE id_usuario = @IdUsuario";

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        // Casteo explícito a int para asegurar el tipo de dato en SQL Server
                        comando.Parameters.AddWithValue("@IdRol", Convert.ToInt32(cmbRoles.SelectedValue));
                        comando.Parameters.AddWithValue("@Activo", Convert.ToInt32(cmbEstado.SelectedValue));
                        comando.Parameters.AddWithValue("@IdUsuario", idUsuarioSeleccionado);

                        conexion.Open();
                        int filas = comando.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("¡Permisos y rol actualizados correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK; // Esto avisa a FrmPerfil que refresque la grilla
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el registro para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar permisos en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cierra el formulario emergente indicando que se canceló la operación
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
