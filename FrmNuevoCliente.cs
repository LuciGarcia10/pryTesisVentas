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
            // 1. Validaciones básicas (para asegurarnos de que no dejen campos vacíos)
            if (string.IsNullOrWhiteSpace(TxtNombreC.Text) || string.IsNullOrWhiteSpace(TxtApC.Text))
            {
                MessageBox.Show("Por favor, complete el Nombre y Apellido del cliente.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Tomamos los valores de la interfaz
            string nroAfiliado = TxtNAfiliado.Text.Trim();
            string nombre = TxtNombreC.Text.Trim();
            string apellido = TxtApC.Text.Trim();
            string obraSocial = CmbObraS.Text; // O txtObraSocial según lo que uses
            string estado = "Al dia"; // Estado por defecto al crear un cliente nuevo
                                      // 3. Extraemos el valor del NumericUpDown directamente con .Value
            decimal saldoInicial = numSaldo.Value;

            // 4. Mandamos los datos a la base de datos de SQL Server
            bool registradoConExito = clsConsultas.RegistrarCliente(nroAfiliado, nombre, apellido, obraSocial, estado, saldoInicial);
            if (registradoConExito)
            {
                MessageBox.Show("¡Cliente registrado con éxito en el sistema!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Indicamos al formulario padre que se guardó correctamente para que refresque la grilla
                this.DialogResult = DialogResult.OK;
                this.Close(); // Cierra la ventana de carga
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
