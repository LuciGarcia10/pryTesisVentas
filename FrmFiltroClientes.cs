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
            // Filtramos de un solo tirón adaptando el NroAfiliado y usando CmbECuenta
            var resultado = listaParaFiltrar.Where(x =>
                (string.IsNullOrWhiteSpace(txtNAf.Text) || x.NroAfiliado.ToString().Contains(txtNAf.Text.Trim())) &&
                (string.IsNullOrWhiteSpace(txtNombre.Text) || (x.Nombre != null && x.Nombre.ToLower().Contains(txtNombre.Text.Trim().ToLower()))) &&
                (string.IsNullOrWhiteSpace(txtApellido.Text) || (x.Apellido != null && x.Apellido.ToLower().Contains(txtApellido.Text.Trim().ToLower()))) &&
                (CmbOS.SelectedIndex == -1 || CmbOS.Text == "Todas" || CmbOS.Text == "Seleccionar Obra Social" || (x.ObraSocial != null && x.ObraSocial == CmbOS.Text)) &&
                (CmbECuenta.SelectedIndex == -1 || string.IsNullOrEmpty(CmbECuenta.Text) || (x.Estado != null && x.Estado == CmbECuenta.Text))
            ).ToList();

            // Enviamos el resultado al padre (frmCuentasCorrientes) y cerramos
            if (this.Owner is frmCuentasCorrientes padre) padre.ActualizarGrilla(resultado);
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
    }
}
