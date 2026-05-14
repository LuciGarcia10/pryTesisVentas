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
            // 1. Empezamos con la lista que recibimos
            var resultado = listaParaFiltrar;

            // 2. Filtro por Obra Social (Validamos que no sea nulo y que no sea la opción por defecto)
            if (CmbOS.SelectedIndex != -1 && CmbOS.Text != "Todas" && !string.IsNullOrEmpty(CmbOS.Text))
            {
                resultado = resultado.Where(x => x.ObraSocial == CmbOS.Text).ToList();
            }

            // 3. Filtro por Nombre (ignora mayúsculas/minúsculas)
            if (!string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                resultado = resultado.Where(x => x.Nombre.ToLower().Contains(txtNombre.Text.ToLower())).ToList();
            }

            // 4. DEVOLVER LOS DATOS Y REFRESCAR
            if (this.Owner is frmCuentasCorrientes padre)
            {
                // Llamamos al método del padre pasándole la nueva lista filtrada
                padre.ActualizarGrilla(resultado);
            }
            this.Close();
        }

        private void lblResetearNumero_Click(object sender, EventArgs e)
        {
            txtIngresarNumero.Clear();
        }

        private void lblResetearNombre_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
        }

        private void lblResetearAp_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
        }

        private void btnResetearTodo_Click(object sender, EventArgs e)
        {
            txtIngresarNumero.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            if (CmbECuenta != null) CmbECuenta.SelectedIndex = -1;
            if (CmbOS != null) CmbOS.SelectedIndex = -1;
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
