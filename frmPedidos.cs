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
    public partial class frmPedidos : Form
    {
        public List<clsPedido> ListaCompleta { get; set; }
        public List<clsPedido> listaPedidos = new List<clsPedido>();
        public void ActualizarGrilla(List<clsPedido> lista)
        {
            dgvPedidos.DataSource = null; // Limpiamos el origen
            dgvPedidos.DataSource = lista; // Cargamos la nueva lista filtrada
            // Si la lista que llega es menor a la total, activamos el botón limpiar
            btnLimpiar.Enabled = (lista.Count < listaPedidos.Count);
        }
        public frmPedidos()
        {
            InitializeComponent();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            frmNuevoPedido ventana = new frmNuevoPedido();
            // Le decimos que use al formulario principal como centro
            ventana.StartPosition = FormStartPosition.CenterParent;
            // Al usar ShowDialog(this), el "this" le indica que el padre es el formulario de Productos
            ventana.ShowDialog(this);
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            //NUEVO: Configuramos la grilla ANTES de cargar los datos 
            dgvPedidos.AutoGenerateColumns = false; // ESTO ES CLAVE para que no se vea feo

            // 1. Creamos el Pedido 109
            clsPedido p1 = new clsPedido();
            p1.IdPedido = 109;
            p1.Fecha = DateTime.Now;
            p1.Proveedor = "Droguería del Sud";
            p1.Estado = "Recibido";

            p1.Detalles.Add(new clsDetallePedido { Producto = "Paracetamol", Cantidad = 2, Precio = 1000 });
            p1.Detalles.Add(new clsDetallePedido { Producto = "Actron 400", Cantidad = 4, Precio = 2500 });

            // 2. Creamos el Pedido 110
            clsPedido p2 = new clsPedido();
            p2.IdPedido = 110;
            p2.Fecha = DateTime.Now.AddDays(-1);
            p2.Proveedor = "Belleza S.A.";
            p2.Estado = "Pendiente";

            p2.Detalles.Add(new clsDetallePedido { Producto = "Crema Dermaglós", Cantidad = 5, Precio = 12000 });

            // 3. Guardamos y cargamos
            listaPedidos.Add(p1);
            listaPedidos.Add(p2);

            EstilizarGrilla(); // <--- Llamada clave
                               // ... tu carga de datos de prueba ...
            ActualizarGrilla(listaPedidos);
        }
        private void EstilizarGrilla()
        {
            // 1. Descongelar columnas para evitar el error de InvalidOperationException
            foreach (DataGridViewColumn col in dgvPedidos.Columns)
            {
                col.Frozen = false;
            }

            // 2. Colores de fondo y bordes generales
            dgvPedidos.BackgroundColor = Color.White;
            dgvPedidos.BorderStyle = BorderStyle.None;
            dgvPedidos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPedidos.GridColor = Color.FromArgb(240, 240, 240); // Gris muy clarito

            // 3. Estilo de los encabezados (N° Pedido, Fecha, etc.)
            dgvPedidos.EnableHeadersVisualStyles = false;
            dgvPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvPedidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 160); // Gris texto
            dgvPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPedidos.ColumnHeadersHeight = 40;

            // 4. Estilo de las filas y texto
            dgvPedidos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 250, 245); // Verde muy claro
            dgvPedidos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPedidos.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64); // Gris oscuro (más legible)
            dgvPedidos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvPedidos.RowTemplate.Height = 50; // Filas más altas

            // 5. Configuración de comportamiento y limpieza visual
            dgvPedidos.RowHeadersVisible = false; // Quita la columna gris de la izquierda
            dgvPedidos.AllowUserToAddRows = false; // Evita la fila vacía al final
            dgvPedidos.ReadOnly = true; // Evita que el usuario escriba sobre la grilla
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selecciona toda la fila

            // 6. Ajuste automático de columnas al ancho total
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 7. Ajuste específico para la columna del Ojito (si existe)
            // Cambiamos "btnVerDetalle" por el Name que le pusiste a tu columna
            if (dgvPedidos.Columns.Contains("btnVerDetalle"))
            {
                dgvPedidos.Columns["btnVerDetalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvPedidos.Columns["btnVerDetalle"].Width = 80; // Ancho fijo para el ojo
                dgvPedidos.Columns["btnVerDetalle"].DefaultCellStyle.BackColor = Color.White;
                dgvPedidos.Columns["btnVerDetalle"].DefaultCellStyle.SelectionBackColor = Color.White;
            }
        }
        private void cmbFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Creamos la instancia
            frmFiltroPedidos ventanaFiltro = new frmFiltroPedidos();

            // 2. Le pasamos la lista de productos
            if (this.listaPedidos == null)
            {
                this.listaPedidos = new List<clsPedido>();
            }
            ventanaFiltro.listaParaFiltrar = this.listaPedidos;

            // --- 3. NUEVO: Lógica de posicionamiento ---

            // Le decimos a Windows que nosotros definiremos la ubicación manualmente
            ventanaFiltro.StartPosition = FormStartPosition.Manual;

            // Calculamos el punto exacto: 
            // Tomamos la posición del ComboBox en la pantalla y le sumamos su altura (Height)
            // para que el filtro empiece justo donde termina el combo.
            Point puntoAparicion = cmbFiltrar.PointToScreen(new Point(0, cmbFiltrar.Height));

            // Si la ventana de filtros es más ancha que el combo, podés restarle un poco a la X 
            // para que quede alineada a la derecha o centrada. Por ahora probá así:
            ventanaFiltro.Location = puntoAparicion;

            // 4. Abrimos la ventana
            ventanaFiltro.ShowDialog();
        }

        private void cmbFiltrar_MouseClick(object sender, MouseEventArgs e)
        {
            frmFiltroPedidos ventanaFiltro = new frmFiltroPedidos();
            ventanaFiltro.listaParaFiltrar = this.listaPedidos;
            ventanaFiltro.StartPosition = FormStartPosition.Manual;

            Point puntoAparicion = cmbFiltrar.PointToScreen(new Point(0, cmbFiltrar.Height));
            ventanaFiltro.Location = puntoAparicion;

            ventanaFiltro.ShowDialog();
        }

        private void cmbFiltrar_DropDown(object sender, EventArgs e)
        {
            // Esto evita que se abra la lista del combo y abre directamente tu ventana pro
            SendKeys.Send("{ESC}");
            AbrirFiltro(); // Meté tu lógica de apertura en un método aparte
        }
        private void AbrirFiltro()
        {
            // 1. Creamos la instancia de la ventana de filtros
            frmFiltroPedidos ventanaFiltro = new frmFiltroPedidos();

            // 2. Le pasamos la lista de pedidos (asegurándonos que no sea null)
            if (this.listaPedidos == null)
            {
                this.listaPedidos = new List<clsPedido>();
            }
            ventanaFiltro.listaParaFiltrar = this.listaPedidos;

            // 3. Configuración de posición (para que aparezca debajo del combo)
            ventanaFiltro.StartPosition = FormStartPosition.Manual;
            Point puntoAparicion = cmbFiltrar.PointToScreen(new Point(0, cmbFiltrar.Height));
            ventanaFiltro.Location = puntoAparicion;

            // 4. Mostramos la ventana
            ventanaFiltro.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que la lista original no esté vacía
            if (listaPedidos != null && listaPedidos.Count > 0)
            {
                // 2. Volvemos a mostrar la lista completa sin filtros
                ActualizarGrilla(listaPedidos);

                // 3. Opcional: Resetear el texto del combo de filtrar para que se vea limpio
                cmbFiltrar.Text = "Filtrar";

                // Mensaje chiquito en la barra de estado (opcional)
                // MessageBox.Show("Filtros quitados. Mostrando todos los pedidos.");
            }
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Verificamos que el clic sea en la columna del ojito (supongamos que es la columna 5)
            // También validamos que no sea el encabezado (e.RowIndex >= 0)
            if (e.RowIndex >= 0 && dgvPedidos.Columns[e.ColumnIndex].Name == "btnVerDetalle")
            {
                clsPedido pedidoSeleccionado = (clsPedido)dgvPedidos.Rows[e.RowIndex].DataBoundItem;
                // 3. Creamos la instancia de la ventana de detalle
                frmDetallePedido ventanaDetalle = new frmDetallePedido();
                // --- ACÁ VAN LAS DOS LÍNEAS CLAVE ---
                ventanaDetalle.PedidoSeleccionado = pedidoSeleccionado; // Para que muestre el que clickeaste
                ventanaDetalle.ListaCompleta = this.listaPedidos;      // <--- ESTA ES LA QUE BUSCABAS
                ventanaDetalle.StartPosition = FormStartPosition.CenterParent;
                ventanaDetalle.ShowDialog(this);
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

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmCuentasCorrientes frm = new frmCuentasCorrientes();
            frm.ShowDialog();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            frmAyuda frm = new frmAyuda();
            frm.ShowDialog();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FrmPerfil frm = new FrmPerfil();
            frm.ShowDialog();
        }
    }
}
