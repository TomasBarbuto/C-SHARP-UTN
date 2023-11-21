using Entidades;
using Entidades.Productos;
using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Entidades.Stock;
using static Entidades.Usuarios.Usuario;
using static System.Windows.Forms.DataFormats;

namespace ParcialLaboratorio2
{
    /// <summary>
    /// Clase parcial que representa el formulario de la interfaz de usuario para el operario.
    /// Permite al operario realizar diversas operaciones, como la producción de bizcochuelos, gelatinas y flanes, y ver el stock actual, entre otras funciones.
    /// </summary>
    public partial class VistaOperario : Form
    {
        private Operario operario;
        Bizcochuelo bizcochuelo = new Bizcochuelo("Bizochuelo");
        Gelatina gelatina = new Gelatina("Gelatina");
        Flan flan = new Flan("Flan");

        /// <summary>
        /// Inicializa una nueva instancia de la clase VistaOperario con el operario especificado.
        /// </summary>
        /// <param name="operario">El operario que utiliza el formulario.</param>
        public VistaOperario(Operario operario)
        {
            InitializeComponent();
            this.operario = operario;
        }

        /// <summary>
        /// Maneja el evento de carga de la vista del operario.
        /// Actualiza la visualización de la vista según el tipo de usuario (administrador o no).
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void VistaOperario_Load(object sender, EventArgs e)
        {
            Operario operario = this.operario;
            lbl_nombreusuario.Text = operario.GenerarIdUsuario();
            Eventos.ProduccionRealizada += VistaOperario_ProduccionRealizada;
            if (operario.Tipo == TipoUsuario.Administrador)
            {
                btn_volver.Visible = true;
                btn_cerrarsesion.Visible = false;
            }
            else
            {
                btn_volver.Visible = false;
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "cerrar sesión".
        /// Muestra un cuadro de diálogo para confirmar si el usuario desea cerrar sesión y, si es así, cierra la sesión y muestra la vista de inicio.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_cerrarsesion_Click(object sender, EventArgs e)
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

                    if (operario is Supervisor)
                    {
                        this.Close();
                    }
                    else
                    {
                        this.Hide();
                    }
                }
            }
        }
        /// <summary>
        /// Maneja el evento de clic en el botón "ver stock".
        /// Muestra un cuadro de diálogo con la información del stock actual.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_stock_Click(object sender, EventArgs e)
        {
            Form StockDisponible = new Form();
            StockDisponible.Text = "Stock Disponible";
            StockDisponible.Size = new Size(500, 400);
            StockDisponible.FormBorderStyle = FormBorderStyle.FixedDialog;
            StockDisponible.StartPosition = FormStartPosition.CenterScreen;

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;

            DataGridView dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView.RowTemplate.Height = 40;

            dataGridView.Columns.Add("Material", "Material");
            dataGridView.Columns.Add("Cantidad", "Cantidad");

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.ColumnHeadersHeight = 40;

            Dictionary<string, int> diccionarioStock = Stock.ObtenerDatosStock();

            foreach (var item in diccionarioStock)
            {
                int cantidad = item.Value;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView, item.Key, cantidad);

                if (cantidad >= 1 && cantidad <= 20)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (cantidad == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.IndianRed;
                }

                dataGridView.Rows.Add(row);
            }

            tableLayoutPanel.Controls.Add(dataGridView, 0, 0);

            StockDisponible.Controls.Add(tableLayoutPanel);

            StockDisponible.ShowDialog();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "fabricar bizcochuelo".
        /// Produce la cantidad específica de bizcochuelos de diferentes sabores según las cantidades ingresadas.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private async Task ProducirBizcochuelosAsync(int cantidadChocolate, int cantidadVainilla, int cantidadCoco)
        {
            await Task.Delay(5000);

            int fabricadosChocolate = 0;
            int fabricadosVainilla = 0;
            int fabricadosCoco = 0;
            int noFabricadosChocolate = 0;
            int noFabricadosVainilla = 0;
            int noFabricadosCoco = 0;
            int totalFabricados = 0;
            StringBuilder producidos = new StringBuilder();
            StringBuilder noProducidos = new StringBuilder();

            for (int i = 0; i < cantidadChocolate; i++)
            {
                if (bizcochuelo.Producir(Sabor.Chocolate))
                {
                    fabricadosChocolate++;
                    totalFabricados += fabricadosChocolate;
                }
                else
                {
                    noFabricadosChocolate++;
                }
            }

            if (noFabricadosChocolate > 0)
            {
                noProducidos.AppendLine($"Bizcochuelo de chocolate = {noFabricadosChocolate}");
            }

            for (int i = 0; i < cantidadVainilla; i++)
            {
                if (bizcochuelo.Producir(Sabor.Vainilla))
                {
                    fabricadosVainilla++;
                    totalFabricados += fabricadosVainilla;
                }
                else
                {
                    noFabricadosVainilla++;
                }
            }

            if (noFabricadosVainilla > 0)
            {
                noProducidos.AppendLine($"Bizcochuelo de vainilla = {noFabricadosVainilla}");
            }

            for (int i = 0; i < cantidadCoco; i++)
            {
                if (bizcochuelo.Producir(Sabor.Coco))
                {
                    fabricadosCoco++;
                    totalFabricados += fabricadosCoco;
                }
                else
                {
                    noFabricadosCoco++;
                }
            }

            if (noFabricadosCoco > 0)
            {
                noProducidos.AppendLine($"Bizcochuelo de coco= {noFabricadosCoco}");
            }

            if (noProducidos.Length > 0)
            {
                MessageBox.Show($"No hay suficiente stock para fabricar algunos productos:\n\n{noProducidos}", "Sin Suficiente Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Eventos.Invoke("Bizcochuelos", totalFabricados);
            }

            cntd_bizchoco.Value = 0;
            cntd_bizvainilla.Value = 0;
            cntd_bizcoco.Value = 0;
        }

        /// <summary>
        /// Maneja el evento Click del botón de producción de bizcochuelo.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private async void btn_bizcochuelo_Click(object sender, EventArgs e)
        {
            int cantidadChocolate = (int)cntd_bizchoco.Value;
            int cantidadVainilla = (int)cntd_bizvainilla.Value;
            int cantidadCoco = (int)cntd_bizcoco.Value;

            btn_bizcochuelo.Enabled = false;

            await ProducirBizcochuelosAsync(cantidadChocolate, cantidadVainilla, cantidadCoco);

            btn_bizcochuelo.Enabled = true;
        }

        /// <summary>
        /// Maneja el evento de producción realizada.
        /// Muestra un mensaje informando sobre la producción completada.
        /// </summary>
        /// <param name="producto">El nombre del producto producido.</param>
        /// <param name="cantidad">La cantidad de unidades producidas.</param>
        private void VistaOperario_ProduccionRealizada(string producto, int cantidad)
        {
            if (this.ContainsFocus)
            {
                MessageBox.Show($"¡La producción de {producto} ({cantidad} unidades) ha sido completada!", "Producción Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "fabricar gelatina".
        /// Produce la cantidad específica de gelatinas de diferentes sabores según las cantidades ingresadas.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private async Task ProducirGelatinasAsync(int cantidadFrambuesa, int cantidadFrutilla, int cantidadCereza)
        {
            await Task.Delay(5000);

            int fabricadosFrambuesa = 0;
            int fabricadosFrutilla = 0;
            int fabricadosCereza = 0;
            int noFabricadosFrambuesa = 0;
            int noFabricadosFrutilla = 0;
            int noFabricadosCereza = 0;
            StringBuilder producidos = new StringBuilder();
            StringBuilder noProducidos = new StringBuilder();

            for (int i = 0; i < cantidadFrambuesa; i++)
            {
                if (gelatina.Producir(Sabor.Frambuesa))
                {
                    fabricadosFrambuesa++;
                }
                else
                {
                    noFabricadosFrambuesa++;
                }
            }

            if (noFabricadosFrambuesa > 0)
            {
                noProducidos.AppendLine($"Gelatina de frambuesa = {noFabricadosFrambuesa}");
            }

            for (int i = 0; i < cantidadFrutilla; i++)
            {
                if (gelatina.Producir(Sabor.Frutilla))
                {
                    fabricadosFrutilla++;
                }
                else
                {
                    noFabricadosFrutilla++;
                }
            }

            if (noFabricadosFrutilla > 0)
            {
                noProducidos.AppendLine($"Gelatina de frutilla = {noFabricadosFrutilla}");
            }

            for (int i = 0; i < cantidadCereza; i++)
            {
                if (gelatina.Producir(Sabor.Cereza))
                {
                    fabricadosCereza++;
                }
                else
                {
                    noFabricadosCereza++;
                }
            }

            if (noFabricadosCereza > 0)
            {
                noProducidos.AppendLine($"Gelatina de cereza = {noFabricadosCereza}");
            }

            if (noProducidos.Length > 0)
            {
                MessageBox.Show($"No hay suficiente stock para fabricar algunos productos:\n\n{noProducidos.ToString()}", "Sin Suficiente Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Eventos.Invoke("Gelatinas", fabricadosFrambuesa + fabricadosFrutilla + fabricadosCereza);
            }

            cntd_gelframbuesa.Value = 0;
            cntd_gelfrutilla.Value = 0;
            cntd_gelcereza.Value = 0;
        }

        /// <summary>
        /// Maneja el evento Click del botón de producción de Gelatinas.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private async void btn_gelatina_Click(object sender, EventArgs e)
        {
            int cantidadFrambuesa = (int)cntd_gelframbuesa.Value;
            int cantidadFrutilla = (int)cntd_gelfrutilla.Value;
            int cantidadCereza = (int)cntd_gelcereza.Value;

            btn_gelatina.Enabled = false;

            await ProducirGelatinasAsync(cantidadFrambuesa, cantidadFrutilla, cantidadCereza);

            btn_gelatina.Enabled = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "fabricar flan".
        /// Produce la cantidad específica de flanes de diferentes sabores según las cantidades ingresadas.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private async Task ProducirFlanesAsync(int cantidadCaramelo, int cantidadChocolate, int cantidadVainilla)
        {
            await Task.Delay(5000);

            int fabricadosCaramelo = 0;
            int fabricadosChocolate = 0;
            int fabricadosVainilla = 0;
            int noFabricadosCaramelo = 0;
            int noFabricadosChocolate = 0;
            int noFabricadosVainilla = 0;

            StringBuilder producidos = new StringBuilder();
            StringBuilder noProducidos = new StringBuilder();

            for (int i = 0; i < cantidadCaramelo; i++)
            {
                if (flan.Producir(Sabor.Caramelo))
                {
                    fabricadosCaramelo++;
                }
                else
                {
                    noFabricadosCaramelo++;
                }
            }

            if (fabricadosCaramelo > 0)
            {
                producidos.AppendLine($"Flan de caramelo = {fabricadosCaramelo}");
            }
            if (noFabricadosCaramelo > 0)
            {
                noProducidos.AppendLine($"Flan de caramelo = {noFabricadosCaramelo}");
            }

            for (int i = 0; i < cantidadChocolate; i++)
            {
                if (flan.Producir(Sabor.Chocolate))
                {
                    fabricadosChocolate++;
                }
                else
                {
                    noFabricadosChocolate++;
                }
            }

            if (fabricadosChocolate > 0)
            {
                producidos.AppendLine($"Flan de chocolate = {fabricadosChocolate}");
            }
            if (noFabricadosChocolate > 0)
            {
                noProducidos.AppendLine($"Flan de chocolate = {noFabricadosChocolate}");
            }

            for (int i = 0; i < cantidadVainilla; i++)
            {
                if (flan.Producir(Sabor.Vainilla))
                {
                    fabricadosVainilla++;
                }
                else
                {
                    noFabricadosVainilla++;
                }
            }

            if (fabricadosVainilla > 0)
            {
                producidos.AppendLine($"Flan de vainilla = {fabricadosVainilla}");
            }
            if (noFabricadosVainilla > 0)
            {
                noProducidos.AppendLine($"Flan de vainilla = {noFabricadosVainilla}");
            }

            if (noProducidos.Length > 0)
            {
                MessageBox.Show($"No hay suficiente stock para fabricar algunos productos:\n\n{noProducidos.ToString()}", "Sin Suficiente Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Eventos.Invoke("Flanes", fabricadosCaramelo + fabricadosChocolate + fabricadosVainilla);
            }

            cntd_flancaramelo.Value = 0;
            cntd_flanchoco.Value = 0;
            cntd_flanvainilla.Value = 0;
        }

        /// <summary>
        /// Maneja el evento Click del botón de producción de Flanes.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private async void btn_flan_Click(object sender, EventArgs e)
        {
            int cantidadCaramelo = (int)cntd_flancaramelo.Value;
            int cantidadChocolate = (int)cntd_flanchoco.Value;
            int cantidadVainilla = (int)cntd_flanvainilla.Value;

            btn_flan.Enabled = false;

            await ProducirFlanesAsync(cantidadCaramelo, cantidadChocolate, cantidadVainilla);

            btn_flan.Enabled = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "volver".
        /// Muestra el formulario del supervisor correspondiente y oculta el formulario actual del operario.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_volver_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is VistaSupervisor)
                {
                    this.Hide();
                    form.Show();
                }
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "cocina".
        /// Muestra el formulario de la vista de cocina y pasa los datos del operario actual a la vista de cocina.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_cocina_Click(object sender, EventArgs e)
        {

            Operario operario = this.operario;
            bool hayInstancia = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is VistaCocina)
                {
                    hayInstancia = true;
                    form.Show();
                }
            }

            if (!hayInstancia)
            {
                VistaCocina vistaCocina = new VistaCocina(operario);
                vistaCocina.Show();
            }
        }
    }
}
