using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTesisVentas
{
    public partial class frmCuentasCorrientes : Form
    {
        // Listas para manejar los datos en memoria
        public List<clsCuentasC> listaCuentas = new List<clsCuentasC>();
        public frmCuentasCorrientes()
        {
            InitializeComponent();
        }


        private void frmCuentasCorrientes_Load(object sender, EventArgs e)/////
        {
            // 1.Configuramos la grilla antes de cargar datos
            dgvCuentasC.AutoGenerateColumns = false;
            EstilizarGrilla();

            // 2. Carga de datos de prueba (Simulando la base de datos)
            CargarDatosPrueba();

            // 3. Mostramos los datos
            ActualizarGrilla(listaCuentas);


        }
        private void CargarDatosPrueba()
        {
            listaCuentas.Clear();
            listaCuentas.Add(new clsCuentasC { IdAfiliado = 1001, Nombre = "Juan", Apellido = "Pérez", ObraSocial = "Apross", Estado = "Al dia", Saldo = 0 });
            listaCuentas.Add(new clsCuentasC { IdAfiliado = 1002, Nombre = "María", Apellido = "García", ObraSocial = "Swiss Medical", Estado = "Pendiente", Saldo = 15400.50m });
            listaCuentas.Add(new clsCuentasC { IdAfiliado = 1003, Nombre = "Carlos", Apellido = " López", ObraSocial = "PAMI", Estado = "Vencido", Saldo = 8900.00m });
        }

        public void ActualizarGrilla(List<clsCuentasC> lista)
        {
            dgvCuentasC.DataSource = null;
            dgvCuentasC.DataSource = lista;

            // Habilitar botón limpiar si hay un filtro aplicado
            if (btnLimpiar != null)
                btnLimpiar.Enabled = (lista.Count < listaCuentas.Count);
        }

        private void EstilizarGrilla()
        {
            // Colores y bordes
            dgvCuentasC.BackgroundColor = Color.White;
            dgvCuentasC.BorderStyle = BorderStyle.None;
            dgvCuentasC.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCuentasC.GridColor = Color.FromArgb(240, 240, 240);

            // Estilo de encabezados
            dgvCuentasC.EnableHeadersVisualStyles = false;
            dgvCuentasC.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvCuentasC.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 160);
            dgvCuentasC.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCuentasC.ColumnHeadersHeight = 40;

            // Selección y filas
            dgvCuentasC.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 250, 245);
            dgvCuentasC.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCuentasC.RowTemplate.Height = 50;
            dgvCuentasC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCuentasC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {

            using (FrmNuevoCliente ventana = new FrmNuevoCliente())
            {
                ventana.StartPosition = FormStartPosition.CenterParent;
                if (ventana.ShowDialog() == DialogResult.OK)
                {
                    //CargarDatos(); 
                    ActualizarGrilla(listaCuentas);
                }
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            frmInicio frm = new frmInicio();
            frm.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            //frmVentas frm = new frmVentas();
            //frm.ShowDialog();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            frmPedidos frm = new frmPedidos();
            frm.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.ShowDialog();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            frmAyuda frm = new frmAyuda();
            frm.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla(listaCuentas);
        }

        private void pctDesplegar_Click(object sender, EventArgs e)
        {
            FrmFiltroClientes ventanaFiltro = new FrmFiltroClientes();
            // Pasamos la lista actual de este formulario
            ventanaFiltro.listaParaFiltrar = this.listaCuentas;

            ventanaFiltro.StartPosition = FormStartPosition.Manual;
            Point puntoAparicion = pctDesplegar.PointToScreen(new Point(0, pctDesplegar.Height));
            ventanaFiltro.Location = puntoAparicion;

            ventanaFiltro.ShowDialog(this);
        }
    }
}
