using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTesisVentas
{
    public partial class frmProductos : Form
    {
        // Lista global que guardará los productos en la memoria de la PC
        List<Producto> listaProductos = new List<Producto>();
        // Cadena de conexión a tu base de datos en Córdoba
        public static string cadena = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Datos\BDDigitalFarma.mdf;Integrated Security=True;Connect Timeout=30;";
        public frmProductos()
        {
            InitializeComponent();

        }
        private void EstilizarGrillaProductos()
        {
            // 1. Fondos y bordes limpios
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.GridColor = Color.FromArgb(240, 242, 245); // Línea divisoria sutil

            // 2. Encabezados (Header)
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(120, 130, 140); // Gris legible
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f);
            dgvProductos.ColumnHeadersHeight = 42;

            // 3. Celdas y filas
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.RowTemplate.Height = 52; // Altura cómoda para leer

            // Color de texto oscuro nítido y selección suave en verde menta
            dgvProductos.DefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 72);
            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 250, 245);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 30, 40);
            dgvProductos.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);

            // 4. Evitar que la primera celda quede resaltada en azul al abrir
            dgvProductos.ClearSelection();
        }
        private void pnlContenedorPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            frmAyuda frm = new frmAyuda();
            frm.ShowDialog();
        }
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evitar errores si se hace clic en el encabezado
            if (e.RowIndex < 0) return;

            // Si hizo clic en el botón de la columna "btnEliminar"
            if (dgvProductos.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                Producto prod = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;

                DialogResult respuesta = MessageBox.Show($"¿Está seguro de que desea eliminar {prod.Nombre} permanentemente del sistema?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    bool eliminadoOk = clsConsultas.EliminarProducto(prod.Id);

                    if (eliminadoOk)
                    {
                        listaProductos.Remove(prod);
                        ActualizarGrilla(listaProductos);
                        MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            // Si hizo clic en "btnEditar"
            else if (dgvProductos.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                Producto prod = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;

                
            }
        }

        private void cmbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Verificamos que haya una opción seleccionada y que la lista tenga datos
            // Esto evita que el programa se cierre por un error de "Referencia nula"
            if (cmbOrden.SelectedItem != null && listaProductos != null && listaProductos.Count > 0)
            {
                string opcion = cmbOrden.SelectedItem.ToString();

                // 2. Aplicamos el orden seleccionado
                if (opcion == "Más nuevo")
                {
                    // Ordenamos por Fecha de Vencimiento de forma descendente (los más nuevos primero)
                    // Si queremos por Fecha de Carga, tener ese campo en la clase
                    var listaOrdenada = listaProductos.OrderByDescending(x => x.FechaVencimiento).ToList();
                    ActualizarGrilla(listaOrdenada);
                }
                else if (opcion == "Más viejo")
                {
                    // Ordenamos por Fecha de Vencimiento de forma ascendente
                    var listaOrdenada = listaProductos.OrderBy(x => x.FechaVencimiento).ToList();
                    ActualizarGrilla(listaOrdenada);
                }
                else if (opcion == "Nombre (A-Z)")
                {
                    // Ordenamos alfabéticamente por el nombre del medicamento
                    var listaOrdenada = listaProductos.OrderBy(x => x.Nombre).ToList();
                    ActualizarGrilla(listaOrdenada);
                }
            }
        }

        // 3. Método auxiliar para refrescar la grilla de forma limpia
        public void ActualizarGrilla(List<Producto> lista)
        {
            dgvProductos.DataSource = null; // Limpia el origen anterior para forzar el refresco
            dgvProductos.DataSource = lista; // Asigna la nueva lista ordenada
            dgvProductos.ClearSelection(); // Evita que la primera fila quede seleccionada en azul al cargar
        }
        private void frmProductos_Load(object sender, EventArgs e)
        {
            dgvProductos.AutoGenerateColumns = false;
            // Configurar columnas y estilo
            ConfigurarColumnasAcciones();
            EstilizarGrillaProductos();
            // Combos de orden
            cmbOrden.Items.Clear();
            cmbOrden.Items.Add("Más nuevo");
            cmbOrden.Items.Add("Más viejo");
            cmbOrden.Items.Add("Nombre (A-Z)");
            cmbOrden.SelectedIndex = 0;
            // Cargar datos
            CargarProductosDesdeBD();
            dgvProductos.Paint += dgvProductos_Paint;
            pnlEstadisticas.Visible = (frmIngresar.RolSesion == "Administrador");
        }

        // Recupera los registros reales de SQL Server y los almacena en la lista global
        public void CargarProductosDesdeBD()
        {
            // Consulta con las columnas reales de la BD y un INNER JOIN a Categorias
            string consulta = @"
        SELECT 
            p.IdProducto, 
            p.StockActual AS Cantidad, 
            p.Nombre, 
            c.Nombre AS Categoria, 
            p.PrecioVenta AS Precio 
        FROM Productos p
        INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria";

            using (SqlConnection conexion = new SqlConnection(clsConsultas.cadena))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    SqlDataReader lector = comando.ExecuteReader();

                    listaProductos.Clear();

                    while (lector.Read())
                    {
                        Producto nuevoProd = new Producto
                        {
                            Id = Convert.ToInt32(lector["IdProducto"]),
                            Cantidad = Convert.ToInt32(lector["Cantidad"]),
                            Nombre = lector["Nombre"].ToString(),
                            Categoria = lector["Categoria"].ToString(),
                            Precio = Convert.ToDecimal(lector["Precio"]),
                            // Asignamos una fecha provisional para evitar error por falta de columna:
                            FechaVencimiento = DateTime.Today
                        };

                        listaProductos.Add(nuevoProd);
                    }

                    // Muestra los registros recuperados en la grilla
                    ActualizarGrilla(listaProductos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la tabla de productos: " + ex.Message,
                                    "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        public void HacerCirculo(Control control)
        {
            using (System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                gp.AddEllipse(0, 0, control.Width, control.Height);
                control.Region = new Region(gp);
            }
        }

        private void ConfigurarColumnasAcciones()
        {
            dgvProductos.Columns.Clear();
            // Cantidad / Stock
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Stock",
                Name = "Cantidad",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            //Nombre (Fill para que tome todo el espacio restante disponible)
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { Font = new Font("Segoe UI", 9.5f, FontStyle.Bold) }
            });
            // Categoría
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Categoria",
                HeaderText = "Categoría",
                Name = "Categoria",
                Width = 170
            });
            // Vencimiento (formateado y centrado)
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaVencimiento",
                HeaderText = "Vencimiento",
                Name = "FechaVencimiento",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            // Precio (formateado con moneda $ y alineado a la derecha)
            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Precio",
                HeaderText = "Precio",
                Name = "Precio",
                Width = 110 // Le damos un poco más de margen
            };
            // Alineación del contenido (los números a la derecha con signo $)
            colPrecio.DefaultCellStyle.Format = "C2";
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            // Alineación del encabezado (centrado o a la derecha según prefieras)
            colPrecio.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colPrecio);
            // Botón Editar
            DataGridViewImageColumn colEditar = new DataGridViewImageColumn
            {
                Name = "btnEditar",
                HeaderText = "Acciones",
                Width = 45,
                Image = Properties.Resources.ptbEditar,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            colEditar.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEditar.DefaultCellStyle.NullValue = null;
            dgvProductos.Columns.Add(colEditar);
            // Botón Eliminar
            DataGridViewImageColumn colEliminar = new DataGridViewImageColumn
            {
                Name = "btnEliminar",
                HeaderText = "",
                Width = 45,
                Image = Properties.Resources.ptbBorrar,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            colEliminar.DefaultCellStyle.NullValue = null;
            dgvProductos.Columns.Add(colEliminar);
        }


        private void cmbFiltrar_MouseClick(object sender, MouseEventArgs e)
        {
            // 1. Creamos la instancia
            frmFiltroProductos ventanaFiltro = new frmFiltroProductos();

            // 2. Le pasamos la lista de productos
            if (this.listaProductos == null)
            {
                this.listaProductos = new List<Producto>();
            }
            ventanaFiltro.listaParaFiltrar = this.listaProductos;

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

        private void dgvProductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Evitar pintar en el encabezado
            if (e.RowIndex < 0) return;

            // --- Pintar botón EDITAR ---
            if (e.ColumnIndex >= 0 && dgvProductos.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                e.PaintBackground(e.CellBounds, true);

                // Definir colores y radio del borde 
                Color backColor = Color.FromArgb(180, 230, 218); 
                Color borderColor = Color.FromArgb(0, 191, 165); 
                int borderRadius = 5;

                // Calcular rectángulo del botón centrado en la celda
                int buttonSize = 25; // Tamaño del cuadrado
                Rectangle rect = new Rectangle(
                    e.CellBounds.X + (e.CellBounds.Width - buttonSize) / 2,
                    e.CellBounds.Y + (e.CellBounds.Height - buttonSize) / 2,
                    buttonSize, buttonSize);

                // Dibujar fondo y borde redondeado
                using (GraphicsPath path = GetRoundedRect(rect, borderRadius))
                using (SolidBrush brush = new SolidBrush(backColor))
                using (Pen pen = new Pen(borderColor, 1))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Bordes suaves
                    e.Graphics.FillPath(brush, path);
                    e.Graphics.DrawPath(pen, path);
                }

                // Dibujar el icono centrado (imagen transparente)
                Image img = Properties.Resources.ptbEditar;
                Rectangle imgRect = new Rectangle(
                    rect.X + (rect.Width - 16) / 2, // Centrar icono de 16x16
                    rect.Y + (rect.Height - 16) / 2,
                    16, 16);
                e.Graphics.DrawImage(img, imgRect);

                e.Handled = true; // Indicar que ya pintamos la celda
            }

            // --- Pintar botón ELIMINAR ---
            if (e.ColumnIndex >= 0 && dgvProductos.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                // Colores para eliminar (rojo suave)
                Color backColor = Color.FromArgb(255, 205, 210);
                Color borderColor = Color.FromArgb(239, 83, 80);
                int borderRadius = 5;

                // Calcular rectángulo del botón
                int buttonSize = 25;
                Rectangle rect = new Rectangle(
                    e.CellBounds.X + (e.CellBounds.Width - buttonSize) / 2,
                    e.CellBounds.Y + (e.CellBounds.Height - buttonSize) / 2,
                    buttonSize, buttonSize);

                // Dibujar fondo y borde
                using (GraphicsPath path = GetRoundedRect(rect, borderRadius))
                using (SolidBrush brush = new SolidBrush(backColor))
                using (Pen pen = new Pen(borderColor, 1))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                    e.Graphics.DrawPath(pen, path);
                }

                // Dibujar icono
                Image img = Properties.Resources.ptbBorrar;
                Rectangle imgRect = new Rectangle(
                    rect.X + (rect.Width - 16) / 2,
                    rect.Y + (rect.Height - 16) / 2,
                    16, 16);
                e.Graphics.DrawImage(img, imgRect);

                e.Handled = true;
            }
        }

        // Método auxiliar para crear rectángulos redondeados
        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2.0f;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(rect.Location, sizeF);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            using (frmAñadirProducto ventana = new frmAñadirProducto())
            {
                ventana.StartPosition = FormStartPosition.CenterParent;
                if (ventana.ShowDialog(this) == DialogResult.OK)
                {
                    // Si añadió un producto correctamente, refrescamos desde SQL Server
                    CargarProductosDesdeBD();
                }
            }
        }

        // Método auxiliar para calcular la geometría de los bordes redondeados
        private GraphicsPath ObtenerCaminoRedondeado(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2.0f;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(rect.Location, sizeF);

            // Esquina superior izquierda
            path.AddArc(arc, 180, 90);

            // Esquina superior derecha
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Esquina inferior derecha
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Esquina inferior izquierda
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void btnAgregarProductos_Paint(object sender, PaintEventArgs e)
        {
            // Obtenemos el botón que lanzó el evento
            Button btn = (Button)sender;

            // Definimos el radio de la redondez (mientras más alto, más redondo)
            int radioBorde = 20;

            // Activamos el suavizado para que el borde no se vea pixelado
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Creamos un camino (path) con la forma redondeada
            Rectangle rectanguloBorde = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath caminoRedondeado = ObtenerCaminoRedondeado(rectanguloBorde, radioBorde);

            // Aplicamos esa forma como la región del botón
            btn.Region = new Region(caminoRedondeado);

            // (Opcional) Dibujar un borde finito si quisieras
            // using (Pen pen = new Pen(Color.FromArgb(0, 120, 110), 1))
            // {
            //     e.Graphics.DrawPath(pen, caminoRedondeado);
            // }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            lblBuscar.Visible = string.IsNullOrEmpty(txtBuscar.Text);

            // Filtramos inmediatamente
            FiltrarBusquedaRapida(txtBuscar.Text);
        }
        private void FiltrarBusquedaRapida(string texto)
        {
            // Si la lista global está vacía o es nula, no hacemos nada para evitar crashes
            if (listaProductos == null || listaProductos.Count == 0) return;

            // Si el texto está vacío, volvemos a mostrar la lista completa original
            if (string.IsNullOrWhiteSpace(texto))
            {
                ActualizarGrilla(listaProductos);
                return;
            }

            string textoMinuscula = texto.ToLower().Trim();

            // Filtramos en tiempo real sobre la lista que tenemos cargada en memoria (PC)
            var busqueda = listaProductos.Where(x =>
                (x.Nombre != null && x.Nombre.ToLower().Contains(textoMinuscula)) ||
                (x.Categoria != null && x.Categoria.ToLower().Contains(textoMinuscula))
            ).ToList();

            // Actualizamos la tabla del diseño con el resultado
            ActualizarGrilla(busqueda);
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {
            // Al tocar el texto, mandamos el foco al TextBox para poder escribir
            txtBuscar.Focus();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            // Apenas el usuario hace clic o llega con el TAB, ocultamos el label
            lblBuscar.Visible = false;
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            // Si sale del cuadro y NO escribió nada, mostramos el label de nuevo
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                lblBuscar.Visible = true;
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

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmCuentasCorrientes frm = new frmCuentasCorrientes();
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

        private void frmProductos_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void dgvProductos_Paint(object sender, PaintEventArgs e)
        {
            // Verificamos que existan las dos columnas de acciones
            if (dgvProductos.Columns.Contains("btnEditar") && dgvProductos.Columns.Contains("btnEliminar"))
            {
                int indexEditar = dgvProductos.Columns["btnEditar"].Index;
                int indexEliminar = dgvProductos.Columns["btnEliminar"].Index;
                // Obtenemos los rectángulos de encabezado de ambas columnas
                Rectangle rect1 = dgvProductos.GetCellDisplayRectangle(indexEditar, -1, true);
                Rectangle rect2 = dgvProductos.GetCellDisplayRectangle(indexEliminar, -1, true);
                // Unimos ambos rectángulos para formar un solo bloque
                Rectangle rectAcciones = new Rectangle(
                    rect1.X,
                    rect1.Y,
                    rect1.Width + rect2.Width,
                    rect1.Height
                );

                if (rectAcciones.Width > 0 && rectAcciones.Height > 0)
                {
                    // Limpiamos el fondo del encabezado con blanco
                    using (SolidBrush brushFondo = new SolidBrush(Color.White))
                    {
                        e.Graphics.FillRectangle(brushFondo, rectAcciones);
                    }
                    // Dibujamos el texto "Acciones" centrado perfectamente sobre los dos botones
                    using (Font fontHeader = new Font("Segoe UI Semibold", 9.5f))
                    using (SolidBrush brushTexto = new SolidBrush(Color.FromArgb(120, 130, 140)))
                    using (StringFormat formato = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    })
                    {
                        e.Graphics.DrawString("Acciones", fontHeader, brushTexto, rectAcciones, formato);
                    }
                }
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que no sea el encabezado
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvProductos.Columns[e.ColumnIndex].Name;

            // Obtener el objeto de la fila actual
            Producto prodSeleccionado = dgvProductos.Rows[e.RowIndex].DataBoundItem as Producto;
            if (prodSeleccionado == null) return;

            // --- ACCIÓN: EDITAR ---
            if (nombreColumna == "btnEditar")
            {
                AbrirFormularioEdicion(prodSeleccionado);
            }
            // --- ACCIÓN: ELIMINAR ---
            else if (nombreColumna == "btnEliminar")
            {
                EliminarProductoSeleccionado(prodSeleccionado);
            }
        }

        private void EliminarProductoSeleccionado(Producto prod)
        {
            DialogResult respuesta = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el producto '{prod.Nombre}' permanentemente del sistema?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Productos WHERE IdProducto = @id";

                    using (SqlConnection conexion = new SqlConnection(clsConsultas.cadena))
                    {
                        conexion.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@id", prod.Id);
                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas > 0)
                            {
                                // 1. Quitar de la lista en memoria
                                listaProductos.Remove(prod);

                                // 2. Refrescar la grilla
                                ActualizarGrilla(listaProductos);

                                MessageBox.Show("Producto eliminado con éxito.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    // Error 547 = Conflicto con Foreign Key (el producto ya tiene ventas o compras asociadas)
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("No se puede eliminar este producto porque ya figura en pedidos o ventas registradas.\n\nSugerencia: Cambie su stock a 0 o márquelo como inactivo.",
                                        "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar en la base de datos: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AbrirFormularioEdicion(Producto prod)
        {
            using (FrmEditarProducto frm = new FrmEditarProducto())
            {
                frm.ProductoSeleccionado = prod;

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    // Refresca la grilla con los cambios actualizados
                    ActualizarGrilla(listaProductos);
                }
            }
        }

        private void cmbFiltrar_Click(object sender, EventArgs e)
        {
            using (frmFiltroProductos ventanaFiltro = new frmFiltroProductos())
            {
                ventanaFiltro.listaParaFiltrar = this.listaProductos;
                ventanaFiltro.StartPosition = FormStartPosition.CenterParent;

                if (ventanaFiltro.ShowDialog(this) == DialogResult.OK)
                {
                    // Si el usuario aplicó filtros o reseteó, actualiza la grilla con lo que devolvió el modal
                    if (ventanaFiltro.ListaResultado != null)
                    {
                        ActualizarGrilla(ventanaFiltro.ListaResultado);
                    }
                }
            }
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
