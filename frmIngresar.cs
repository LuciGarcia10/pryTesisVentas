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
    public partial class frmIngresar : Form
    {
        public frmIngresar()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Requerimiento: Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtContra.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            // Validación de credenciales (Requerimiento 7) [cite: 525]
            if (txtMail.Text == "admin@digitalfarma.com" && txtContra.Text == "1234")
            {
                // Si es correcto, abrimos el formulario principal 
                //FormMain principal = new FormMain();
                //principal.Show();
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
            if (txtContra.Text == "Contraseña")
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.Black;
                txtContra.UseSystemPasswordChar = true; // Activa los puntitos al escribir
            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContra.Text))
            {
                txtContra.Text = "Contraseña";
                txtContra.ForeColor = Color.Gray;
                txtContra.UseSystemPasswordChar = false; // Muestra la palabra "Contraseña"
            }
        }
    }
}
