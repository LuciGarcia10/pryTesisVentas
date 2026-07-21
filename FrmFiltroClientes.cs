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
    public partial class FrmFiltroClientes : Form
    {
        public FrmFiltroClientes()
        {
            InitializeComponent();
        }

        public List<clsCuentasC> listaParaFiltrar { get; set; }

        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            // 1. Protección de seguridad por si la lista no fue asignada
            if (listaParaFiltrar == null)
            {
                this.Close();
                return;
            }

            // 2. Consulta LINQ optimizada y segura contra valores nulos en controles
            string txtAfiliadoVal = txtNAf.Text.Trim();
            string txtNombreVal = txtNombre.Text.Trim().ToLower();
            string txtApellidoVal = txtApellido.Text.Trim().ToLower();

            var resultado = listaParaFiltrar.Where(x =>
                // Filtro por Nro Afiliado
                (string.IsNullOrWhiteSpace(txtAfiliadoVal) || (x.NroAfiliado != null && x.NroAfiliado.Contains(txtAfiliadoVal))) &&

                // Filtro por Nombre
                (string.IsNullOrWhiteSpace(txtNombreVal) || (x.Nombre != null && x.Nombre.ToLower().Contains(txtNombreVal))) &&

                // Filtro por Apellido
                (string.IsNullOrWhiteSpace(txtApellidoVal) || (x.Apellido != null && x.Apellido.ToLower().Contains(txtApellidoVal))) &&

                // Filtro por Obra Social
                (CmbOS.SelectedIndex == -1 || CmbOS.Text == "Todas" || CmbOS.Text == "Seleccionar Obra Social" || (x.ObraSocial != null && x.ObraSocial == CmbOS.Text)) &&

                // Filtro por Estado de Cuenta
                (CmbECuenta.SelectedIndex == -1 || string.IsNullOrEmpty(CmbECuenta.Text) || (x.Estado != null && x.Estado == CmbECuenta.Text))
            ).ToList();

            // 3. Notificamos al formulario padre utilizando el Owner asignado
            if (this.Owner is frmCuentasCorrientes padre)
            {
                padre.ActualizarGrilla(resultado);
            }

            // 4. Establecemos el resultado exitoso para el ShowDialog y cerramos
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnResetearTodo_Click(object sender, EventArgs e)
        {
            txtNAf.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            if (CmbECuenta != null) CmbECuenta.SelectedIndex = -1;
            if (CmbOS != null) CmbOS.SelectedIndex = -1;
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiarAf_Click(object sender, EventArgs e)
        {
            txtNAf.Clear();
        }

        private void btnLimpiarN_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
        }

        private void btnLimpiarAp_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
        }

        private void FrmFiltroClientes_Load(object sender, EventArgs e)
        {
            // 1. CARGAR ESTADOS DE CUENTA (Fijos según tus ejemplos)
            CmbECuenta.Items.Clear();
            CmbECuenta.Items.Add("Al día");
            CmbECuenta.Items.Add("Pendiente");
            CmbECuenta.Items.Add("Vencido");
            // Podés dejarlo vacío al inicio para que el usuario elija voluntariamente
            CmbECuenta.SelectedIndex = -1;

            // 2. CARGAR OBRAS SOCIALES
            CmbOS.Items.Clear();
            CmbOS.Items.Add("Todas"); // Opción por defecto para limpiar el filtro
            CmbOS.Items.Add("Apross");
            CmbOS.Items.Add("Swiss Medical");
            CmbOS.Items.Add("PAMI");
            CmbOS.Items.Add("OSDE");

            // Seleccionamos "Todas" por defecto para que no aparezca el hueco en blanco
            CmbOS.SelectedIndex = 0;
        }
    }
}
