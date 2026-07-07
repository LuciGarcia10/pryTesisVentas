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
        // Creamos una propiedad para definir el modo: "NUEVO", "EDITAR" o "DETALLES"
        public string Modo { get; set; } = "NUEVO"; // Por defecto arranca en Nuevo

        // Variable para guardar el ID del cliente si vamos a editar o ver detalles
        public string IdClienteSeleccionado { get; set; }
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

        //AGREGAMOS UN CLIENTE A LA BASE DE DATOS
        private void BtnAgregarC_Click(object sender, EventArgs e)
        {
            // 1. Llamamos a tu método: prende las alertas rojas y si algo falta, frena acá.
            if (!ValidarCamposObligatorios())
            {
                return;
            }

            // 2. Tomamos los valores de la interfaz (tal cual lo tenías vos)
            string nroAfiliado = TxtNAfiliado.Text.Trim();
            string dni = TxtDni.Text.Trim();
            string nombre = TxtNombreC.Text.Trim();
            string apellido = TxtApC.Text.Trim();
            string telefono = TxtTel.Text.Trim();
            string email = TxtEmail.Text.Trim();
            string obraSocial = CmbObraS.Text;
            string estado = "Al dia";
            decimal saldoInicial = numSaldo.Value;

            // ====================================================================
            // REUTILIZACIÓN
            // ====================================================================
            if (Modo == "EDITAR")
            {
                // 3A. Si el modo es EDITAR, llamamos al método UPDATE pasándole el ID que guardamos al abrir el formulario
                bool modificadoConExito = clsConsultas.ModificarCliente(IdClienteSeleccionado, nroAfiliado, dni, nombre, apellido, telefono, email, obraSocial, saldoInicial);

                if (modificadoConExito)
                {
                    MessageBox.Show("¡Cliente modificado con éxito en el sistema!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; // Le avisa a la grilla que se refresque
                    this.Close(); // Cierra la ventana
                }
            }
            else
            {
                // 3B. MODO NUEVO (Tu código original del INSERT)
                bool registradoConExito = clsConsultas.RegistrarCliente(nroAfiliado, dni, nombre, apellido, telefono, email, obraSocial, estado, saldoInicial);

                if (registradoConExito)
                {
                    MessageBox.Show("¡Cliente registrado con éxito en el sistema!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Para que solo se puedan poner numeros en este campo
        private void TxtNAfiliado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FrmNuevoCliente_Load(object sender, EventArgs e)
        {

            lblErrorDni.Visible = false;
            lblErrorNombre.Visible = false;
            lblErrorApellido.Visible = false;

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


            // ==========================================
            // REUTILIZACIÓN
            // ==========================================

            if (Modo == "EDITAR")
            {
                this.Text = "Editar Cliente";
                LblCliente.Text = "Modificar datos del Cliente";
                BtnAgregarC.Text = "Guardar Cambios";

                // El número de afiliado o DNI a veces conviene bloquearlos en la edición para que no los alteren
                TxtDni.ReadOnly = true;
                lblErrorDni.Visible = false;
                lblErrorNombre.Visible = false;
                lblErrorApellido.Visible = false;

                CargarDatosDelCliente(); // Método que busca en la base de datos y rellena los campos
                ValidarCamposObligatorios();
            }
            else if (Modo == "DETALLES")
            {
                this.Text = "Información del Cliente";
                LblCliente.Text = "Detalles del Cliente";

                // Ocultamos el botón de guardar porque solo es para mirar datos
                BtnAgregarC.Visible = false;

                // Bloqueamos todos tus campos para que no puedan escribir
                TxtDni.ReadOnly = true;
                TxtNombreC.ReadOnly = true;
                TxtApC.ReadOnly = true;
                TxtTel.ReadOnly = true;
                TxtEmail.ReadOnly = true;
                TxtNAfiliado.ReadOnly = true;
                CmbObraS.Enabled = false;
                numSaldo.Enabled = false;
                lblErrorDni.Visible = false;
                lblErrorNombre.Visible = false;
                lblErrorApellido.Visible = false;
                if (CmbECuenta != null) CmbECuenta.Enabled = false;

                CargarDatosDelCliente(); // Método que busca en la base de datos y rellena los campos
            }
            else
            {
                // Modo NUEVO (Título estándar)
                this.Text = "Registrar Nuevo Cliente";
                LblCliente.Text = "Agregar Nuevo Cliente";
                BtnAgregarC.Text = "Guardar";
                lblErrorDni.Visible = false;
                lblErrorNombre.Visible = false;
                lblErrorApellido.Visible = false;
            }
        }


        private bool ValidarCamposObligatorios()
        {
            // 1. Apagamos los errores anteriores y devolvemos el color a blanco
            lblErrorDni.Visible = false;
            lblErrorNombre.Visible = false;
            lblErrorApellido.Visible = false;

            TxtDni.BackColor = Color.White;
            TxtNombreC.BackColor = Color.White;
            TxtApC.BackColor = Color.White;

            bool formularioValido = true;

            // 2. Validar DNI
            if (string.IsNullOrWhiteSpace(TxtDni.Text))
            {
                lblErrorDni.Visible = true;
                TxtDni.BackColor = Color.MistyRose; // 🌟 Agregamos el color rosa
                formularioValido = false;
            }

            // 3. Validar Nombre
            if (string.IsNullOrWhiteSpace(TxtNombreC.Text))
            {
                lblErrorNombre.Visible = true;
                TxtNombreC.BackColor = Color.MistyRose; // 🌟 Agregamos el color rosa
                formularioValido = false;
            }

            // 4. Validar Apellido
            if (string.IsNullOrWhiteSpace(TxtApC.Text))
            {
                lblErrorApellido.Visible = true;
                TxtApC.BackColor = Color.MistyRose; // 🌟 Agregamos el color rosa
                formularioValido = false;
            }

            return formularioValido;
        }

        private void CargarDatosDelCliente()
        {
            // 1. Validamos que tengamos un ID válido para buscar
            if (string.IsNullOrEmpty(IdClienteSeleccionado)) return;

            // 2. Vamos a la base de datos a buscar la info de este cliente
            DataTable dtCliente = clsConsultas.ObtenerClientePorId(IdClienteSeleccionado);

            // 3. Si encontramos al cliente, rellenamos los campos de la interfaz
            if (dtCliente.Rows.Count > 0)
            {
                DataRow fila = dtCliente.Rows[0];

                TxtNAfiliado.Text = fila["NroAfiliado"].ToString();
                TxtDni.Text = fila["Dni"].ToString();
                TxtNombreC.Text = fila["Nombre"].ToString();
                TxtApC.Text = fila["Apellido"].ToString();
                TxtTel.Text = fila["Telefono"].ToString();
                TxtEmail.Text = fila["Email"].ToString();

                // Seleccionamos la obra social en el combo
                CmbObraS.Text = fila["ObraSocial"].ToString();

                // Si usás el combo de estado, seleccionamos el que corresponda
                if (CmbECuenta != null)
                {
                    CmbECuenta.Text = fila["Estado"].ToString();
                }

                // Cargamos el saldo en el NumericUpDown
                if (fila["Saldo"] != DBNull.Value)
                {
                    numSaldo.Value = Convert.ToDecimal(fila["Saldo"]);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron los datos del cliente seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtDni_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtDni.Text))
            {
                lblErrorDni.Visible = false;
                TxtDni.BackColor = Color.White;
            }
        }

        private void TxtNombreC_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtNombreC.Text))
            {
                lblErrorNombre.Visible = false;
                TxtNombreC.BackColor = Color.White;
            }
        }

        private void TxtApC_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtApC.Text))
            {
                lblErrorApellido.Visible = false;
                TxtApC.BackColor = Color.White; 
            }
        }
    }
}
