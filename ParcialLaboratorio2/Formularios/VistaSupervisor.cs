using Entidades;
using Entidades.Productos;
using Entidades.SQL;
using Entidades.Usuarios;
using System.Data;

using static Entidades.Stock;


namespace ParcialLaboratorio2
{
    /// <summary>
    /// Clase parcial que representa la interfaz de usuario para un supervisor en el sistema.
    /// </summary>
    public partial class VistaSupervisor : Form
    {
        private Supervisor supervisor;
        private List<Usuario> usuarios;

        //Para listar los usuarios en un orden
        public delegate void OrdenarDelegate<T>(ref List<T> lista, Func<T, T, int> comparador);

        //Para el envío de stock y cancelacion.
        private CancellationTokenSource cts;
        private int tiempoRestante = 0;

        /// <summary>
        /// Constructor para la clase VistaSupervisor.
        /// </summary>
        /// <param name="supervisor">El supervisor asociado a la vista.</param>
        /// <param name="usuarios">La lista de usuarios del sistema.</param>
        public VistaSupervisor(Supervisor supervisor, List<Usuario> usuarios)
        {
            InitializeComponent();
            this.supervisor = supervisor;
            this.usuarios = usuarios;
        }

        private void VistaSupervisor_ProduccionRealizada(string producto, int cantidad)
        {
            if (this.ContainsFocus)
            {
                MessageBox.Show($"¡La producción de {producto} ({cantidad} unidades) ha sido completada!", "Producción Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Maneja el evento de carga de la vista del supervisor.
        /// Establece el IDusuario actual en "lbl_nombreusuario".
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void VistaSupervisor_Load(object sender, EventArgs e)
        {
            lbl_nombreusuario.Text = supervisor.GenerarIdUsuario();
            Eventos.ProduccionRealizada += VistaSupervisor_ProduccionRealizada;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "cerrar sesión".
        /// cierra la sesión actual y te devuelve al LOGIN.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_cerrarsesion_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirmResult = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Confirmar cierre de sesión", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is VistaInicio)
                        {
                            this.Hide();
                            form.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "btn_cerrarsesion_Click");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Maneja el evento de clic en el botón "consultar stock".
        /// muestra y actualiza la información del stock en la interfaz.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_consultarstock_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_supervisor.DataSource = null;
                dgv_supervisor.Columns.Clear();

                dgv_supervisor.Columns.Add("Material", "Material");
                dgv_supervisor.Columns.Add("Cantidad", "Cantidad");

                Dictionary<string, int> diccionarioStock = Stock.ObtenerDatosStock();

                foreach (var item in diccionarioStock)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgv_supervisor, item.Key, item.Value.ToString());

                    if (item.Value <= 20 && item.Value >= 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    if (item.Value == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.IndianRed;
                    }

                    dgv_supervisor.Rows.Add(row);
                }

                dgv_supervisor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_supervisor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "btn_consultarstock_Click");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// Maneja el evento de clic en el botón "lista de operarios".
        /// muestra la lista de los Usuarios en la interfaz.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_listaoperarios_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_supervisor.DataSource = null;
                dgv_supervisor.Columns.Clear();

                List<object> usuariosListar = new List<object>();

                foreach (var usuario in usuarios)
                {
                    if (usuario is Operario)
                    {
                        Operario operario = (Operario)usuario;
                        usuariosListar.Add(new
                        {
                            IdUsuario = operario.GenerarIdUsuario(),
                            Nombre = operario.NombreUsuario,
                            Dni = operario.DniUsuario,
                            Contrasenia = operario.Contrasenia,
                        });
                    }
                    else if (usuario is Supervisor)
                    {
                        Supervisor supervisor = (Supervisor)usuario;
                        usuariosListar.Add(new
                        {
                            IdUsuario = supervisor.GenerarIdUsuario(),
                            Nombre = supervisor.NombreUsuario,
                            Dni = supervisor.DniUsuario,
                            Contrasenia = supervisor.Contrasenia,
                        });
                    }
                }

                Ordenador.OrdenarAscendente(usuariosListar, (a, b) => string.Compare(((dynamic)a).IdUsuario.ToString(), ((dynamic)b).IdUsuario.ToString()));

                dgv_supervisor.AutoGenerateColumns = true;
                dgv_supervisor.DataSource = usuariosListar;
                dgv_supervisor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_supervisor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "btn_listaoperarios_Click");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic del botón 'btn_pedirstock', permitiendo al usuario agregar más materia prima o cantidad de sabores al stock.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>

        private void btn_pedirstock_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> materiasPrimas = new List<string>
                {
                    "Harina",
                    "Azucar",
                    "Gelatina",
                    "Leudantes",
                    "Almidon",
                    "Gelificantes"
                };

                List<string> sabores = Enum.GetNames(typeof(Stock.Sabor)).ToList();

                List<string> options = new List<string>();
                options.AddRange(materiasPrimas);
                options.AddRange(sabores);

                string selectedOption = PromptSelection("Seleccione la materia prima o sabor que desea agregar:", "Cargar Stock", options);

                if (!string.IsNullOrEmpty(selectedOption))
                {
                    string input = PromptInputNum($"Ingrese la cantidad adicional de {selectedOption}:", "Cantidad adicional");
                    if (int.TryParse(input, out int cantidad) && cantidad >= 0)
                    {
                        if (materiasPrimas.Contains(selectedOption))
                        {
                            Stock.AgregarMateriaPrima(selectedOption, cantidad);
                        }
                        else if (sabores.Contains(selectedOption))
                        {
                            Stock.AgregarCantidadSabor((Stock.Sabor)Enum.Parse(typeof(Stock.Sabor), selectedOption), cantidad);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "btn_pedirstock_Click");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Muestra un prompt de selección con la etiqueta, el título y las opciones especificados.
        /// </summary>
        /// <param name="labelText">El texto de la etiqueta en el cuadro de diálogo.</param>
        /// <param name="caption">El título del cuadro de diálogo.</param>
        /// <param name="options">Las opciones disponibles para seleccionar.</param>
        /// <returns>La opción seleccionada por el usuario.</returns>
        private string PromptSelection(string labelText, string caption, List<string> options)
        {
            try
            {
                Form prompt = new Form();
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.Width = 500;
                prompt.Height = 200;
                prompt.Text = caption;

                Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = labelText };
                ComboBox inputBox = new ComboBox() { Left = 50, Top = 50, Width = 400, DropDownStyle = ComboBoxStyle.DropDownList };
                inputBox.Items.AddRange(options.ToArray());

                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 70, Top = 100 };
                confirmation.Click += (sender, e) => { prompt.Close(); };

                inputBox.KeyDown += (sender, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        confirmation.PerformClick();
                    }
                };

                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.ShowDialog();
                return inputBox.Text;
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "PromptSelection");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "pedir stock".
        /// Permite al supervisor solicitar más cantidad de materias primas o sabores específicos.
        /// </summary>
        /// <param name="labelText">El texto de la etiqueta en el cuadro de diálogo.</param>
        /// <param name="caption">El título del cuadro de diálogo.</param>
        private string PromptInputNum(string labelText, string caption)
        {
            try
            {
                int result;
                Form prompt = new Form();
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.Width = 500;
                prompt.Height = 200;
                prompt.Text = caption;

                Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = labelText };
                TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 400 };

                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 70, Top = 100 };
                confirmation.Click += (sender, e) =>
                {
                    if (int.TryParse(inputBox.Text, out result))
                    {
                        prompt.Close();
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un número válido menor o igual a 1000.");
                    }
                };

                inputBox.KeyPress += (sender, e) =>
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        confirmation.PerformClick();
                    }
                };

                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.ShowDialog();
                return inputBox.Text;
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "PromptInput");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "producción".
        /// Oculta el formulario actual y muestra el formulario de la vista del operario asociado a este supervisor.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_produccion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form vistaOperario = new VistaOperario(supervisor);
            vistaOperario.Show();
        }

        /// <summary>
        /// Maneja el evento de clic del botón 'btn_RegistroCocina', mostrando un registro de las cantidades cocinadas de bizcochuelo, gelatina y flan, en un DataGridView.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</

        private void btn_RegistroCocina_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_supervisor.DataSource = null;
                dgv_supervisor.Columns.Clear();

                Dictionary<string, int> todasLasCantidades = new Dictionary<string, int>();

                Dictionary<string, int> cantidadesBizcochuelo = Bizcochuelo.ObtenerCantidadesCocinadas();
                foreach (var cantidad in cantidadesBizcochuelo)
                {
                    todasLasCantidades.Add(cantidad.Key, cantidad.Value);
                }

                Dictionary<string, int> cantidadesGelatina = Gelatina.ObtenerCantidadesCocinadas();
                foreach (var cantidad in cantidadesGelatina)
                {
                    todasLasCantidades.Add(cantidad.Key, cantidad.Value);
                }

                Dictionary<string, int> cantidadesFlan = Flan.ObtenerCantidadesCocinadas();
                foreach (var cantidad in cantidadesFlan)
                {
                    todasLasCantidades.Add(cantidad.Key, cantidad.Value);
                }

                bool todasCero = todasLasCantidades.Values.All(cantidad => cantidad == 0);

                if (todasCero)
                {
                    MessageBox.Show("No hay stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var listaOrdenada = todasLasCantidades.ToList();
                    Ordenador.OrdenarDescendente(listaOrdenada, (a, b) => a.Value.CompareTo(b.Value));

                    dgv_supervisor.DataSource = listaOrdenada;
                    dgv_supervisor.Columns[0].HeaderText = "Producto";
                    dgv_supervisor.Columns[1].HeaderText = "Cantidad Cocinada";
                    dgv_supervisor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_supervisor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    foreach (DataGridViewRow row in dgv_supervisor.Rows)
                    {
                        if (row.Cells[1].Value != null)
                        {
                            int cantidad = Convert.ToInt32(row.Cells[1].Value);
                            if (cantidad >= 1 && cantidad <= 5)
                            {
                                row.DefaultCellStyle.BackColor = Color.Yellow;
                            }
                            else if (cantidad == 0)
                            {
                                row.DefaultCellStyle.BackColor = Color.IndianRed;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "btn_RegistroCocina_Click");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Registrar Producido".
        /// Muestra en el DataGridView la cantidad actual de productos disponibles en stock para cada tipo y sabor.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_RegProducido_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_supervisor.DataSource = null;
                dgv_supervisor.Columns.Clear();

                Dictionary<string, Dictionary<Sabor, int>> todosLosStocks = new Dictionary<string, Dictionary<Sabor, int>>
                {
                    { "Bizcochuelo", Bizcochuelo.Cantidades },
                    { "Gelatina", Gelatina.Cantidades },
                    { "Flan", Flan.Cantidades }
                };

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Producto", typeof(string));
                dataTable.Columns.Add("Sabor", typeof(string));
                dataTable.Columns.Add("Cantidad", typeof(int));

                bool todasCero = todosLosStocks.Values.All(stock => stock.Values.All(cantidad => cantidad == 0));

                if (todasCero)
                {
                    MessageBox.Show("No hay stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgv_supervisor.Dock = DockStyle.Fill;
                    dgv_supervisor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

                    foreach (var stock in todosLosStocks)
                    {
                        foreach (var cantidad in stock.Value)
                        {
                            dataTable.Rows.Add(stock.Key, cantidad.Key, cantidad.Value);
                        }
                    }

                    dgv_supervisor.DataSource = dataTable;

                    foreach (DataGridViewColumn column in dgv_supervisor.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "btn_RegProducido_Click");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Alta Usuarios".
        /// Permite dar de alta a un nuevo usuario (Operario o Supervisor) solicitando información como nombre, DNI y contraseña.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_altausuarios_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> roles = new List<string> { "Operario", "Supervisor" };
                string selectedRole = PromptSelection("Seleccione el rol del usuario a dar de alta:", "Alta de Usuarios", roles);

                if (!string.IsNullOrEmpty(selectedRole))
                {
                    string nombre = PromptInputText("Ingrese el nombre del usuario:", "Alta de Usuarios");
                    string dniInput = PromptInputNum("Ingrese el DNI del usuario:", "Alta de Usuarios");
                    int tipo;

                    if (int.TryParse(dniInput, out int dni))
                    {
                        string contrasenia = PromptInputText("Ingrese la contraseña del usuario:", "Alta de Usuarios");

                        Usuario nuevoUsuario;

                        if (selectedRole == "Operario")
                        {
                            nuevoUsuario = new Operario(nombre, dni, contrasenia, 2);
                            tipo = 2;
                        }
                        else
                        {
                            nuevoUsuario = new Supervisor(nombre, dni, contrasenia, 1);
                            tipo = 1;
                        }

                        bool usuarioExistente = usuarios.Any(u => u.DniUsuario == dni);

                        if (!usuarioExistente)
                        {

                            Thread actualizarListaThread = new Thread(() => ActualizarListaUsuarios(nuevoUsuario));
                            actualizarListaThread.Start();

                            usuarios.Add(nuevoUsuario);
                            UsuarioDB.Insert(nuevoUsuario.GenerarIdUsuario(), nombre, dni, contrasenia, tipo);
                            MessageBox.Show($"{selectedRole} dado de alta exitosamente.", "Alta de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un usuario con el mismo DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un DNI válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "btn_altausuarios_Click");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualiza la lista de usuarios en el DataGridView del formulario.
        /// </summary>
        /// <param name="nuevoOperario">El nuevo operario que se agregará a la lista.</param>
        private void ActualizarListaUsuarios(Usuario nuevoOperario)
        {
            try
            {

                
                List<object> usuariosListar = new List<object>();

                foreach (var usuario in usuarios)
                {
                    if (usuario is Operario)
                    {
                        Operario operario = (Operario)usuario;
                        usuariosListar.Add(new
                        {
                            IdUsuario = operario.GenerarIdUsuario(),
                            Nombre = operario.NombreUsuario,
                            Dni = operario.DniUsuario,
                            Contrasenia = operario.Contrasenia,
                        });
                    }
                    else if (usuario is Supervisor)
                    {
                        Supervisor supervisor = (Supervisor)usuario;
                        usuariosListar.Add(new
                        {
                            IdUsuario = supervisor.GenerarIdUsuario(),
                            Nombre = supervisor.NombreUsuario,
                            Dni = supervisor.DniUsuario,
                            Contrasenia = supervisor.Contrasenia,
                        });
                    }
                }

                Ordenador.OrdenarAscendente(usuariosListar, (a, b) => string.Compare(((dynamic)a).IdUsuario.ToString(), ((dynamic)b).IdUsuario.ToString()));

                this.Invoke((MethodInvoker)delegate
                {
                    dgv_supervisor.DataSource = null;
                    dgv_supervisor.Columns.Clear();
                    dgv_supervisor.AutoGenerateColumns = true;
                    dgv_supervisor.DataSource = usuariosListar;
                    dgv_supervisor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_supervisor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                });
                
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "ActualizarListaOperarios");
                MessageBox.Show($"Error al actualizar la lista de operarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra un cuadro de diálogo de entrada de texto y devuelve la entrada del usuario.
        /// </summary>
        /// <param name="labelText">Texto que se mostrará como etiqueta.</param>
        /// <param name="caption">Texto del título del cuadro de diálogo.</param>
        /// <returns>La entrada de texto del usuario o cadena vacía si hay un error.</returns>
        private string PromptInputText(string labelText, string caption)
        {
            try
            {
                string result = string.Empty;
                Form prompt = new Form();
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.Width = 500;
                prompt.Height = 200;
                prompt.Text = caption;

                Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = labelText };
                TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 400 };

                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 70, Top = 100 };
                confirmation.Click += (sender, e) =>
                {
                    result = inputBox.Text;
                    prompt.Close();
                };

                inputBox.KeyDown += (sender, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        confirmation.PerformClick();
                    }
                };

                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.ShowDialog();
                return result;
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "PromptInputText");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        /// <summary>
        /// Evento de clic del botón para dar de baja a un usuario seleccionado.
        /// </summary>
        private void btn_bajausuarios_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> nombresUsuarios = new List<string>();
                List<string> informacionUsuarios = new List<string>();

                foreach (var usuario in usuarios)
                {
                    nombresUsuarios.Add(usuario.NombreUsuario);
                    informacionUsuarios.Add($"{usuario.GenerarIdUsuario()}, {usuario.Tipo}");
                }

                string usuarioSeleccionado = PromptSelectionBaja("Seleccione el usuario a dar de baja:", "Baja de Usuarios", nombresUsuarios, informacionUsuarios);

                if (!string.IsNullOrEmpty(usuarioSeleccionado))
                {
                    Usuario usuarioBaja = null;

                    foreach (var usuario in usuarios)
                    {
                        if (usuario.NombreUsuario == usuarioSeleccionado)
                        {
                            usuarioBaja = usuario;
                            break;
                        }
                    }

                    if (usuarioBaja is not null)
                    {
                        Thread actualizarListaThread = new Thread(() => ActualizarListaUsuarios(usuarioBaja));
                        actualizarListaThread.Start();

                        usuarios.Remove(usuarioBaja);
                        UsuarioDB.Delete(usuarioBaja.GenerarIdUsuario());
                        MessageBox.Show($"Usuario {usuarioSeleccionado} dado de baja exitosamente.", "Baja de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"No se encontró el usuario {usuarioSeleccionado}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "btn_bajausuarios_Click");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra un cuadro de diálogo de selección con opciones de baja de usuarios.
        /// </summary>
        /// <param name="labelText">Texto que se mostrará como etiqueta.</param>
        /// <param name="caption">Texto del título del cuadro de diálogo.</param>
        /// <param name="options">Opciones a mostrar en la lista.</param>
        /// <param name="userData">Información adicional de las opciones.</param>
        /// <returns>La opción seleccionada por el usuario o cadena vacía si hay un error.</returns>
        private string PromptSelectionBaja(string labelText, string caption, List<string> options, List<string> userData)
        {
            try
            {
                Form prompt = new Form();
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.Width = 600;
                prompt.Height = 300;
                prompt.Text = caption;

                Label textLabel = new Label() { Left = 50, Top = 20, Width = 500, Text = labelText };
                ListBox listBox = new ListBox() { Left = 50, Top = 50, Width = 500, Height = 150 };

                options.Zip(userData, (opt, data) => $"{opt} - {data}")
                    .ToList()
                    .ForEach(option => listBox.Items.Add(option));

                Button confirmation = new Button() { Text = "Ok", Left = 450, Width = 70, Top = 220 };
                confirmation.Click += (sender, e) =>
                {
                    if (listBox.SelectedItem != null)
                    {
                        prompt.Close();
                    }
                };

                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(listBox);

                listBox.KeyPress += (sender, e) =>
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        confirmation.PerformClick();
                    }
                };

                prompt.ShowDialog();

                if (listBox.SelectedItem != null)
                {
                    return listBox.SelectedItem.ToString().Split("-")[0].Trim();
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "PromptSelectionBaja");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }


        /// <summary>
        /// Evento de clic del botón para enviar el stock al servidor.
        /// </summary>
        private async void btn_enviarstock_Click(object sender, EventArgs e)
        {
            btn_enviarstock.Enabled = false;

            cts = new CancellationTokenSource();
            tiempoRestante = 5;

            try
            {

                DialogResult result = await MostrarMessageBoxConConteo(tiempoRestante);

                if (result == DialogResult.OK)
                {

                    try
                    {
                        await Task.Run(async () =>
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                if (cts.Token.IsCancellationRequested)
                                    break;

                                await Task.Delay(1000);
                            }

                            if (!cts.Token.IsCancellationRequested)
                                await Archivos.GuardarStockXMLAsync(Stock.ObtenerDatosStock(), cts.Token);
                        }, cts.Token);

                        if (!cts.Token.IsCancellationRequested)
                        {
                            MessageBox.Show("Operación completada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        MessageBox.Show("Operación cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    cts.Cancel();
                    MessageBox.Show("Operación cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                btn_enviarstock.Enabled = true;
            }
        }

        /// <summary>
        /// Muestra un cuadro de diálogo de mensaje con un conteo regresivo antes de confirmar.
        /// </summary>
        /// <param name="tiempoRestante">Tiempo restante en segundos.</param>
        /// <returns>El resultado del cuadro de diálogo (OK o Cancelar).</returns>
        private async Task<DialogResult> MostrarMessageBoxConConteo(int tiempoRestante)
        {
            string mensaje = $"La operación se realizara en {tiempoRestante} segundos. Si desea cancelar el envio, pulse CANCELAR";
            var result = await Task.Run(() => MessageBox.Show(mensaje, "Conteo Regresivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning));

            return result;
        }


        /// <summary>
        /// Muestra un cuadro de diálogo de selección para elegir el atributo a modificar.
        /// </summary>
        /// <returns>El atributo seleccionado por el usuario o cadena vacía si hay un error.</returns>
        private string PromptSeleccionModificacion()
        {
            List<string> opcionesModificacion = new List<string> { "NombreUsuario", "DNIUsuario", "Contrasenia" };
            return PromptSelection("Seleccione el atributo a modificar:", "Modificar Usuario", opcionesModificacion);
        }

        /// <summary>
        /// Evento de clic del botón para modificar un usuario seleccionado.
        /// </summary>
        private void btn_modificarusuario_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> nombresUsuarios = new List<string>();
                List<string> informacionUsuarios = new List<string>();

                foreach (var usuario in usuarios)
                {
                    nombresUsuarios.Add(usuario.NombreUsuario);
                    informacionUsuarios.Add($"{usuario.GenerarIdUsuario()}, {usuario.Tipo}");
                }

                string usuarioSeleccionado = PromptSelectionBaja("Seleccione el usuario a modificar:", "Modificar Usuario", nombresUsuarios, informacionUsuarios);

                if (!string.IsNullOrEmpty(usuarioSeleccionado))
                {
                    Usuario usuarioAModificar = usuarios.FirstOrDefault(u => u.NombreUsuario == usuarioSeleccionado);

                    if (usuarioAModificar is not null)
                    {

                        string atributoAModificar = PromptSeleccionModificacion();

                        string nuevoValor = string.Empty;

                        switch (atributoAModificar)
                        {
                            case "NombreUsuario":
                                nuevoValor = PromptInputText($"Ingrese el nuevo {atributoAModificar} del usuario:", "Modificar Usuario");
                                usuarioAModificar.NombreUsuario = nuevoValor;
                                break;
                            case "DNIUsuario":
                                string nuevoDniInput = PromptInputNum($"Ingrese el nuevo {atributoAModificar} del usuario:", "Modificar Usuario");
                                if (int.TryParse(nuevoDniInput, out int nuevoDni))
                                {
                                    usuarioAModificar.DniUsuario = nuevoDni;
                                }
                                else
                                {
                                    MessageBox.Show("Ingrese un DNI válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                break;
                            case "Contrasenia":
                                nuevoValor = PromptInputText($"Ingrese la nueva {atributoAModificar} del usuario:", "Modificar Usuario");
                                usuarioAModificar.Contrasenia = nuevoValor;
                                break;
                        }

                        Thread actualizarListaThread = new Thread(() => ActualizarListaUsuarios(usuarioAModificar));
                        actualizarListaThread.Start();

                        UsuarioDB.Update(atributoAModificar, nuevoValor, usuarioAModificar.GenerarIdUsuario());
                        MessageBox.Show($"Usuario {usuarioSeleccionado} modificado exitosamente.", "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"No se encontró el usuario {usuarioSeleccionado}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Archivos.AgregarErrorLog(ex, nameof(VistaSupervisor), "btn_modificarusuario_Click");
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
