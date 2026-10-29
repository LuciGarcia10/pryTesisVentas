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
            ventana.StartPosition = FormStartPosition.CenterParent;
            if (ventana.ShowDialog(this) == DialogResult.OK)
            {
                CargarPedidosDesdeBD();
            }
        }
        private void ConfigurarColumnaBotonRecibido()
        {
            if (!dgvPedidos.Columns.Contains("btnRecibir"))
            {
                DataGridViewButtonColumn colBoton = new DataGridViewButtonColumn();
                colBoton.Name = "btnRecibir";
                colBoton.HeaderText = "Recepción";
                colBoton.FlatStyle = FlatStyle.Flat;
                colBoton.Width = 110;
                colBoton.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Estilo base
                colBoton.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                colBoton.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvPedidos.Columns.Add(colBoton);
            }
        }
        private void frmPedidos_Load(object sender, EventArgs e)
        {
            ConfigurarColumnaBotonRecibido();
            EstilizarGrilla();
            CargarPedidosDesdeBD();
            frmPedidos_Resize(sender, e);
            pnlEstadisticas.Visible = (frmIngresar.RolSesion == "Administrador");
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
            ORDER BY p.IdPedido DESC";

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
            foreach (DataGridViewColumn col in dgvPedidos.Columns)
            {
                col.Frozen = false;
            }

            dgvPedidos.BackgroundColor = Color.White;
            dgvPedidos.BorderStyle = BorderStyle.None;
            dgvPedidos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPedidos.GridColor = Color.FromArgb(240, 240, 240);

            dgvPedidos.EnableHeadersVisualStyles = false;
            dgvPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvPedidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 160);
            dgvPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPedidos.ColumnHeadersHeight = 40;

            dgvPedidos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 250, 245);
            dgvPedidos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPedidos.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvPedidos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvPedidos.RowTemplate.Height = 50;

            dgvPedidos.RowHeadersVisible = false;
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.ReadOnly = false; // Debe ser false para permitir hacer clic en el botón de la celda

            // Ponemos todas las columnas existentes como ReadOnly excepto los botones
            foreach (DataGridViewColumn col in dgvPedidos.Columns)
            {
                if (col.Name != "btnRecibir" && col.Name != "btnVerDetalle")
                {
                    col.ReadOnly = true;
                }
            }

            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvPedidos.Columns.Contains("btnVerDetalle"))
            {
                dgvPedidos.Columns["btnVerDetalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvPedidos.Columns["btnVerDetalle"].Width = 80;
                dgvPedidos.Columns["btnVerDetalle"].DefaultCellStyle.BackColor = Color.White;
                dgvPedidos.Columns["btnVerDetalle"].DefaultCellStyle.SelectionBackColor = Color.White;
            }

            if (dgvPedidos.Columns.Contains("btnRecibir"))
            {
                dgvPedidos.Columns["btnRecibir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvPedidos.Columns["btnRecibir"].Width = 110;
            }
            dgvPedidos.ShowCellToolTips = false;
            dgvPedidos.StandardTab = true;
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
            SendKeys.Send("{ESC}");
            AbrirFiltro(); // Meté tu lógica de apertura en un método aparte
        }
        private void AbrirFiltro()
        {
            frmFiltroPedidos ventanaFiltro = new frmFiltroPedidos();
            if (this.listaPedidos == null)
            {
                this.listaPedidos = new List<clsPedido>();
            }
            ventanaFiltro.listaParaFiltrar = this.listaPedidos;
            ventanaFiltro.StartPosition = FormStartPosition.Manual;
            Point puntoAparicion = cmbFiltrar.PointToScreen(new Point(0, cmbFiltrar.Height));
            ventanaFiltro.Location = puntoAparicion;
            ventanaFiltro.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (listaPedidos != null && listaPedidos.Count > 0)
            {
                ActualizarGrilla(listaPedidos);
                cmbFiltrar.Text = "Filtrar";
            }
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colNombre = dgvPedidos.Columns[e.ColumnIndex].Name;

            // 1. Clic en VER DETALLE (Ojito)
            if (colNombre == "btnVerDetalle")
            {
                clsPedido pedidoSeleccionado = dgvPedidos.Rows[e.RowIndex].DataBoundItem as clsPedido;

                if (pedidoSeleccionado == null)
                {
                    var valorCelda = dgvPedidos.Rows[e.RowIndex].Cells["colNumeroPedido"]?.Value
                                  ?? dgvPedidos.Rows[e.RowIndex].Cells[0].Value;

                    if (valorCelda != null && int.TryParse(valorCelda.ToString(), out int idObtenido))
                    {
                        pedidoSeleccionado = new clsPedido { IdPedido = idObtenido };
                    }
                }

                if (pedidoSeleccionado == null) return;

                using (frmDetallePedido ventanaDetalle = new frmDetallePedido())
                {
                    ventanaDetalle.PedidoSeleccionado = pedidoSeleccionado;
                    ventanaDetalle.ListaCompleta = this.listaPedidos;
                    ventanaDetalle.StartPosition = FormStartPosition.CenterParent;
                    ventanaDetalle.ShowDialog(this);
                }
            }

            // 2. Clic en BOTÓN RECIBIR
            if (colNombre == "btnRecibir")
            {
                clsPedido pedidoSeleccionado = dgvPedidos.Rows[e.RowIndex].DataBoundItem as clsPedido;
                if (pedidoSeleccionado == null) return;

                if (pedidoSeleccionado.Estado == "Recibido")
                {
                    MessageBox.Show("Este pedido ya fue recibido previamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult res = MessageBox.Show(
                    $"¿Desea confirmar la recepción del Pedido N° {pedidoSeleccionado.IdPedido}?\nSe actualizará el stock de los productos ingresados en el inventario.",
                    "Confirmar Recepción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (res == DialogResult.Yes)
                {
                    RegistrarRecepcionPedido(pedidoSeleccionado.IdPedido);
                }
            }
        }
        private void RegistrarRecepcionPedido(int idPedido)
        {
            // Cambia el estado a 2 (Recibido)
            string queryPedido = "UPDATE Pedidos SET IdEstado = 2 WHERE IdPedido = @IdPedido AND IdEstado = 1";

            // Suma la cantidad comprada al stock de cada producto
            string queryStock = @"
                UPDATE prod
                SET prod.Stock = prod.Stock + dp.Cantidad
                FROM Productos prod
                INNER JOIN DetallePedido dp ON prod.IdProducto = dp.IdProducto
                WHERE dp.IdPedido = @IdPedido";

            try
            {
                using (SqlConnection conexion = new SqlConnection(clsConsultas.cadena))
                {
                    conexion.Open();
                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            // 1. Actualizar el pedido
                            using (SqlCommand cmdPedido = new SqlCommand(queryPedido, conexion, transaccion))
                            {
                                cmdPedido.Parameters.AddWithValue("@IdPedido", idPedido);
                                int filas = cmdPedido.ExecuteNonQuery();

                                if (filas == 0)
                                {
                                    transaccion.Rollback();
                                    MessageBox.Show("El pedido ya se encontraba recibido o no se pudo actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            // 2. Aumentar stock de productos
                            using (SqlCommand cmdStock = new SqlCommand(queryStock, conexion, transaccion))
                            {
                                cmdStock.Parameters.AddWithValue("@IdPedido", idPedido);
                                cmdStock.ExecuteNonQuery();
                            }

                            // Confirmar la transacción
                            transaccion.Commit();

                            MessageBox.Show($"¡Pedido N° {idPedido} marcado como Recibido y stock actualizado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Recargar pedidos para refrescar la grilla y los botones
                            CargarPedidosDesdeBD();
                        }
                        catch (Exception exTrans)
                        {
                            transaccion.Rollback();
                            throw exTrans;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la recepción del pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPedidos_Resize(object sender, EventArgs e)
        {
            if (pnlUsuario != null)
            {
                // Si está colocado directamente en el Formulario:
                pnlUsuario.Top = this.ClientSize.Height - pnlUsuario.Height - 20;

                // Si está adentro de un panel lateral (ejemplo pnlMenu):
                if (pnlUsuario.Parent != null)
                {
                    pnlUsuario.Top = pnlUsuario.Parent.ClientSize.Height - pnlUsuario.Height - 20;
                }
            }
        }

        private void dgvPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPedidos.Columns[e.ColumnIndex].Name == "btnRecibir")
            {
                clsPedido pedido = dgvPedidos.Rows[e.RowIndex].DataBoundItem as clsPedido;
                if (pedido != null)
                {
                    if (pedido.Estado == "Recibido")
                    {
                        e.Value = "✓ Recibido";
                        // Color gris claro suave para pedidos terminados
                        e.CellStyle.BackColor = Color.FromArgb(245, 245, 245);
                        e.CellStyle.ForeColor = Color.FromArgb(140, 140, 140);
                        e.CellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(140, 140, 140);
                    }
                    else
                    {
                        e.Value = "Recibir";
                        // Verde DigitalFarma uniforme
                        Color verdeNormal = Color.FromArgb(0, 105, 92);
                        e.CellStyle.BackColor = verdeNormal;
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.SelectionBackColor = verdeNormal;
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                }
            }
        }
    }
}
