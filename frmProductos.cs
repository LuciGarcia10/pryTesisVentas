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
        string cadena = "Server=.; Database=BDDigitalFarma; Integrated Security=True";
        public frmProductos()
        {
            InitializeComponent();

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
                    // 1. Borramos físicamente de la base de datos SQL Server
                    bool eliminadoOk = clsConsultas.EliminarProducto(prod.Id);

                    if (eliminadoOk)
                    {
                        // 2. Si se borró en SQL Server, lo quitamos de la memoria de la pantalla
                        listaProductos.Remove(prod);

                        // 3. Refrescamos la interfaz filtrando lo que queda
                        ActualizarGrilla(listaProductos);
                        MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            // Si hizo clic en "btnEditar"
            else if (dgvProductos.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                Producto prod = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;
                MessageBox.Show("Abriendo edición para: " + prod.Nombre);
                // Aquí abrirías tu formulario de edición pasándole el objeto 'prod'
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
        }
        private void frmProductos_Load(object sender, EventArgs e)
        {
            // CONFIGURACIÓN DE LA GRILLA 
            // 1. ESTO VA PRIMERO: Apagamos el generador automático antes de hacer nada
            dgvProductos.AutoGenerateColumns = false;

            // 2. Configuramos las columnas manuales (que ahora incluyen el Clear)
            ConfigurarColumnasAcciones();

            // 3. Cargamos los combos y el resto 
            cmbOrden.Items.Clear();
            cmbOrden.Items.Add("Más nuevo");
            cmbOrden.Items.Add("Más viejo");
            cmbOrden.Items.Add("Prioridad");
            cmbOrden.SelectedIndex = 0;

            // --- 4. CARGAR LOS PRODUCTOS EN LA TABLA ---
            CargarProductosDesdeBD(); //crear este método para llenar el DataGridView
        }

        // Recupera los registros reales de SQL Server y los almacena en la lista global
        public void CargarProductosDesdeBD()
        {
            // Consulta a tu tabla de productos (Asegúrate de incluir la columna de ID o Clave Primaria)
            string consulta = "SELECT IdProducto, Cantidad, Nombre, Categoria, FechaVencimiento, Precio FROM Productos";

            // Accedemos de forma directa usando la conexión estática unificada
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
                        Producto nuevoProd = new Producto();
                        // Mapeamos las propiedades (Asegúrate de que la clase Producto tenga la propiedad IdProducto o Id)
                        nuevoProd.Id = Convert.ToInt32(lector["IdProducto"]);
                        nuevoProd.Cantidad = Convert.ToInt32(lector["Cantidad"]);
                        nuevoProd.Nombre = lector["Nombre"].ToString();
                        nuevoProd.Categoria = lector["Categoria"].ToString();
                        nuevoProd.FechaVencimiento = Convert.ToDateTime(lector["FechaVencimiento"]);
                        nuevoProd.Precio = Convert.ToDecimal(lector["Precio"]);

                        listaProductos.Add(nuevoProd);
                    }

                    // Mostramos la lista completa en la grilla
                    ActualizarGrilla(listaProductos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la tabla de productos: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // 1. LIMPIEZA TOTAL
            dgvProductos.Columns.Clear();

            // 2. COLUMNAS DE DATOS
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cantidad", Name = "Cantidad", Width = 50 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", Name = "Nombre", Width = 200 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Categoria", HeaderText = "Categoría", Name = "Categoria", Width = 150 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaVencimiento", HeaderText = "Vencimiento", Name = "FechaVencimiento", Width = 100 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = "Precio", Name = "Precio", Width = 80 });

            // 3. COLUMNA EDITAR
            DataGridViewImageColumn colEditar = new DataGridViewImageColumn();
            colEditar.Name = "btnEditar";
            colEditar.HeaderText = "Acciones"; // Título principal
            colEditar.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEditar.Image = Properties.Resources.ptbEditar;
            colEditar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colEditar.DefaultCellStyle.NullValue = null;
            colEditar.Width = 50;
            dgvProductos.Columns.Add(colEditar);

            // 4. COLUMNA ELIMINAR
            DataGridViewImageColumn colEliminar = new DataGridViewImageColumn();
            colEliminar.Name = "btnEliminar";
            colEliminar.HeaderText = ""; // Vacío para que parezca la misma columna de "Acciones"
            colEliminar.Image = Properties.Resources.ptbBorrar;
            colEliminar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colEliminar.DefaultCellStyle.NullValue = null;
            colEliminar.Width = 50;
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
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

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

        private void lblBuscarArriba_Click(object sender, EventArgs e)
        {
            txtBuscarArriba.Focus();
        }

        private void txtBuscarArriba_TextChanged(object sender, EventArgs e)
        {
            lblBuscarArriba.Visible = string.IsNullOrEmpty(txtBuscarArriba.Text);

            // Filtramos inmediatamente
            FiltrarBusquedaRapida(txtBuscarArriba.Text);
        }

        private void txtBuscarArriba_Enter(object sender, EventArgs e)
        {
            lblBuscarArriba.Visible = false;
        }

        private void txtBuscarArriba_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarArriba.Text))
            {
                lblBuscarArriba.Visible = true;
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

        private void cmbFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        // Método para traer la lista de productos desde SQL Server y guardarlos en memoria
        // public void CargarProductosDesdeBD()
        // {
        //     try 
        //     {
        //         // Establece y abre la conexión con la base de datos DigitalFarma
        //         using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        //         {
        //             conexion.Open();
        //
        //             // Consulta SQL para seleccionar las columnas necesarias de la tabla Productos
        //             string query = "SELECT Cantidad, Nombre, Categoria, Precio FROM Productos";
        //
        //             // Prepara el comando y ejecuta el lector de datos (Reader)
        //             SqlCommand comando = new SqlCommand(query, conexion);
        //             SqlDataReader lector = comando.ExecuteReader();
        //
        //             // Limpiamos la lista local para evitar que se dupliquen los datos al recargar
        //             listaProductos.Clear(); 
        //
        //             // Recorre fila por fila los resultados obtenidos de la base de datos
        //             while (lector.Read())
        //             {
        //                 // Crea un nuevo objeto de la clase Producto y mapea los datos de las columnas
        //                 Producto nuevoProd = new Producto();
        //                 nuevoProd.Cantidad = Convert.ToInt32(lector["Cantidad"]);
        //                 nuevoProd.Nombre = lector["Nombre"].ToString();
        //                 nuevoProd.Categoria = lector["Categoria"].ToString();
        //                 nuevoProd.Precio = Convert.ToDecimal(lector["Precio"]);
        //                 
        //                 // Agrega el producto procesado a nuestra lista global listaProductos
        //                 listaProductos.Add(nuevoProd);
        //             }
        //             
        //             // Refresca la interfaz visual vinculando la lista actualizada al DataGridView
        //             dgvProductos.DataSource = null; // Resetea el origen de datos
        //             dgvProductos.DataSource = listaProductos; // Asigna la lista cargada
        //         }
        //     }
        //     // Captura cualquier falla en la conexión o en la consulta SQL
        //     catch (Exception ex)
        //     {
        //         // Muestra un cuadro de mensaje informando el error exacto
        //         MessageBox.Show("Error al cargar productos: " + ex.Message);
        //     }
        // }
    }
}
