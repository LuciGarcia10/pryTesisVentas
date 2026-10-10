using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pryTesisVentas
{
    public partial class frmPedidos : Form
    {
        public List<clsPedido> ListaCompleta { get; set; }
        public List<clsPedido> listaPedidos = new List<clsPedido>();
        public void ActualizarGrilla(List<clsPedido> lista)
        {
            // Forzamos que NO cree columnas automáticas (evita que aparezcan columnas extras a la derecha)
            dgvPedidos.AutoGenerateColumns = false;

            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = lista;

            btnLimpiar.Enabled = (lista != null && listaPedidos != null && lista.Count < listaPedidos.Count);
        }
        public frmPedidos()
        {
            InitializeComponent();
            CargarPedidosDesdeBD();
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
            EstilizarGrilla(); 
            ActualizarGrilla(listaPedidos);
        }

        private void CargarPedidosDesdeBD()
        {
            listaPedidos.Clear();

            // Consultamos la tabla Pedidos uniendo con Proveedores y Estados (si existen)
            string query = @"
             SELECT p.IdPedido, 
               p.FechaPedido, 
               ISNULL(prov.RazonSocial, 'Sin Proveedor') AS Proveedor, 
               CASE 
                   WHEN p.IdEstado = 1 THEN 'Pendiente'
                   WHEN p.IdEstado = 2 THEN 'Recibido'
                   ELSE 'Pendiente'
               END AS Estado,
               p.Total,
               ISNULL((SELECT SUM(dp.Cantidad) FROM DetallePedido dp WHERE dp.IdPedido = p.IdPedido), 0) AS CantidadTotal
            FROM Pedidos p
            LEFT JOIN Proveedores prov ON p.IdProveedor = prov.IdProveedor
            ORDER BY p.IdPedido ASC";

            using (SqlConnection conexion = new SqlConnection(clsConsultas.cadena))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader lector = cmd.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                clsPedido pedido = new clsPedido
                                {
                                    IdPedido = Convert.ToInt32(lector["IdPedido"]),
                                    Fecha = lector["FechaPedido"] != DBNull.Value ? Convert.ToDateTime(lector["FechaPedido"]) : DateTime.Now,
                                    Proveedor = lector["Proveedor"].ToString(),
                                    Estado = lector["Estado"].ToString(),
                                    Total = lector["Total"] != DBNull.Value ? Convert.ToDecimal(lector["Total"]) : 0,
                                    CantidadDeProductos = Convert.ToInt32(lector["CantidadTotal"])
                                };

                                listaPedidos.Add(pedido);
                            }
                        }
                    }

                    // Actualizamos la grilla con los pedidos reales (1, 2, 3...)
                    ActualizarGrilla(listaPedidos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
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

            // 7. Ajuste específico para la columna del Ojito
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

            // --- 3.Lógica de posicionamiento ---

            // Le decimos a Windows que nosotros definiremos la ubicación manualmente
            ventanaFiltro.StartPosition = FormStartPosition.Manual;

            // Calculamos el punto exacto: 
            // Tomamos la posición del ComboBox en la pantalla y le sumamos su altura (Height)
            // para que el filtro empiece justo donde termina el combo.
            Point puntoAparicion = cmbFiltrar.PointToScreen(new Point(0, cmbFiltrar.Height));

            // Si la ventana de filtros es más ancha que el combo, podés restarle un poco a la X 
            // para que quede alineada a la derecha o centrada.
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
            // Verificamos que no sea el encabezado y que sea la columna del ojito
            if (e.RowIndex >= 0 && dgvPedidos.Columns[e.ColumnIndex].Name == "btnVerDetalle")
            {
                clsPedido pedidoSeleccionado = null;

                // Intentamos obtenerlo de DataBoundItem si usas DataSource
                if (dgvPedidos.Rows[e.RowIndex].DataBoundItem is clsPedido item)
                {
                    pedidoSeleccionado = item;
                }
                else
                {
                    // Respaldo seguro: Si se cargó manualmente con Rows.Add(), leemos la celda directamente
                    // (Ajustá "colNumeroPedido" o el índice de celda según el nombre de tu columna de ID)
                    var valorCelda = dgvPedidos.Rows[e.RowIndex].Cells["colNumeroPedido"]?.Value
                                  ?? dgvPedidos.Rows[e.RowIndex].Cells[0].Value;

                    if (valorCelda != null && int.TryParse(valorCelda.ToString(), out int idObtenido))
                    {
                        pedidoSeleccionado = new clsPedido { IdPedido = idObtenido };
                    }
                }

                if (pedidoSeleccionado == null) return;

                // Abrimos la ventana de detalle
                using (frmDetallePedido ventanaDetalle = new frmDetallePedido())
                {
                    ventanaDetalle.PedidoSeleccionado = pedidoSeleccionado;
                    ventanaDetalle.ListaCompleta = this.listaPedidos;
                    ventanaDetalle.StartPosition = FormStartPosition.CenterParent;
                    ventanaDetalle.ShowDialog(this);
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

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            frmEstadisticas frm = new frmEstadisticas();
            frm.ShowDialog();
        }

        private void txtBuscarArriba_TextChanged(object sender, EventArgs e)
        {
            string criterio = txtBuscarArriba.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(criterio))
            {
                ActualizarGrilla(listaPedidos);
            }
            else
            {
                var filtrados = listaPedidos.Where(p =>
                    p.IdPedido.ToString().Contains(criterio) ||
                    p.Proveedor.ToLower().Contains(criterio) ||
                    p.Estado.ToLower().Contains(criterio)
                ).ToList();

                ActualizarGrilla(filtrados);
            }
        }
    }
}
