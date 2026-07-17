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
        private string cadenaConexion = "Server=localhost; Database=BDDigitalFarma; Integrated Security=True";
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

            // Ajustar propiedades de la grilla de usuarios
            DgvPermisos.BackgroundColor = Color.White;
            DgvPermisos.BorderStyle = BorderStyle.None;
            DgvPermisos.RowHeadersVisible = false;
            DgvPermisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvPermisos.AllowUserToAddRows = false;
           // DgvPermisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarGrillaUsuarios(string filtro = "")
        {
            // Consulta SQL trayendo el ID interno, el nombre, el rol y el estado real
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

                        DgvPermisos.DataSource = null;
                        DgvPermisos.DataSource = dt;
                    }
                }

                // Ocultamos la columna del ID para que no se vea en la interfaz de usuario
                if (DgvPermisos.Columns["id_usuario"] != null)
                {
                    DgvPermisos.Columns["id_usuario"].Visible = false;
                }
                // Acciones
                if (!DgvPermisos.Columns.Contains("btnAcciones"))
                {
                    DataGridViewImageColumn colAccion = new DataGridViewImageColumn();
                    colAccion.Name = "btnAcciones";
                    colAccion.HeaderText = "Acciones";

                    colAccion.Image = Properties.Resources.Acciones;

                    colAccion.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    colAccion.Width = 80;
                    colAccion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    DgvPermisos.Columns.Add(colAccion);
                }
                // Configurar e insertar la columna de engranaje (Acciones) si no existe
                if (!DgvPermisos.Columns.Contains("btnAcciones"))
                {
                    DataGridViewImageColumn colAccion = new DataGridViewImageColumn();
                    colAccion.Name = "btnAcciones";
                    colAccion.HeaderText = "Acciones";

                    // Si tenés el engranaje en tus recursos, descomentá la línea de abajo:
                    // colAccion.Image = Properties.Resources.engranaje; 

                    colAccion.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    colAccion.Width = 60;
                    DgvPermisos.Columns.Add(colAccion);
                }
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

     
    }
}
