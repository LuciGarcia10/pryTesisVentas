using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTesisVentas
{
    public partial class FrmPerfil : Form
    {
        // Lista local para simular las otras cuentas a gestionar por el Administrador
        //private List<clsUsuarioSimulado> listaUsuarios;
        // Tu cadena de conexión real apuntando a BDDigitalFarma
        private string cadenaConexion = clsConsultas.cadena;
        public FrmPerfil()
        {
            InitializeComponent();
            ConfigurarEstilosExclusivos();
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            // Cargar datos actuales del Admin en los TextBox
            TxtUsuario.Text = "Valeria.Admin";
            TxtEmail.Text = "valeria.admin@digitalfarma.com";
            TxtContraActual.Text = "123456789";
            TxtContraNueva.Text = "";

            // Configurar contraseñas ocultas inicialmente
            TxtContraActual.PasswordChar = '●';
            TxtContraNueva.PasswordChar = '●';

            // Cargar datos de prueba para la grilla de control de permisos
            CargarGrillaUsuarios();
            AcomodarTarjetaDatosPersonales();
        }

        private void ConfigurarEstilosExclusivos()
        {
            BtnGuardar.BackColor = Color.FromArgb(0, 105, 92); 
            BtnGuardar.ForeColor = Color.White;
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.FlatAppearance.BorderSize = 0;
            BtnGuardar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            BtnGuardar.Cursor = Cursors.Hand;

            // Estilizar botón Cambiar Foto
            BtnCambiarFoto.BackColor = Color.White;
            BtnCambiarFoto.ForeColor = Color.FromArgb(0, 105, 92);
            BtnCambiarFoto.FlatStyle = FlatStyle.Flat;
            BtnCambiarFoto.FlatAppearance.BorderColor = Color.FromArgb(0, 105, 92);
            BtnCambiarFoto.FlatAppearance.BorderSize = 1;
            BtnCambiarFoto.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // --- Estilización profesional de la grilla de cuentas ---
            DgvPermisos.BackgroundColor = Color.White;
            DgvPermisos.BorderStyle = BorderStyle.None;
            DgvPermisos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvPermisos.GridColor = Color.FromArgb(230, 235, 240); // Línea divisoria suave
            DgvPermisos.RowHeadersVisible = false;
            DgvPermisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvPermisos.MultiSelect = false;
            DgvPermisos.AllowUserToAddRows = false;
            DgvPermisos.AllowUserToResizeRows = false;
            DgvPermisos.ShowCellToolTips = false;

            // Altura cómoda para cada fila (evita que el texto y el engranaje queden apretados)
            DgvPermisos.RowTemplate.Height = 40;

            // Encabezados (títulos de columnas): fondo gris sutil y texto oscuro nítido
            DgvPermisos.EnableHeadersVisualStyles = false; // Permite aplicar los colores personalizados
            DgvPermisos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvPermisos.ColumnHeadersHeight = 38;
            DgvPermisos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            DgvPermisos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 75, 85); // Texto gris oscuro legible
            DgvPermisos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            DgvPermisos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Celdas de contenido: TEXTO OSCURO FUERTE
            DgvPermisos.DefaultCellStyle.BackColor = Color.White;
            DgvPermisos.DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30); // Negro suave de alta legibilidad
            DgvPermisos.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            DgvPermisos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DgvPermisos.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            // Color de fila seleccionada (verde institucional suave en sintonía con DigitalFarma)
            DgvPermisos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 235);
            DgvPermisos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 70, 60); // Texto verde oscuro al marcar la fila
        }
        private void AcomodarTarjetaDatosPersonales()
        {
            // Reemplazá 'pnlDatosPersonales' por el (Name) de tu panel blanco izquierdo
            // Si no tiene nombre especial, fijate en propiedades cómo se llama (ej: panel1, pnlDatos, etc.)
            Control panel = PctFotoPerfil.Parent;
            if (panel == null) return;

            int anchoPanel = panel.ClientSize.Width;
            int altoPanel = panel.ClientSize.Height;

            // 1. Ancho uniforme y centrado de los TextBox
            int anchoCampos = anchoPanel - 60; // Deja 30px de margen a cada lado
            if (anchoCampos > 320) anchoCampos = 320; // Límite para que no queden exageradamente anchos

            int posXCentrada = (anchoPanel - anchoCampos) / 2;

            TxtUsuario.Width = anchoCampos;
            TxtUsuario.Left = posXCentrada;

            TxtEmail.Width = anchoCampos;
            TxtEmail.Left = posXCentrada;

            TxtContraActual.Width = anchoCampos;
            TxtContraActual.Left = posXCentrada;

            TxtContraNueva.Width = anchoCampos - 35; // Espacio para el ojito
            TxtContraNueva.Left = posXCentrada;
            BtnVerContra.Left = TxtContraNueva.Right + 5;

            // 2. Centrar Foto y Botón Cambiar Foto
            PctFotoPerfil.Left = (anchoPanel - PctFotoPerfil.Width) / 2;
            BtnCambiarFoto.Left = (anchoPanel - BtnCambiarFoto.Width) / 2;

            // 3. Botón Guardar y Link Cerrar Sesión
            BtnGuardar.Width = anchoCampos;
            BtnGuardar.Height = 42;
            BtnGuardar.Left = posXCentrada;
            LinkCerrarSesion.Left = (anchoPanel - LinkCerrarSesion.Width) / 2;

            // 4. DISTRIBUCIÓN VERTICAL CON AIRE
            // Calculamos el espacio vertical dinámicamente según la altura de la pantalla
            int posY = 55; // Comienza debajo del título "Datos Personales"

            PctFotoPerfil.Top = posY;
            posY = PctFotoPerfil.Bottom + 10;

            BtnCambiarFoto.Top = posY;

            // Espacio generoso entre la foto y el primer campo para que no se encimen
            int espacioEntreBloques = (altoPanel > 650) ? 22 : 14;
            posY = BtnCambiarFoto.Bottom + (espacioEntreBloques + 10);

            // Campo Usuario (buscamos su etiqueta arriba)
            MoverEtiquetaYCampo(TxtUsuario, ref posY, espacioEntreBloques);

            // Campo Email
            MoverEtiquetaYCampo(TxtEmail, ref posY, espacioEntreBloques);

            // Campo Contraseña Actual
            MoverEtiquetaYCampo(TxtContraActual, ref posY, espacioEntreBloques);

            // Campo Nueva Contraseña
            MoverEtiquetaYCampo(TxtContraNueva, ref posY, espacioEntreBloques);
            BtnVerContra.Top = TxtContraNueva.Top;

            // Botón Guardar Cambios
            posY += 15;
            BtnGuardar.Top = posY;

            // Link Cerrar Sesión
            LinkCerrarSesion.Top = BtnGuardar.Bottom + 14;
        }

        // Función auxiliar para mover cada TextBox junto a su Label correspondiente
        private void MoverEtiquetaYCampo(TextBox txt, ref int posY, int espacioEntreBloques)
        {
            Control panel = txt.Parent;
            // Busca el label que está justo encima del TextBox
            foreach (Control c in panel.Controls)
            {
                if (c is Label && c.Bounds.IntersectsWith(new Rectangle(txt.Left - 10, txt.Top - 35, txt.Width + 20, 35)))
                {
                    c.Left = txt.Left;
                    c.Top = posY;
                    posY = c.Bottom + 6;
                    break;
                }
            }

            txt.Top = posY;
            posY = txt.Bottom + espacioEntreBloques;
        }

        private void CargarGrillaUsuarios(string filtro = "")
        {
            string query = @"SELECT U.id_usuario, U.nombre AS [Usuario], R.nombre_rol AS [Rol], 
                            CASE WHEN U.activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS [Estado]
                     FROM Usuarios U
                     INNER JOIN Roles R ON U.id_rol = R.id_rol";

            if (!string.IsNullOrEmpty(filtro))
            {
                query += " WHERE U.nombre LIKE @Filtro OR R.nombre_rol LIKE @Filtro";
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        if (!string.IsNullOrEmpty(filtro))
                        {
                            comando.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");
                        }

                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);

                        // Evitar que genere columnas extras automáticamente
                        DgvPermisos.AutoGenerateColumns = false;

                        // Enlazar los campos con las columnas creadas en el diseñador
                        if (DgvPermisos.Columns["ClmUsuario"] != null)
                            DgvPermisos.Columns["ClmUsuario"].DataPropertyName = "Usuario";

                        if (DgvPermisos.Columns["Rol"] != null)
                            DgvPermisos.Columns["Rol"].DataPropertyName = "Rol";

                        if (DgvPermisos.Columns["Estado"] != null)
                            DgvPermisos.Columns["Estado"].DataPropertyName = "Estado";

                        DgvPermisos.DataSource = dt;
                    }
                }

                // Configurar la columna de Acciones existente (sin agregar una duplicada)
                if (DgvPermisos.Columns.Contains("Acciones"))
                {
                    var colAccion = DgvPermisos.Columns["Acciones"] as DataGridViewImageColumn;
                    if (colAccion != null)
                    {
                        colAccion.Image = Properties.Resources.Acciones;
                        colAccion.ImageLayout = DataGridViewImageCellLayout.Zoom; // Mantiene el tamaño compacto
                        colAccion.Width = 70;
                        colAccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // Ancho fijo
                        colAccion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                else if (!DgvPermisos.Columns.Contains("btnAcciones"))
                {
                    // Solo si no existiera de antes en el diseñador:
                    DataGridViewImageColumn colAccion = new DataGridViewImageColumn
                    {
                        Name = "btnAcciones",
                        HeaderText = "Acciones",
                        Image = Properties.Resources.Acciones,
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
                        Width = 70,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    };
                    colAccion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colAccion.DefaultCellStyle.NullValue = null;

                    DgvPermisos.Columns.Add(colAccion);
                }

                // Quitar inmovilización para que no falle el modo Fill
                foreach (DataGridViewColumn col in DgvPermisos.Columns)
                {
                    col.Frozen = false;
                }

                // Activar modo Fill y pesos relativos
                DgvPermisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (DgvPermisos.Columns["ClmUsuario"] != null)
                    DgvPermisos.Columns["ClmUsuario"].FillWeight = 140;

                if (DgvPermisos.Columns["Rol"] != null)
                    DgvPermisos.Columns["Rol"].FillWeight = 90;

                if (DgvPermisos.Columns["Estado"] != null)
                    DgvPermisos.Columns["Estado"].FillWeight = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla de permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerContra_Click(object sender, EventArgs e)
        {
            if (TxtContraNueva.PasswordChar == '●')
            {
                TxtContraNueva.PasswordChar = '\0'; // Muestra el texto plano
                BtnVerContra.Image = Properties.Resources.hide;
            }
            else
            {
                TxtContraNueva.PasswordChar = '●'; // Oculta el texto
                BtnVerContra.Image = Properties.Resources.show;
            }
        }

        // Variable para guardar temporalmente la ruta de la foto seleccionada
        private string rutaFotoSeleccionada = "";
        private void BtnCambiarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Filtramos para que solo muestre formatos de imagen comunes
                ofd.Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Guardamos la ruta del archivo seleccionado
                    rutaFotoSeleccionada = ofd.FileName;

                    // Mostramos la foto en el PictureBox de tu diseño
                    PctFotoPerfil.Image = Image.FromFile(ofd.FileName);
                    PctFotoPerfil.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        // Función auxiliar para convertir la foto del disco a binario (bytes)
        private byte[] ConvertirImagenABytes(string rutaArchivo)
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                byte[] datos = new byte[fs.Length];
                fs.Read(datos, 0, System.Convert.ToInt32(fs.Length));
                return datos;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas de interfaz
            string nombre = TxtUsuario.Text.Trim();
            string email = TxtEmail.Text.Trim();
            string contraActual = TxtContraActual.Text;
            string contraNueva = TxtContraNueva.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("El nombre de usuario y el email no pueden estar vacíos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(contraActual))
            {
                MessageBox.Show("Por favor, ingrese su contraseña actual para confirmar los cambios.", "Confirmación requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Conectamos a SQL Server
            string queryVerificar = "SELECT contrasenia FROM Usuarios WHERE mail = @Email";

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // PASO A: Verificar contraseña actual
                    using (SqlCommand cmdVerificar = new SqlCommand(queryVerificar, conexion))
                    {
                        cmdVerificar.Parameters.AddWithValue("@Email", email);
                        object resultado = cmdVerificar.ExecuteScalar();

                        if (resultado == null)
                        {
                            MessageBox.Show("No se encontró ningún usuario con el correo electrónico vinculado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string contraEnBD = resultado.ToString();

                        if (contraActual != contraEnBD)
                        {
                            MessageBox.Show("La contraseña actual ingresada es incorrecta.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // PASO B: Preparar la consulta de actualización
                    bool cambiaContrasenia = !string.IsNullOrWhiteSpace(contraNueva);
                    bool cambiaFoto = !string.IsNullOrEmpty(rutaFotoSeleccionada);

                    // Armamos dinámicamente el query según lo que modificó el usuario
                    string queryUpdate = "UPDATE Usuarios SET nombre = @Nombre";

                    if (cambiaContrasenia) queryUpdate += ", contrasenia = @NuevaContra";
                    if (cambiaFoto) queryUpdate += ", foto = @Foto";

                    queryUpdate += " WHERE mail = @Email";

                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conexion))
                    {
                        cmdUpdate.Parameters.AddWithValue("@Nombre", nombre);
                        cmdUpdate.Parameters.AddWithValue("@Email", email);

                        if (cambiaContrasenia)
                        {
                            cmdUpdate.Parameters.AddWithValue("@NuevaContra", contraNueva);
                        }

                        if (cambiaFoto)
                        {
                            // Convertimos la imagen seleccionada a un arreglo de bytes para guardarla en SQL
                            byte[] imagenBytes = ConvertirImagenABytes(rutaFotoSeleccionada);
                            cmdUpdate.Parameters.AddWithValue("@Foto", imagenBytes);
                        }

                        int filasAfectadas = cmdUpdate.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("¡Cambios de perfil guardados con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Limpiamos variables y campos temporales de contraseñas
                            TxtContraActual.Text = "";
                            TxtContraNueva.Text = "";
                            rutaFotoSeleccionada = "";

                            CargarGrillaUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("No se pudieron guardar los cambios. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 1. Mostrar el cuadro de diálogo de confirmación
            DialogResult res = MessageBox.Show(
                "¿Está seguro de que desea cerrar la sesión actual?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (res == DialogResult.Yes)
            {
                // Ocultamos la pantalla actual (FrmPerfil)
                this.Hide();

                // 2. Buscamos si el formulario de Login ya está creado en la memoria de la app
                Form loginAbierto = Application.OpenForms["FrmLogin"];

                if (loginAbierto != null)
                {
                    // Si el Login ya existía de antes en segundo plano, lo volvemos a mostrar y limpiamos sus campos
                    loginAbierto.Show();

                    // Opcional: si querés borrar lo que el usuario anterior escribió en el login
                    if (loginAbierto.Controls["txtUsuario"] != null)
                        loginAbierto.Controls["txtUsuario"].Text = "";
                    if (loginAbierto.Controls["txtContrasena"] != null)
                        loginAbierto.Controls["txtContrasena"].Text = "";
                }
                else
                {
                    // Si por alguna razón se había cerrado por completo, creamos uno nuevo
                    // (Reemplazá "FrmLogin" por el nombre exacto de tu formulario de Login)
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                }

                // 3. Cerramos definitivamente esta pantalla de Perfil para liberar memoria
                this.Close();
            }
        }

        private void DgvPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evitamos errores si el usuario hace clic en los encabezados de las columnas
            if (e.RowIndex < 0) return;

            // Verificamos si hizo clic específicamente en la columna de la imagen del engranaje
            if (DgvPermisos.Columns[e.ColumnIndex].Name == "btnAcciones")
            {
                DataRowView filaSeleccionada = DgvPermisos.Rows[e.RowIndex].DataBoundItem as DataRowView;

                if (filaSeleccionada != null)
                {
                    // Rescatamos los valores reales de la fila
                    int idUsuario = Convert.ToInt32(filaSeleccionada["id_usuario"]);
                    string usuario = filaSeleccionada["Usuario"].ToString();
                    string rolActual = filaSeleccionada["Rol"].ToString();
                    string estadoActual = filaSeleccionada["Estado"].ToString();

                    // Aquí podés abrir un pequeño formulario modal (ej: frmEditarRol) pasándole el idUsuario
                    // Por ahora, te dejo el aviso funcional que demuestra que captura el ID correcto:
                    MessageBox.Show($"ID de Cuenta: {idUsuario}\n" +
                                    $"Usuario: {usuario}\n" +
                                    $"Rol Actual: {rolActual}\n" +
                                    $"Estado: {estadoActual}\n\n" +
                                    $"¡Listo para conectar con un combo de actualización!",
                                    "Gestión de Permisos",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    /* 
                       Idea para el futuro inmediato:
                       frmCambiarRol frm = new frmCambiarRol(idUsuario);
                       if(frm.ShowDialog() == DialogResult.OK) {
                           CargarGrillaUsuarios(); // Recarga la grilla si hubo cambios
                       }
                    */
                }
            }
        }

        // Clase para ver la grilla de control del Administrador
        //public class clsUsuarioSimulado
        //{
        //    public string Usuario { get; set; }
        //    public string Rol { get; set; }
        //    public string Estado { get; set; }
        //}

        private void TxtBuscarU_Enter(object sender, EventArgs e)
        {
            if (TxtBuscarU.Text == "Buscar usuarios...")
            {
                TxtBuscarU.Text = "";
                TxtBuscarU.ForeColor = Color.Black; // Texto normal
            }
        }

        private void TxtBuscarU_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBuscarU.Text))
            {
                TxtBuscarU.Text = "Buscar usuarios...";
                TxtBuscarU.ForeColor = Color.Gray; // Color gris de guía
            }
        }
        private void TxtBuscarU_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = TxtBuscarU.Text.Trim();

            // Si el buscador está vacío o tiene el texto del placeholder ("Buscar usuarios..."), cargamos todo sin filtros
            if (string.IsNullOrEmpty(textoBusqueda) || textoBusqueda == "Buscar usuarios...")
            {
                CargarGrillaUsuarios();
            }
            else
            {
                // De lo contrario, le enviamos el filtro para consultar en la base de datos
                CargarGrillaUsuarios(textoBusqueda);
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

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            frmEstadisticas frm = new frmEstadisticas();
            frm.ShowDialog();
        }

        private void txtBuscarUsuarioGlobal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string usuarioABuscar = txtBuscarGlobal.Text.Trim();

                if (string.IsNullOrEmpty(usuarioABuscar))
                {
                    MessageBox.Show("Por favor, ingrese un nombre de usuario para buscar.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1. Agregamos el campo 'foto' a la consulta SQL
                string query = "SELECT nombre, mail, contrasenia, foto FROM Usuarios WHERE nombre = @Nombre";

                try
                {
                    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                    {
                        conexion.Open();
                        using (SqlCommand comando = new SqlCommand(query, conexion))
                        {
                            comando.Parameters.AddWithValue("@Nombre", usuarioABuscar);

                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                if (lector.Read())
                                {
                                    // Cargamos los campos de texto
                                    TxtUsuario.Text = lector["nombre"].ToString();
                                    TxtEmail.Text = lector["mail"].ToString();
                                    TxtContraActual.Text = lector["contrasenia"].ToString();
                                    TxtContraNueva.Text = "";

                                    // 2. LEER LA FOTO DESDE LA BASE DE DATOS
                                    if (lector["foto"] != DBNull.Value)
                                    {
                                        byte[] imagenBytes = (byte[])lector["foto"];

                                        // Convertimos los bytes en una imagen usando MemoryStream
                                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBytes))
                                        {
                                            PctFotoPerfil.Image = Image.FromStream(ms);
                                            PctFotoPerfil.SizeMode = PictureBoxSizeMode.Zoom;
                                        }
                                    }
                                    else
                                    {
                                        // Si el usuario no tiene foto, limpiamos el PictureBox 
                                        // para evitar mostrar la foto de la búsqueda anterior
                                        PctFotoPerfil.Image = null;
                                    }

                                    MessageBox.Show($"Usuario '{usuarioABuscar}' cargado con éxito.", "Búsqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró ningún usuario con ese nombre.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el usuario en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmPerfil_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Si cierran la ventana directamente de la X de Windows, cerramos toda la aplicación
            // para que no queden procesos "fantasma" corriendo de fondo.
            Application.Exit();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPerfil_Resize(object sender, EventArgs e)
        {
            AcomodarTarjetaDatosPersonales();
        }
    }
}
