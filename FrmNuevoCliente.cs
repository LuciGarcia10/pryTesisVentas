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
    public partial class FrmNuevoCliente : Form
    {
        public FrmNuevoCliente()
        {
            InitializeComponent();
            ConfigurarEstilos();
        }

        private void ConfigurarEstilos()
        {
            
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;


            BtnAgregarC.BackColor = Color.FromArgb(0, 150, 136);
            BtnAgregarC.ForeColor = Color.White;
            BtnAgregarC.FlatStyle = FlatStyle.Flat;
            BtnAgregarC.FlatAppearance.BorderSize = 0;
        }
        private void BtnAgregarC_Click(object sender, EventArgs e)
        {
            // 1. Validar que los campos obligatorios no estén vacios
            if (string.IsNullOrWhiteSpace(TxtNombreC.Text) || string.IsNullOrWhiteSpace(TxtApC.Text) || string.IsNullOrWhiteSpace(TxtNAfiliado.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios (Nombre, apellido y N° de Afiliado).",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Crear la instancia del nuevo cliente usando clsCuentasC
                clsCuentasC nuevoCliente = new clsCuentasC();
                nuevoCliente.IdAfiliado = int.Parse(TxtNAfiliado.Text);
                nuevoCliente.Nombre = TxtNombreC.Text;
                nuevoCliente.Apellido = TxtApC.Text;
                nuevoCliente.ObraSocial = CmbObraS.Text;
                nuevoCliente.Estado = "Al día"; 
                nuevoCliente.Saldo = 0;         

                // 3. Para guardar 
               // clsConsultas.InsertarCliente(nuevoCliente); 

                // 4. Notificar al formulario padre y cerrar
                MessageBox.Show("Cliente registrado con éxito.", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TxtNAfiliado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            // Llenar Combo de Obra Social
            CmbObraS.Items.Clear();
            CmbObraS.Items.Add("Particular");
            CmbObraS.Items.Add("PAMI");
            CmbObraS.Items.Add("Apross");
            CmbObraS.Items.Add("Swiss Medical");
            CmbObraS.Items.Add("OSDE");

            CmbObraS.SelectedIndex = 0; 

            // Estado inicial del cliente
            if (CmbECuenta != null)
            {
                CmbECuenta.Items.Clear();
                CmbECuenta.Items.Add("Al día");
                CmbECuenta.Items.Add("Inactivo");
                CmbECuenta.SelectedIndex = 0;
            }
        }
    }
}
