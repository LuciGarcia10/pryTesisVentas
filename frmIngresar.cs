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
    public partial class frmIngresar : Form
    {
        public frmIngresar()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Requerimiento: Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtContra.Text) ||
                txtMail.Text == "Mail" || txtContra.Text == "Contraseña")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mailIngresado = txtMail.Text.Trim();
            string contraIngresada = txtContra.Text.Trim();

            // Consulta SQL para buscar al usuario por su mail y traer también su rol
            string query = @"SELECT U.id_usuario, U.nombre, U.mail, U.contrasenia, R.nombre_rol 
                     FROM Usuarios U 
                     INNER JOIN Roles R ON U.id_rol = R.id_rol 
                     WHERE U.mail = @Mail";

            try
            {
                using (SqlConnection conexion = new SqlConnection(clsConsultas.cadena))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Mail", mailIngresado);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                string contraEnBD = lector["contrasenia"].ToString();

                                // Validamos si la contraseña coincide
                                if (contraEnBD == contraIngresada)
                                {
                                    // --- ¡GUARDAMOS LOS DATOS EN NUESTRA CLASE CLSUSUARIO! ---
                                    ClsUsuario.IdUsuario = Convert.ToInt32(lector["id_usuario"]);
                                    ClsUsuario.UsuarioLogueado = lector["nombre"].ToString();
                                    ClsUsuario.EmailLogueado = lector["mail"].ToString();
                                    ClsUsuario.RolLogueado = lector["nombre_rol"].ToString();
                                    // ---------------------------------------------------------

                                    // Lógica de recordar credenciales
                                    if (chkRecordar.Checked)
                                    {
                                        Properties.Settings.Default.UsuarioRecordado = mailIngresado;
                                        Properties.Settings.Default.RecordarCredenciales = true;
                                    }
                                    else
                                    {
                                        Properties.Settings.Default.UsuarioRecordado = string.Empty;
                                        Properties.Settings.Default.RecordarCredenciales = false;
                                    }
                                    Properties.Settings.Default.Save();

                                    // Abrimos el formulario de inicio
                                    frmInicio frm = new frmInicio();
                                    frm.Show();

                                    // Ocultamos el login actual
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Contraseña incorrecta.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ninguna cuenta registrada con ese correo electrónico.", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            frmLogin registro = new frmLogin();

            // Mostrar el registro
            registro.Show();

            // Ocultar el formulario actual de ingreso
            this.Hide();
        }

        private void txtMail_Enter(object sender, EventArgs e)// LÓGICA PARA MAIL (Agregá estos eventos en el rayito del diseñador)
        {
            if (txtMail.Text == "Mail")
            {
                txtMail.Text = "";
                txtMail.ForeColor = Color.Black;
            }
        }

        private void txtMail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                txtMail.Text = "Mail";
                txtMail.ForeColor = Color.Gray;
            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            // Cuando el usuario hace clic para escribir, borramos el placeholder
            if (txtContra.Text == "Contraseña")
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.Black;

                // ACTIVA ENMASCARADO: Muestra los puntitos del sistema al escribir
                txtContra.PasswordChar = '*';
            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            // Si el usuario sale de la caja de texto y no escribió nada
            if (string.IsNullOrWhiteSpace(txtContra.Text))
            {
                txtContra.Text = "Contraseña";
                txtContra.ForeColor = Color.Gray;

                // DESACTIVA EL ENMASCARADO: Permite que se vuelva a leer la palabra "Contraseña"
                txtContra.PasswordChar = '\0';
            }
        }

        private void frmIngresar_Load(object sender, EventArgs e)
        {
            // Apenas arranca el formulario, le configuramos el asterisco por defecto al cuadro
            // para asegurarnos de que NUNCA muestre texto limpio si se escribe algo.
            txtContra.PasswordChar = '*';
            // Si el sistema recuerda que el usuario tildó el checkbox la última vez:
            if (Properties.Settings.Default.RecordarCredenciales)
            {
                txtMail.Text = Properties.Settings.Default.UsuarioRecordado;
                txtMail.ForeColor = Color.Black; // Le cambiamos el color a negro porque ya no es el placeholder gris
                chkRecordar.Checked = true;

                // Le damos el foco directo a la contraseña para que solo tengan que tipear el número
                txtContra.Focus();
            }
        }

        private void lnkOlvidasteContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperarContraseña frmRecuperar = new frmRecuperarContraseña();
            frmRecuperar.ShowDialog();
        }

        private void frmIngresar_Resize(object sender, EventArgs e)
        {
            // Obtiene el límite donde comienza el panel verde de la derecha
            int anchoZonaBlanca = pnlIngresar.Left; // Ajusta 'pnlVerde' al nombre de tu panel derecho

            // Centra pnlLogin horizontalmente en el área blanca y verticalmente en el formulario
            pnlIngresa.Left = (anchoZonaBlanca - pnlIngresa.Width) / 2;
            pnlIngresa.Top = (this.ClientSize.Height - pnlIngresa.Height) / 2;
        }
    }
}
