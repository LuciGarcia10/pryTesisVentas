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
       

        public frmCuentasCorrientes()
        {
            InitializeComponent();
        }


        private void frmCuentasCorrientes_Load(object sender, EventArgs e)/////
        {
            // 1. Configuramos los aspectos visuales de la grilla antes de cargar los datos
            dgvCuentasC.AutoGenerateColumns = false;
            EstilizarGrilla();

            // 2. Carga y muestra de datos REALES desde SQL Server
            CargarDatosDesdeBase();
        }

        private void CargarDatosDesdeBase()
        {
            // Definimos la consulta a tu tabla real de Cuentas Corrientes
            // Asegúrate de que los nombres de las columnas en el diseñador (DataPropertyName) coincidan con estos campos
            string consulta = "SELECT IdCliente, NroAfiliado, Nombre, Apellido, ObraSocial, Estado, Saldo FROM Clientes";

            // Llamamos a la función estática que lee la conexión directa con el punto (.)
            clsConsultas.LlenarGrid(consulta, dgvCuentasC);

            // Habilitar o deshabilitar botón limpiar según corresponda
            if (btnLimpiar != null)
                btnLimpiar.Enabled = false; // Inicialmente cargado sin filtros
        }
        public void ActualizarGrilla(List<clsCuentasC> lista)
        {
            // Mantenemos esta función por si tu ventana de filtros (FrmFiltroClientes) te devuelve una lista filtrada en memoria
            dgvCuentasC.DataSource = null;
            dgvCuentasC.DataSource = lista;

            if (btnLimpiar != null)
                btnLimpiar.Enabled = true; // Si se fuerza una lista manual, habilitamos limpiar para regresar a la base
        }

        private void ConfigurarColumnasAcciones()
        {
            // las otras columnas de datos (DNI, Nombre, etc.) 

            //Boton VER
            DataGridViewImageColumn colVer = new DataGridViewImageColumn();
            colVer.Name = "btnVer";
            colVer.HeaderText = "Acciones"; // Título de la sección
            colVer.Image = Properties.Resources.Lupita; // Usa tus recursos
            colVer.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colVer.Width = 40;
            dgvCuentasC.Columns.Add(colVer);

            //Boton EDITAR
            DataGridViewImageColumn colEditar = new DataGridViewImageColumn();
            colEditar.Name = "btnEditar";
            colEditar.HeaderText = ""; // Vacío para que parezca la misma sección
            colEditar.Image = Properties.Resources.ptbEditar; // Asegúrate de tener este recurso
            colEditar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colEditar.Width = 40;
            dgvCuentasC.Columns.Add(colEditar);

            //Boton ELIMINAR
            DataGridViewImageColumn colEliminar = new DataGridViewImageColumn();
            colEliminar.Name = "btnEliminar";
            colEliminar.HeaderText = "";
            colEliminar.Image = Properties.Resources.ptbBorrar; //
            colEliminar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colEliminar.Width = 40;
            dgvCuentasC.Columns.Add(colEliminar);
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
                    // Si se registra un cliente con éxito, refrescamos directamente desde SQL Server
                    CargarDatosDesdeBase();
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
            frmVentas frm = new frmVentas();
            frm.ShowDialog();
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
            // Al limpiar los filtros, volvemos a consultar el estado actual de la base de datos
            CargarDatosDesdeBase();
        }

        private void pctDesplegar_Click(object sender, EventArgs e)
        {
            FrmFiltroClientes ventanaFiltro = new FrmFiltroClientes();

            // Si tu ventana de filtros aún requiere una lista base para procesar en memoria,
            // podemos convertir el DataSource actual de la grilla (DataTable) a Lista, o pasarle una nueva consulta.
            // Para mantener compatibilidad con tu código actual:
            if (dgvCuentasC.DataSource is List<clsCuentasC> listaActual)
            {
                ventanaFiltro.listaParaFiltrar = listaActual;
            }

            ventanaFiltro.StartPosition = FormStartPosition.Manual;
            Point puntoAparicion = pctDesplegar.PointToScreen(new Point(0, pctDesplegar.Height));
            ventanaFiltro.Location = puntoAparicion;

            ventanaFiltro.ShowDialog(this);
        }

        private void dgvCuentasC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCuentasC.Columns[e.ColumnIndex].Name == "ColAcciones")
            {
                // Obtenemos la posición del clic relativa a la celda
                var relativeX = dgvCuentasC.PointToClient(Cursor.Position).X - dgvCuentasC.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;

                // Definimos rangos aproximados según el ancho de tus iconos (ej: 30px cada uno)
                if (relativeX > 0 && relativeX <= 35)
                {
                    MessageBox.Show("Clic en VER");
                }
                else if (relativeX > 35 && relativeX <= 70)
                {
                    MessageBox.Show("Clic en EDITAR");
                }
                else if (relativeX > 70)
                {
                    MessageBox.Show("Clic en BORRAR");
                }
            }
        }

        private void dgvCuentasC_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Modificado para que responda tanto si se llama "ClmAcciones" o "ColAcciones" en las propiedades de la grilla
            if (e.RowIndex >= 0 && (dgvCuentasC.Columns[e.ColumnIndex].Name == "ClmAcciones" || dgvCuentasC.Columns[e.ColumnIndex].Name == "ColAcciones"))
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                int tamañoIcono = 20;

                Image ver = Properties.Resources.Lupita;
                Image editar = Properties.Resources.ptbEditar;
                Image borrar = Properties.Resources.ptbBorrar;

                int espacioEntreIconos = 10;
                int xVer = e.CellBounds.Left + 15;
                int xEditar = xVer + tamañoIcono + espacioEntreIconos;
                int xBorrar = xEditar + tamañoIcono + espacioEntreIconos;

                int y = e.CellBounds.Top + (e.CellBounds.Height - tamañoIcono) / 2;

                e.Graphics.DrawImage(ver, new Rectangle(xVer, y, tamañoIcono, tamañoIcono));
                e.Graphics.DrawImage(editar, new Rectangle(xEditar, y, tamañoIcono, tamañoIcono));
                e.Graphics.DrawImage(borrar, new Rectangle(xBorrar, y, tamañoIcono, tamañoIcono));

                e.Handled = true;
            }
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FrmPerfil frm = new FrmPerfil();
            frm.ShowDialog();
        }
    }
    
}
