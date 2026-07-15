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
        // Variable global para almacenar el Id del cliente seleccionado en la pantalla
        private string idClienteSeleccionado = "";
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
            string consulta = "SELECT IdCliente, NroAfiliado, Nombre, Apellido, ObraSocial, Estado, Saldo FROM Clientes";
            clsConsultas.LlenarGrid(consulta, dgvCuentasC);

            if (btnLimpiar != null)
                btnLimpiar.Enabled = false;
        }
        public void ActualizarGrilla(List<clsCuentasC> lista)
        {
            // Mantenemos esta función por si tu ventana de filtros (FrmFiltroClientes) te devuelve una lista filtrada en memoria
            dgvCuentasC.DataSource = null;
            dgvCuentasC.DataSource = lista;

            if (btnLimpiar != null)
                btnLimpiar.Enabled = true; // Si se fuerza una lista manual, habilitamos limpiar para regresar a la base
        }


        private void EstilizarGrilla()
        {
            // 1. Bordes y estructura general
            dgvCuentasC.BackgroundColor = Color.White;
            dgvCuentasC.BorderStyle = BorderStyle.None;
            dgvCuentasC.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCuentasC.GridColor = Color.FromArgb(240, 240, 240);

            // 2. Encabezados (Gris claro fijo y centrado)
            dgvCuentasC.EnableHeadersVisualStyles = false;
            dgvCuentasC.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            dgvCuentasC.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(110, 110, 110);
            dgvCuentasC.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCuentasC.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCuentasC.ColumnHeadersHeight = 40;

            // 3. Filas y Selección (Al estar limpio el diseñador, esto aplica directo sin dar vueltas)
            dgvCuentasC.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvCuentasC.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 250, 245); // Tu verde agua
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
            this.Hide();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmVentas frm = new frmVentas();
            frm.ShowDialog();
            this.Hide();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            frmPedidos frm = new frmPedidos();
            frm.ShowDialog();
            this.Hide();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.ShowDialog();
            this.Hide();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            frmAyuda frm = new frmAyuda();
            frm.ShowDialog();
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Al limpiar los filtros, volvemos a consultar el estado actual de la base de datos
            CargarDatosDesdeBase();
        }

        private void pctDesplegar_Click(object sender, EventArgs e)
        {
            FrmFiltroClientes ventanaFiltro = new FrmFiltroClientes();

            // 1. Le asignamos el dueño para el 'this.Owner' de tu compañera
            ventanaFiltro.Owner = this;

            // 2. LLAMAMOS AL NUEVO MÉTODO ESTÁTICO (Trae la lista real de SQL Server)
            ventanaFiltro.listaParaFiltrar = clsConsultas.ObtenerClientesLista();

            // 3. Tu lógica matemática de posición en pantalla
            ventanaFiltro.StartPosition = FormStartPosition.Manual;
            Point puntoAparicion = pctDesplegar.PointToScreen(new Point(0, pctDesplegar.Height));
            ventanaFiltro.Location = puntoAparicion;

            ventanaFiltro.ShowDialog(this);
        }

        private void dgvCuentasC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Evitamos las filas de cabecera o clics fuera de rango
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // 2. Verificá que este nombre coincida EXACTAMENTE con el .Name de tu columna de acciones
            if (dgvCuentasC.Columns[e.ColumnIndex].Name == "ClmAcciones")
            {
                // Intentamos leer el ID primero como Objeto de la lista (por si está el filtro activo)
                string idCliente = "";

                if (dgvCuentasC.Rows[e.RowIndex].DataBoundItem is clsCuentasC clienteObjeto)
                {
                    // Si la grilla tiene la lista del filtro en memoria, saca el ID directo del objeto
                    idCliente = clienteObjeto.IdCliente.ToString();
                }
                else
                {
                    // Si la grilla tiene el DataTable común (Carga inicial), lo lee de la celda oculta como antes
                    idCliente = dgvCuentasC.Rows[e.RowIndex].Cells["IdCliente"].Value.ToString();
                }

                // El resto de tu código original se queda EXACTAMENTE IGUAL
                string nombreCliente = dgvCuentasC.Rows[e.RowIndex].Cells["ClmN"].Value.ToString();
                // Conseguimos las coordenadas del clic del mouse en la pantalla
                Point puntoLocal = dgvCuentasC.PointToClient(Cursor.Position);
                Rectangle celdaBounds = dgvCuentasC.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                // Calculamos la posición X relativa, es decir, a cuántos píxeles desde el borde izquierdo de la celda se hizo clic
                int clicX = puntoLocal.X - celdaBounds.X;

                // --- DIVIDIMOS LA CELDA EN 3 SECCIONES (Asumiendo que la columna mide unos 120px de ancho) ---
                // BOTÓN 1: LUPA (Ver detalles/Historial) - Clic en el primer tercio (de 0 a 40 píxeles)
                if (clicX >= 0 && clicX < 40)
                {
                    // Instanciamos el formulario que vas a reutilizar
                    FrmNuevoCliente frmDetalle = new FrmNuevoCliente();

                    // Le configuramos las propiedades públicas que creamos
                    frmDetalle.Modo = "DETALLES";
                    frmDetalle.IdClienteSeleccionado = idCliente; // Le pasa el ID para que busque sus datos

                    // Lo abrimos como ventana emergente
                    frmDetalle.ShowDialog();
                }

                // BOTÓN 2: LÁPIZ (Editar cliente) - Clic en el segundo tercio (de 40 a 80 píxeles)
                else if (clicX >= 40 && clicX < 80)
                {
                    FrmNuevoCliente frmEditar = new FrmNuevoCliente();

                    frmEditar.Modo = "EDITAR";
                    frmEditar.IdClienteSeleccionado = idCliente;

                    // Usamos un 'if' con DialogResult.OK por si el usuario guardó los cambios con éxito.
                    // Si guardó, el formulario se cierra avisando "OK" y recargamos tu grilla principal.
                    if (frmEditar.ShowDialog() == DialogResult.OK) // <-- ESTO avisa a la grilla que tiene que actualizarse
                    {
                        CargarDatosDesdeBase(); // Tu método para refrescar los clientes en pantalla
                    }
                }

                // BOTÓN 3: TACHITO (Eliminar/Dar de baja) - Clic en el último tercio (de 80 en adelante)
                else if (clicX >= 80)
                {
                    // Le preguntamos al usuario para evitar que borre algo sin querer
                    DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea eliminar permanentemente al cliente {nombreCliente}? Esta acción no se puede deshacer.",
                                                             "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes)
                    {
                        // Llamamos al método que borra físicamente de la base de datos
                        bool borradoExitoso = clsConsultas.EliminarCliente(idCliente);

                        if (borradoExitoso)
                        {
                            // Refrescamos tu grilla para que el cliente desaparezca de la pantalla al instante
                            CargarDatosDesdeBase();
                            MessageBox.Show("Cliente eliminado correctamente del sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void dgvCuentasC_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 1. Evitamos cabeceras y filtramos por tu columna real
            if (e.RowIndex >= 0 && dgvCuentasC.Columns[e.ColumnIndex].Name == "ClmAcciones")
            {
                // 2. Que Windows Forms pinte el fondo (blanco o verde según corresponda) de forma automática
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // 3. Tus iconos con las posiciones exactas que ya tenías
                int y = e.CellBounds.Top + (e.CellBounds.Height - 20) / 2;

                e.Graphics.DrawImage(Properties.Resources.Lupita, new Rectangle(e.CellBounds.Left + 15, y, 20, 20));
                e.Graphics.DrawImage(Properties.Resources.ptbEditar, new Rectangle(e.CellBounds.Left + 45, y, 20, 20));
                e.Graphics.DrawImage(Properties.Resources.ptbBorrar, new Rectangle(e.CellBounds.Left + 75, y, 20, 20));

                // 4. Avisamos que ya terminamos
                e.Handled = true;
            
            }
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FrmPerfil frm = new FrmPerfil();
            frm.ShowDialog();
            this.Hide();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            frmEstadisticas frm = new frmEstadisticas();    
            frm.ShowDialog();
        }

        private void btnExp_Click(object sender, EventArgs e)
        {// 1. Validamos que la grilla tenga datos para exportar
            if (dgvCuentasC.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la grilla para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Configuramos el cuadro de diálogo para guardar el archivo
            SaveFileDialog guardarArchivo = new SaveFileDialog();
            guardarArchivo.Filter = "Archivos CSV (*.csv)|*.csv";
            guardarArchivo.FileName = "Cuentas_Corrientes_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
            guardarArchivo.Title = "Exportar Grilla a Excel";

            if (guardarArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<string> lineas = new List<string>();

                    // 3. Creamos los encabezados de las columnas (reproducimos los nombres de tu grilla)
                    // Usamos un formato compatible con Excel en español (separado por punto y coma ';')
                    string encabezado = "Nro Afiliado;Nombre;Apellido;Obra Social;Estado;Saldo";
                    lineas.Add(encabezado);

                    // 4. Recorremos las filas de la grilla para extraer los datos reales
                    foreach (DataGridViewRow fila in dgvCuentasC.Rows)
                    {
                        // Evitamos la fila vacía del final si está habilitada
                        if (fila.IsNewRow) continue;

                        // Extraemos los valores usando el (Name) real del diseño
                        string nroAfiliado = fila.Cells["ClmAfiliado"].Value?.ToString() ?? "";
                        string nombre = fila.Cells["ClmN"].Value?.ToString() ?? ""; // El que vimos hoy en tu clic
                        string apellido = fila.Cells["ClmApellido"].Value?.ToString() ?? ""; // Revisá si es así
                        string obraSocial = fila.Cells["ClmObraS"].Value?.ToString() ?? ""; // Revisá si es así
                        string estado = fila.Cells["ClmEstadoCuenta"].Value?.ToString() ?? ""; // O ClmEstadoCuenta
                        string saldo = fila.Cells["ClmSaldo"].Value?.ToString() ?? "0";

                        // Limpiamos los caracteres que puedan romper el formato CSV (comas o punto y coma dentro del texto)
                        nombre = nombre.Replace(";", " ");
                        apellido = apellido.Replace(";", " ");

                        // Unimos los datos en una sola línea separada por ';'
                        string linea = $"{nroAfiliado};{nombre};{apellido};{obraSocial};{estado};{saldo}";
                        lineas.Add(linea);
                    }

                    // 5. Escribimos el archivo físico en la compu usando codificación UTF-8 con BOM 
                    // (Esto último es clave para que Excel reconozca bien los acentos y las 'ñ')
                    System.IO.File.WriteAllLines(guardarArchivo.FileName, lineas, System.Text.Encoding.UTF8);

                    MessageBox.Show("¡Datos exportados con éxito! Ya podés abrir el archivo en Excel.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar exportar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
    
}
