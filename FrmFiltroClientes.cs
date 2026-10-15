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
            if (this.Owner is frmCuentasCorrientes padre)
            {
                // Tomamos los filtros ingresados
                string nroAfiliado = txtNAf.Text.Trim();
                string nombre = txtNombre.Text.Trim().ToLower();
                string apellido = txtApellido.Text.Trim().ToLower();
                string obraSocial = CmbOS.SelectedItem?.ToString().Trim() ?? "";
                string estado = CmbECuenta.SelectedItem?.ToString().Trim() ?? "";
                // Si la lista del padre no tiene datos, intentamos recargarla
                if (padre.listaClientes == null || padre.listaClientes.Count == 0)
                {
                    MessageBox.Show("No hay clientes en memoria para filtrar.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Filtramos sobre la lista completa del formulario padre
                var filtrados = padre.listaClientes.Where(c =>
                {
                    // Nro Afiliado (si se escribió)
                    if (!string.IsNullOrEmpty(nroAfiliado))
                    {
                        if (string.IsNullOrEmpty(c.NroAfiliado) || !c.NroAfiliado.Contains(nroAfiliado))
                            return false;
                    }
                    // Nombre (si se escribió)
                    if (!string.IsNullOrEmpty(nombre))
                    {
                        if (string.IsNullOrEmpty(c.Nombre) || !c.Nombre.ToLower().Contains(nombre))
                            return false;
                    }
                    // Apellido (si se escribió)
                    if (!string.IsNullOrEmpty(apellido))
                    {
                        if (string.IsNullOrEmpty(c.Apellido) || !c.Apellido.ToLower().Contains(apellido))
                            return false;
                    }
                    // Obra Social (ignora si dice 'Todas', 'Ingresar...' o vacío)
                    if (!string.IsNullOrEmpty(obraSocial) &&
                        obraSocial != "Todas" &&
                        !obraSocial.StartsWith("Ingresar") &&
                        !obraSocial.StartsWith("Seleccionar"))
                    {
                        if (string.IsNullOrEmpty(c.ObraSocial) || !c.ObraSocial.Equals(obraSocial, StringComparison.OrdinalIgnoreCase))
                            return false;
                    }
                    // Estado de cuenta (ignora si dice 'Todos', 'Ingresar...' o vacío)
                    if (!string.IsNullOrEmpty(estado) &&
                        estado != "Todos" &&
                        !estado.StartsWith("Ingresar") &&
                        !estado.StartsWith("Seleccionar"))
                    {
                        string estItem = (c.Estado ?? "").Replace("í", "i").ToLower();
                        string estFiltro = estado.Replace("í", "i").ToLower();
                        if (!estItem.Contains(estFiltro))
                            return false;
                    }
                    return true;
                }).ToList();
                // Enviamos la lista filtrada al padre
                padre.ActualizarGrilla(filtrados);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void btnResetearTodo_Click(object sender, EventArgs e)
        {
            // Limpiar cajas de texto
            txtNAf.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            if (CmbOS != null && CmbOS.Items.Count > 0)
            {
                CmbOS.SelectedIndex = 0;
            }
            if (CmbECuenta != null && CmbECuenta.Items.Count > 0)
            {
                CmbECuenta.SelectedIndex = 0;
            }
            btnAplicarFiltros.Text = "Aplicar Filtros";
            // Restaurar la grilla
            if (this.Owner is frmCuentasCorrientes padre && padre.listaClientes != null)
            {
                padre.ActualizarGrilla(padre.listaClientes);
            }
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
            // Estados de cuenta
            CmbECuenta.Items.Clear();
            CmbECuenta.Items.Add("Todos");
            CmbECuenta.Items.Add("Al día");
            CmbECuenta.Items.Add("Pendiente");
            CmbECuenta.Items.Add("Vencido");
            CmbECuenta.SelectedIndex = 0; // Todos por defecto

            // Obras sociales (Carga dinámica si la lista tiene datos, o fija)
            CmbOS.Items.Clear();
            CmbOS.Items.Add("Todas");

            if (listaParaFiltrar != null && listaParaFiltrar.Count > 0)
            {
                // Extrae las obras sociales únicas de los clientes existentes
                var obrasSociales = listaParaFiltrar
                    .Where(x => !string.IsNullOrWhiteSpace(x.ObraSocial))
                    .Select(x => x.ObraSocial.Trim())
                    .Distinct()
                    .OrderBy(x => x);

                foreach (var os in obrasSociales)
                {
                    CmbOS.Items.Add(os);
                }
            }
            else
            {
                CmbOS.Items.Add("APROSS");
                CmbOS.Items.Add("PAMI");
                CmbOS.Items.Add("OSDE");
                CmbOS.Items.Add("Swiss Medical");
            }

            CmbOS.SelectedIndex = 0; // Todas por defecto
        }
    }
}
