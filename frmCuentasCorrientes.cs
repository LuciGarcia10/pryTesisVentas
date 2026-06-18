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

            // Acciones
            ///////////////////////////dgvCuentasC.Columns["Acciones"].DefaultCellStyle.NullValue = null;

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
            if (e.RowIndex >= 0 && dgvCuentasC.Columns[e.ColumnIndex].Name == "ClmAcciones")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // 1. Definimos un tamaño estándar para los iconos (20x20 o 18x18)
                int tamañoIcono = 20;

                // 2. Cargamos las imágenes
                Image ver = Properties.Resources.Lupita;
                Image editar = Properties.Resources.ptbEditar;
                Image borrar = Properties.Resources.ptbBorrar;

                // 3. Calculamos posiciones horizontales con el nuevo tamaño fijo
                // Ajustamos el margen para que queden centradas en la columna
                int espacioEntreIconos = 10;
                int xVer = e.CellBounds.Left + 15; // Ajusta este 15 para centrar el bloque
                int xEditar = xVer + tamañoIcono + espacioEntreIconos;
                int xBorrar = xEditar + tamañoIcono + espacioEntreIconos;

                // 4. Calculamos posición vertical centrada
                int y = e.CellBounds.Top + (e.CellBounds.Height - tamañoIcono) / 2;

                // 5. DIBUJAMOS con el tamaño forzado (tamañoIcono, tamañoIcono)
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
