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
    public partial class frmFiltroPedidos : Form
    {
        public List<clsPedido> listaParaFiltrar { get; set; }
        public frmFiltroPedidos()
        {
            InitializeComponent();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            // Si el cuadro de texto NO está vacío, ocultamos el label de ayuda
            if (txtNombre.Text.Trim().Length > 0)
            {
                lblNombre.Visible = false;
            }
            else
            {
                // Si borra todo, volvemos a mostrar el label "Elegir el nombre..."
                lblNombre.Visible = true;
            }
        }

        private void lblEscribirNombre_Click(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            lblNombre.Visible = false;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            // Si sale del cuadro y NO escribió nada, mostramos el label de nuevo
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblNombre.Visible = true;
            }
        }

        private void txtIngresarNumero_TextChanged(object sender, EventArgs e)
        {
            if (txtIngresarNumero.Text.Trim().Length > 0)
            {
                lblNombre.Visible = false;
            }
            else
            {
                // Si borra todo, volvemos a mostrar el label "Elegir el nombre..."
                lblIngresarNumero.Visible = true;
            }
        }

        private void txtIngresarNumero_Enter(object sender, EventArgs e)
        {
            lblIngresarNumero.Visible = false;
        }

        private void txtIngresarNumero_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblIngresarNumero.Visible = true;
            }
        }

        private void lblIngresarNumero_Click(object sender, EventArgs e)
        {
            txtIngresarNumero.Focus();
        }

        private void lblResetearFecha_Click(object sender, EventArgs e)
        {
            // Volvemos a un rango amplio por defecto
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;
        }

        private void lblResetearNombre_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            lblEscribirNombre.Visible = true;
        }

        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            if (listaParaFiltrar == null) return;

            string busquedaNombre = txtNombre.Text.ToLower().Trim();
            string busquedaNumero = txtIngresarNumero.Text.Trim();
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            var filtrados = listaParaFiltrar.Where(p =>
                (p.Fecha.Date >= desde && p.Fecha.Date <= hasta) &&
                (string.IsNullOrEmpty(busquedaNombre) || p.Proveedor.ToLower().Contains(busquedaNombre)) &&
                (string.IsNullOrEmpty(busquedaNumero) || p.IdPedido.ToString().Contains(busquedaNumero))
            ).ToList();

            frmPedidos padre = (frmPedidos)Application.OpenForms["frmPedidos"];
            if (padre != null)
            {
                padre.ActualizarGrilla(filtrados);
            }

            this.Close();
        }

        private void btnResetearTodo_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtIngresarNumero.Clear();
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;
            lblEscribirNombre.Visible = true;
            lblIngresarNumero.Visible = true;
        }
    }
}
