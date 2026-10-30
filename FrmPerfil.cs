using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        private int idUsuarioActual = 0;
        public FrmPerfil()
        {
            InitializeComponent();
            ConfigurarEstilosExclusivos();
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            // Configurar contraseñas ocultas inicialmente
            txtContraActual.PasswordChar = '●';
            txtContraNueva.PasswordChar = '●';
            string usuarioLogueado = !string.IsNullOrEmpty(frmIngresar.UsuarioSesion) ? frmIngresar.UsuarioSesion : "Valeria.Admin";
            // Cargar datos de prueba para la grilla de control de permisos
            CargarGrillaUsuarios();
            AcomodarTarjetaDatosPersonales();
            VerificarPermisosUsuario();
            if (pnlEstadisticas != null)
            {
                pnlEstadisticas.Visible = (frmIngresar.RolSesion == "Administrador");
            }
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
            Control panel = PctFotoPerfil.Parent;
            if (panel == null) return;

            int anchoPanel = panel.ClientSize.Width;
            int altoPanel = panel.ClientSize.Height;

            int anchoCampos = anchoPanel - 60;
            if (anchoCampos > 320) anchoCampos = 320;

            int posXCentrada = (anchoPanel - anchoCampos) / 2;

            txtUsuario.Width = anchoCampos;
            txtUsuario.Left = posXCentrada;

            txtEmail.Width = anchoCampos;
            txtEmail.Left = posXCentrada;

            txtContraActual.Width = anchoCampos;
            txtContraActual.Left = posXCentrada;

            txtContraNueva.Width = anchoCampos - 35; 
            txtContraNueva.Left = posXCentrada;
            BtnVerContra.Left = txtContraNueva.Right + 5;

            txtLegajo.Width = anchoCampos;
            txtLegajo.Left = posXCentrada;

            txtTelefono.Width = anchoCampos;
            txtTelefono.Left = posXCentrada;

            PctFotoPerfil.Left = (anchoPanel - PctFotoPerfil.Width) / 2;
            BtnCambiarFoto.Left = (anchoPanel - BtnCambiarFoto.Width) / 2;

            BtnGuardar.Width = anchoCampos;
            BtnGuardar.Height = 38;
            BtnGuardar.Left = posXCentrada;
            LinkCerrarSesion.Left = (anchoPanel - LinkCerrarSesion.Width) / 2;

            int posY = 35;

            PctFotoPerfil.Top = posY;
            posY = PctFotoPerfil.Bottom + 6;

            BtnCambiarFoto.Top = posY;

            int espacioEntreBloques = (altoPanel > 750) ? 12 : 7;
            posY = BtnCambiarFoto.Bottom + (espacioEntreBloques + 6);

            PosicionarBloque(lblUsuario, txtUsuario, ref posY, posXCentrada, espacioEntreBloques);
            PosicionarBloque(lblEmail, txtEmail, ref posY, posXCentrada, espacioEntreBloques);
            PosicionarBloque(lblContraActual, txtContraActual, ref posY, posXCentrada, espacioEntreBloques);

            PosicionarBloque(lblContraNueva, txtContraNueva, ref posY, posXCentrada, espacioEntreBloques);
            BtnVerContra.Top = txtContraNueva.Top;

            PosicionarBloque(lblLegajo, txtLegajo, ref posY, posXCentrada, espacioEntreBloques);
            PosicionarBloque(lblTelefono, txtTelefono, ref posY, posXCentrada, espacioEntreBloques);

            posY += 8;
            BtnGuardar.Top = posY;
            LinkCerrarSesion.Top = BtnGuardar.Bottom + 8;
        }
        private void PosicionarBloque(Label lbl, TextBox txt, ref int posY, int posX, int espacioEntreBloques)
        {
            if (lbl != null)
            {
                lbl.Left = posX;
                lbl.Top = posY;
                posY = lbl.Bottom + 3; 
            }

            if (txt != null)
            {
                txt.Top = posY;
                posY = txt.Bottom + espacioEntreBloques; 
            }
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

                string colAccionName = DgvPermisos.Columns.Contains("Acciones") ? "Acciones" : (DgvPermisos.Columns.Contains("btnAcciones") ? "btnAcciones" : "");

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
        private void VerificarPermisosUsuario()
        {
            // Consulta directa a la base de datos uniendo Usuarios y Roles
            string query = @"SELECT R.nombre_rol 
                     FROM Usuarios U 
                     INNER JOIN Roles R ON U.id_rol = R.id_rol 
                     WHERE U.nombre = @NombreUsuario";

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        // Toma el nombre que figura actualmente en el formulario
                        comando.Parameters.AddWithValue("@NombreUsuario", txtUsuario.Text.Trim());

                        conexion.Open();
                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
                            string rol = resultado.ToString().ToLower();

                            // Si el rol NO contiene "admin", aplicamos las restricciones
                            if (!rol.Contains("admin"))
                            {
                                // 1. Ocultar el botón de estadísticas del menú lateral
                                btnEstadisticas.Visible = false;

                                // 2. Ocultar la grilla de permisos de la derecha para que no edite otros roles
                                DgvPermisos.Visible = false;
                                TxtBuscarU.Visible = false;
                            }
                            else
                            {
                                // Si es administrador, tiene acceso completo
                                btnEstadisticas.Visible = true;
                                DgvPermisos.Visible = true;
                                TxtBuscarU.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al comprobar permisos: " + ex.Message);
            }
        }

        private void CargarDatosUsuarioPorNombre(string nombreUsuario)
        {
            string query = "SELECT id_usuario, nombre, mail, legajo, telefono, contrasenia, foto FROM Usuarios WHERE nombre = @Nombre";

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", nombreUsuario);
                        conexion.Open();

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                idUsuarioActual = Convert.ToInt32(lector["id_usuario"]);
                                txtUsuario.Text = lector["nombre"].ToString();
                                txtEmail.Text = lector["mail"].ToString();

                                // Cargamos Legajo y Teléfono verificando que no vengan vacíos/nulos desde la BD
                                txtLegajo.Text = lector["legajo"] != DBNull.Value ? lector["legajo"].ToString() : "";
                                txtTelefono.Text = lector["telefono"] != DBNull.Value ? lector["telefono"].ToString() : "";

                                txtContraActual.Text = "";
                                txtContraNueva.Text = "";
                                rutaFotoSeleccionada = "";

                                // Carga de la foto de perfil
                                if (lector["foto"] != DBNull.Value)
                                {
                                    byte[] imagenBytes = (byte[])lector["foto"];
                                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                                    {
                                        PctFotoPerfil.Image = Image.FromStream(ms);
                                        PctFotoPerfil.SizeMode = PictureBoxSizeMode.Zoom;
                                    }
                                }
                                else
                                {
                                    PctFotoPerfil.Image = null;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerContra_Click(object sender, EventArgs e)
        {
            if (txtContraNueva.PasswordChar == '●')
            {
                txtContraNueva.PasswordChar = '\0'; // Muestra el texto plano
                BtnVerContra.Image = Properties.Resources.hide;
            }
            else
            {
                txtContraNueva.PasswordChar = '●'; // Oculta el texto
                BtnVerContra.Image = Properties.Resources.show;
            }
        }

        // Variable para guardar temporalmente la ruta de la foto seleccionada
        private string rutaFotoSeleccionada = "";
        private void BtnCambiarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Seleccionar foto de perfil";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaFotoSeleccionada = ofd.FileName;
                    // Cargamos en un stream para no bloquear el archivo en el explorador de Windows
                    using (FileStream fs = new FileStream(rutaFotoSeleccionada, FileMode.Open, FileAccess.Read))
                    {
                        PctFotoPerfil.Image = Image.FromStream(fs);
                    }
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
            string nombre = txtUsuario.Text.Trim();
            string email = txtEmail.Text.Trim();
            string legajo = txtLegajo.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string contraActual = txtContraActual.Text;
            string contraNueva = txtContraNueva.Text;

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

            // Conexión y operaciones en SQL Server
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // Verificar contraseña actual usando el id_usuario cargado
                    using (SqlCommand cmdVerificar = new SqlCommand("SELECT contrasenia FROM Usuarios WHERE id_usuario = @IdUsuario", conexion))
                    {
                        cmdVerificar.Parameters.AddWithValue("@IdUsuario", idUsuarioActual);
                        object resultado = cmdVerificar.ExecuteScalar();

                        if (resultado == null)
                        {
                            MessageBox.Show("No se encontró el registro del usuario en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string contraEnBD = resultado.ToString();

                        if (contraActual != contraEnBD)
                        {
                            MessageBox.Show("La contraseña actual ingresada es incorrecta.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Preparar la consulta de actualización con legajo y telefono
                    bool cambiaContrasenia = !string.IsNullOrWhiteSpace(contraNueva);
                    bool cambiaFoto = !string.IsNullOrEmpty(rutaFotoSeleccionada);

                    string queryUpdate = "UPDATE Usuarios SET nombre = @Nombre, mail = @Email, legajo = @Legajo, telefono = @Telefono";

                    if (cambiaContrasenia) queryUpdate += ", contrasenia = @NuevaContra";
                    if (cambiaFoto) queryUpdate += ", foto = @Foto";

                    queryUpdate += " WHERE id_usuario = @IdUsuario";

                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conexion))
                    {
                        cmdUpdate.Parameters.AddWithValue("@Nombre", nombre);
                        cmdUpdate.Parameters.AddWithValue("@Email", email);
                        cmdUpdate.Parameters.AddWithValue("@Legajo", string.IsNullOrWhiteSpace(legajo) ? (object)DBNull.Value : legajo);
                        cmdUpdate.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
                        cmdUpdate.Parameters.AddWithValue("@IdUsuario", idUsuarioActual);

                        if (cambiaContrasenia)
                        {
                            cmdUpdate.Parameters.AddWithValue("@NuevaContra", contraNueva);
                        }

                        if (cambiaFoto)
                        {
                            byte[] imagenBytes = ConvertirImagenABytes(rutaFotoSeleccionada);
                            cmdUpdate.Parameters.AddWithValue("@Foto", imagenBytes);
                        }

                        int filasAfectadas = cmdUpdate.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("¡Cambios de perfil guardados con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtContraActual.Text = "";
                            txtContraNueva.Text = "";
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
            // Mostrar el cuadro de diálogo de confirmación
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

                // Buscamos si el formulario de Login ya está creado en la memoria de la app
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

                // Cerramos definitivamente esta pantalla de Perfil para liberar memoria
                this.Close();
            }
        }

        private void DgvPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evitamos errores si el usuario hace clic en los encabezados
            if (e.RowIndex < 0) return;

            string colName = DgvPermisos.Columns[e.ColumnIndex].Name;

            // Verificamos si hizo clic en la columna de engranaje (por nombre o porque es celda de imagen)
            if (colName == "btnAcciones" || colName == "Acciones" || colName == "ClmAcciones" || DgvPermisos.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                DataRowView filaSeleccionada = DgvPermisos.Rows[e.RowIndex].DataBoundItem as DataRowView;

                if (filaSeleccionada != null)
                {
                    // Rescatamos el id_usuario real de la base de datos
                    int idUsuario = Convert.ToInt32(filaSeleccionada["id_usuario"]);

                    // Abrimos directamente el formulario modal
                    using (frmCambiarRol frm = new frmCambiarRol(idUsuario))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            // Si guardó cambios exitosamente, recargamos la grilla para ver el nuevo rol/estado
                            CargarGrillaUsuarios();
                        }
                    }
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
                                    txtUsuario.Text = lector["nombre"].ToString();
                                    txtEmail.Text = lector["mail"].ToString();
                                    txtContraActual.Text = lector["contrasenia"].ToString();
                                    txtContraNueva.Text = "";

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
