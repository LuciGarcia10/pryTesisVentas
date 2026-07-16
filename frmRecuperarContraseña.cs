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
    public partial class frmRecuperarContraseña : Form
    {
        public frmRecuperarContraseña()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMail.Text))
            {
                MessageBox.Show("Por favor, ingrese su correo electrónico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Aquí podrías verificar en tu Base de Datos si el mail existe en la tabla de Usuarios.
            // De momento, simulamos el éxito:
            MessageBox.Show("Se ha enviado un enlace de recuperación a: " + txtMail.Text, "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
