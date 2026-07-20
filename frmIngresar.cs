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
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Variable para guardar el rol que inició sesión
            string rolUsuario = "";

            // 1. Validación de credenciales para ADMINISTRADOR
            if (txtMail.Text == "admin@digitalfarma.com" && txtContra.Text == "1234")
            {
                rolUsuario = "Administrador";
            }
            // 2. NUEVO ROL: Validación de credenciales para EMPLEADO/VENDEDOR
            else if (txtMail.Text == "empleado@digitalfarma.com" && txtContra.Text == "5678")
            {
                rolUsuario = "Empleado";
            }
            // Puedes agregar más roles aquí usando otros 'else if'

            // Si el rolUsuario cambió, significa que las credenciales son correctas
            if (rolUsuario != "")
            {
                // --- ¡NUEVA LÓGICA DE RECORDAR CREDENCIALES ACÁ! ---
                if (chkRecordar.Checked)
                {
                    // Guardamos el mail ingresado y activamos el estado en la memoria del disco
                    Properties.Settings.Default.UsuarioRecordado = txtMail.Text.Trim();
                    Properties.Settings.Default.RecordarCredenciales = true;
                }
                else
                {
                    // Si entraron bien pero desmarcaron el botón, borramos el recuerdo
                    Properties.Settings.Default.UsuarioRecordado = string.Empty;
                    Properties.Settings.Default.RecordarCredenciales = false;
                }
                // Impactamos el guardado de manera física
                Properties.Settings.Default.Save();
                // ----------------------------------------------------

                // Creamos el formulario de inicio
                frmInicio frm = new frmInicio();
                frm.Show();

                // Ocultamos el formulario de login actual
                this.Hide();
            }
            else
            {
                // Requerimiento 17.1: Mostrar mensaje si son incorrectos 
                MessageBox.Show("Mail o contraseña incorrectos");
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
    }
}
