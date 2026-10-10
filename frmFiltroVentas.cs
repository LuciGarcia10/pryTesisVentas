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
        public List<Producto> listaResultado { get; set; } = new List<Producto>();

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
            // Validamos que la lista no sea nula
            if (listaParaFiltrar == null) { this.Close(); return; }

            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            // Verificamos categoría con Trim()
            string catSeleccionada = cmbCategoria.Text != null ? cmbCategoria.Text.Trim() : "";
            bool filtrarPorCategoria = !string.IsNullOrEmpty(catSeleccionada)
                                       && !catSeleccionada.Equals("Elegir categoría...", StringComparison.OrdinalIgnoreCase)
                                       && !catSeleccionada.Equals("Todas", StringComparison.OrdinalIgnoreCase);

            // Verificamos búsqueda de nombre
            string nombreBusqueda = txtNombre.Text.Trim().ToLower();
            bool filtrarPorNombre = !string.IsNullOrEmpty(nombreBusqueda)
                                    && nombreBusqueda != "elegir el nombre..."
                                    && nombreBusqueda != "escribir el nombre...";

            // Filtrado en memoria
            var listaFiltrada = listaParaFiltrar.Where(x =>
                // Filtro de categoría
                (!filtrarPorCategoria || (x.Categoria != null && x.Categoria.Trim().Equals(catSeleccionada, StringComparison.OrdinalIgnoreCase))) &&

                // Filtro de nombre
                (!filtrarPorNombre || (x.Nombre != null && x.Nombre.ToLower().Contains(nombreBusqueda)))
            ).ToList();

            // Guardamos en la propiedad de resultado
            this.listaResultado = listaFiltrada;

            // Si se abrió desde frmVentas, lo actualizamos directamente
            frmVentas formVentas = (frmVentas)Application.OpenForms["frmVentas"];
            if (formVentas != null)
            {
                formVentas.MostrarEnGrilla(listaFiltrada);
            }

            // Si también se usa desde frmProductos:
            frmProductos formProd = (frmProductos)Application.OpenForms["frmProductos"];
            if (formProd != null)
            {
                formProd.ActualizarGrilla(listaFiltrada);
            }

            this.DialogResult = DialogResult.OK;
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

        private void btnResetearTodo_Click(object sender, EventArgs e)
        {
            // Limpiamos visualmente los controles del formulario
            LimpiarTodosLosFiltros();

            // La lista de resultado vuelve a ser la lista completa original sin filtros
            this.listaResultado = new List<Producto>(this.listaParaFiltrar);

            // (Opcional recomendado) Si quieres que al resetear todo se cierre y aplique el reseteo en la grilla:
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void LimpiarTodosLosFiltros()
        {
            // 1. Restablecer fechas a un rango por defecto (por ejemplo, el último año o fechas estándar)
            dtpDesde.Value = DateTime.Today.AddYears(-1);
            dtpHasta.Value = DateTime.Today;

            // 2. Restablecer el ComboBox a la primera opción ("Elegir categoría..." o "Todas")
            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = 0;
            }

            // 3. Limpiar la caja de texto del nombre
            txtNombre.Clear(); // o txtNombre.Text = "";
        }

        private void lblResetearFecha_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddYears(-1);
            dtpHasta.Value = DateTime.Today;
        }

        private void lblResetearCategoria_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = 0;
            }
        }

        private void lblResetearNombre_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
        }
    }
}
