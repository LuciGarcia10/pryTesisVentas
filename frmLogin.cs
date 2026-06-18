using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTesisVentas
{
    public partial class frmLogin : Form
    {
        private bool mostrarContraseña = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmIngresar ventanaIngresar = new frmIngresar();
            ventanaIngresar.Show();
        }

        private void btnSig_Click(object sender, EventArgs e)
        {
            AvanzarPaso2();

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text == "Nombre" ||
                string.IsNullOrWhiteSpace(txtApellido.Text) || txtApellido.Text == "Apellido" ||
                string.IsNullOrWhiteSpace(txtMail.Text) || txtMail.Text == "Mail" ||
                string.IsNullOrWhiteSpace(txtContra.Text) || txtContra.Text == "Contraseña")
            {
                MessageBox.Show("Por favor, complete todos los campos.",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("¡Registro completado con éxito!");
        }
        private void AvanzarPaso2()
        {
            txtNombre.Visible = false;
            txtApellido.Visible = false;
            txtMail.Visible = false;
            txtContra.Visible = false;
            lblEstado.Visible = false;
            progressBarContra.Visible = false;
            pcbContra.Visible = false;

            MessageBox.Show("¡Registro completado con éxito!");
            // 2. Mostrar los nuevos controles del Paso 2 (ej. un cuadro para código de verificación)
            // txtCodigoVerificacion.Visible = true; 

            // 3. Actualizar el indicador de progreso visual
            // Aquí puedes cambiar el color del círculo del PASO 2 en el panel lateral
            //panelPaso1.BackColor = Color.LightGray;
            //panelPaso2.BackColor = Color.FromArgb(0, 168, 132);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Esto abrirá el navegador con los términos legales
            System.Diagnostics.Process.Start("https://tu-sitio-farma.com/terminos");
        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {
            int fuerza = txtContra.Text.Length;

            // Usando colores más "vivos" para DigitalFarma
            if (fuerza == 0)
            {
                progressBarContra.Value = 0;
                lblEstado.Text = "";
            }
            else if (fuerza < 4)
            {
                progressBarContra.Value = 30;
                lblEstado.ForeColor = Color.IndianRed;
                lblEstado.Text = "Contraseña insegura";
            }
            else if (fuerza < 8)
            {
                progressBarContra.Value = 60;
                lblEstado.ForeColor = Color.Goldenrod;
                lblEstado.Text = "Contraseña media";
            }
            else
            {
                progressBarContra.Value = 100;
                lblEstado.ForeColor = Color.MediumSeaGreen;
                lblEstado.Text = "Contraseña segura";
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Configuración del PictureBox
            pcbContra.Cursor = Cursors.Hand;
            pcbContra.Click += pcbContra_Click;
            pcbContra.Image = Properties.Resources.show; // ojo abierto

            // Configuración inicial placeholders
            ConfigurarPlaceholder(txtNombre, "Nombre");
            ConfigurarPlaceholder(txtApellido, "Apellido");
            ConfigurarPlaceholder(txtMail, "Mail");
            ConfigurarPlaceholder(txtContra, "Contraseña");
        }
        // Método auxiliar para no repetir código en el Load
        private void ConfigurarPlaceholder(TextBox txt, string texto)
        {
            txt.Text = texto;
            txt.ForeColor = Color.Gray;

            if (texto == "Contraseña")
                txt.UseSystemPasswordChar = false;
        }

        private void txtMail_Enter(object sender, EventArgs e)
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

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "Apellido")
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.Black;
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.Text = "Apellido";
                txtApellido.ForeColor = Color.Gray;
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Text = "Nombre";
                txtNombre.ForeColor = Color.Gray;
            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            if (txtContra.Text == "Contraseña")
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.Black;

                txtContra.UseSystemPasswordChar = true;
                mostrarContraseña = false;
                pcbContra.Image = Properties.Resources.show;
            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContra.Text))
            {
                txtContra.Text = "Contraseña";
                txtContra.ForeColor = Color.Gray;
                txtContra.UseSystemPasswordChar = false;

                mostrarContraseña = false;
                pcbContra.Image = Properties.Resources.show;
            }
        }

        private void pcbContra_Click(object sender, EventArgs e)
        {
            pcbContra.BackColor = Color.Red; // ← línea de prueba

            if (txtContra.ForeColor == Color.Gray)
                return;

            mostrarContraseña = !mostrarContraseña;

            if (mostrarContraseña)
            {
                txtContra.UseSystemPasswordChar = false;
                pcbContra.Image = Properties.Resources.hide;
            }
            else
            {
                txtContra.UseSystemPasswordChar = true;
                pcbContra.Image = Properties.Resources.show;
            }
        }
        private void txtContra_TextChanged_1(object sender, EventArgs e)
        {
            if (txtContra.ForeColor == Color.Gray) return;

            int fuerza = txtContra.Text.Length;

            if (fuerza == 0)
            {
                progressBarContra.Value = 0;
                lblEstado.Text = "";
            }
            else if (fuerza < 4)
            {
                progressBarContra.Value = 30;
                lblEstado.ForeColor = Color.IndianRed;
                lblEstado.Text = "Contraseña insegura";
            }
            else if (fuerza < 8)
            {
                progressBarContra.Value = 60;
                lblEstado.ForeColor = Color.Goldenrod;
                lblEstado.Text = "Contraseña media";
            }
            else
            {
                progressBarContra.Value = 100;
                lblEstado.ForeColor = Color.MediumSeaGreen;
                lblEstado.Text = "Contraseña segura";
            }
        }
    }
}
