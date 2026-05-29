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
    public partial class frmFiltroVentas : Form
    {
        internal List<Producto> listaParaFiltrar;

        public frmFiltroVentas()
        {
            InitializeComponent();
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
        }

        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            // 1. Validamos que la lista no sea nula para evitar errores
            if (listaParaFiltrar == null) { this.Close(); return; }

            // 2. Tomamos los valores de los controles
            // Usamos .Date para ignorar la hora y filtrar solo por día
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            // Verificamos si eligió algo en el combo o si quedó el texto por defecto
            string catSeleccionada = cmbCategoria.Text;
            bool filtrarPorCategoria = !string.IsNullOrEmpty(catSeleccionada) && catSeleccionada != "Elegir categoría...";

            string nombreBusqueda = txtNombre.Text.ToLower().Trim();

            // 3. Filtrado con LINQ (Súper potente)
            var listaFiltrada = listaParaFiltrar.Where(x =>
                // Filtro de fecha
                (x.FechaVencimiento.Date >= desde && x.FechaVencimiento.Date <= hasta) &&
                // Filtro de categoría (si seleccionó una)
                (!filtrarPorCategoria || x.Categoria == catSeleccionada) &&
                // Filtro de nombre (si escribió algo)
                (string.IsNullOrEmpty(nombreBusqueda) || nombreBusqueda == "elegir el nombre..." || x.Nombre.ToLower().Contains(nombreBusqueda))
            ).ToList();

            // 4. Enviamos la lista al formulario principal
            frmProductos formPadre = (frmProductos)Application.OpenForms["frmProductos"];
            if (formPadre != null)
            {
                formPadre.ActualizarGrilla(listaFiltrada);
            }

            this.Close();
        }

        private void btnEstasemana_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now; // Hoy
            dtpHasta.Value = DateTime.Now.AddDays(7); // 7 días hacia adelante
        }

        private void btnEstemes_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpHasta.Value = dtpDesde.Value.AddMonths(1).AddDays(-1); // Último día del mes
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

        private void lblNombre_Click(object sender, EventArgs e)
        {
            // Al tocar el texto de ayuda, mandamos el foco al TextBox para poder escribir
            txtNombre.Focus();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            // Apenas el usuario hace clic o llega con el TAB, ocultamos el label
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

        private void frmFiltroVentas_Load(object sender, EventArgs e)
        {

        }
    }
}
