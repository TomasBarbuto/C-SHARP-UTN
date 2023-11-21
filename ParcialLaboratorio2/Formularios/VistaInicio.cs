using Entidades;
using Entidades.SQL;
using Entidades.Usuarios;

namespace ParcialLaboratorio2
{
    /// <summary>
    /// Clase parcial que representa el formulario de inicio de sesi�n de la interfaz de usuario.
    /// Permite a los usuarios iniciar sesi�n como supervisor u operario y redirigirlos al formulario correspondiente una vez que se autentican correctamente.
    /// </summary>
    public partial class VistaInicio : Form
    {
        private List<Usuario> usuarios;

        /// <summary>
        /// Constructor de la clase VistaInicio. Inicializa una nueva instancia del formulario de inicio de sesi�n.
        /// </summary>
        public VistaInicio()
        {
            InitializeComponent();
            usuarios = new List<Usuario>();
            this.FormClosing += VistaInicio_FormClosing;
        }

        /// <summary>
        /// Agrega los usuarios a la lista de usuarios y configura el stock de sabor en 50 al cargar el formulario.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Inicio_Load(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> usuariosDesdeBD = UsuarioDB.SelectAll();
                usuarios.AddRange(usuariosDesdeBD);
                StockDB.CargarStock();
                ProductosDB.CargarProductosFabricados();
                ProductosDB.CargarProductosCocinados();
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaInicio), "Inicio_Load");
                MessageBox.Show($"Error al cargar la lista de usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Escribe el nombre de usuario y la contrase�a como "Lautaro" y "L10" al hacer clic en el bot�n de Supervisor.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btn_supervisor_Click(object sender, EventArgs e)
        {
            in_usuario.Text = "Lautaro";
            in_contrase�a.Text = "L10";
        }

        /// <summary>
        /// Escribe el nombre de usuario y la contrase�a como "Lucas" y "L20" al hacer clic en el bot�n de Operario.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btn_operario_Click(object sender, EventArgs e)
        {
            in_usuario.Text = "Lucas";
            in_contrase�a.Text = "L20";
        }

        /// <summary>
        /// Verifica el nombre de usuario y la contrase�a ingresados y muestra el formulario correspondiente seg�n el tipo de usuario al hacer clic en el bot�n de inicio de sesi�n.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btn_iniciocesion_Click(object sender, EventArgs e)
        {

            string nombreUsuarioIngresado = in_usuario.Text;
            string contraseniaIngresada = in_contrase�a.Text;
            Supervisor supervisor = null;
            Operario operario = null;

            foreach (var usuario in usuarios)
            {
                if (usuario.NombreUsuario == nombreUsuarioIngresado && usuario.Contrasenia == contraseniaIngresada)
                {

                    this.Hide();

                    if (usuario is Supervisor)
                    {
                        foreach (var item in usuarios)
                        {
                            if (item.NombreUsuario == nombreUsuarioIngresado && item.Contrasenia == contraseniaIngresada)
                            {
                                supervisor = (Supervisor)item;
                                break;
                            }
                        }
                        VistaSupervisor formSupervisor = new VistaSupervisor(supervisor, usuarios);
                        formSupervisor.Show();
                    }
                    else if (usuario is Operario)
                    {
                        foreach (var item in usuarios)
                        {
                            if (item.NombreUsuario == nombreUsuarioIngresado && item.Contrasenia == contraseniaIngresada)
                            {
                                operario = (Operario)item;
                                break;
                            }
                        }
                        VistaOperario formOperario = new VistaOperario(operario);
                        formOperario.Show();
                    }

                    MessageBox.Show($"Bienvenido {nombreUsuarioIngresado}!", "Inicio de sesi�n exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show("Nombre de usuario o contrase�a incorrectos. Int�ntelo de nuevo.");
        }

        /// <summary>
        /// Evento FormClosing para manejar el cierre del formulario.
        /// </summary>
        private void VistaInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StockDB.ActualizarStock();
                ProductosDB.ActualizarProductosFabricados();
                ProductosDB.ActualizarProductosCocinados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Archivos.AgregarErrorLog(ex, nameof(VistaInicio), "VistaInicio_FormClosing");
            }
        }
    }
}