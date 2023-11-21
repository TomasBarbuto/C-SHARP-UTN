using Entidades;
using Entidades.Productos;
using Entidades.Usuarios;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Entidades.Stock;
using static Entidades.Usuarios.Usuario;

namespace ParcialLaboratorio2
{
    public partial class VistaCocina : Form
    {
        private Operario operario;
        Bizcochuelo bizcochuelo = new Bizcochuelo("Bizochuelo");
        Gelatina gelatina = new Gelatina("Gelatina");
        Flan flan = new Flan("Flan");

        public VistaCocina(Operario operario)
        {
            InitializeComponent();
            this.operario = operario;
        }

        /// <summary>
        /// Método que carga la vista de la cocina y establece el IdUsuario en el formulario.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void VistaCocina_Load(object sender, EventArgs e)
        {
            lbl_nombreusuario.Text = operario.IdUsuario;
            Eventos.ProduccionRealizada += VistaCocina_ProduccionRealizada;
        }

        /// <summary>
        /// Maneja el evento de producción realizada en la vista de cocina.
        /// </summary>
        /// <param name="producto">Nombre del producto producido.</param>
        /// <param name="cantidad">Cantidad de unidades producidas.</param>
        private void VistaCocina_ProduccionRealizada(string producto, int cantidad)
        {
            if (this.ContainsFocus)
            {
                MessageBox.Show($"¡La producción de {producto} ({cantidad} unidades) ha sido completada!", "Producción Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Método que maneja el evento de clic en el botón "Volver Operario" para cerrar la vista de la cocina.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_volveroperario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Método que muestra el stock de los productos terminados en un cuadro de diálogo.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_stock_Click(object sender, EventArgs e)
        {
            Dictionary<string, Dictionary<Sabor, int>> todosLosStocks = new Dictionary<string, Dictionary<Sabor, int>>
            {
                { "Bizcochuelo", Bizcochuelo.Cantidades },
                { "Gelatina", Gelatina.Cantidades },
                { "Flan", Flan.Cantidades }
            };

            bool todasCero = true;

            foreach (var stock in todosLosStocks)
            {
                foreach (var cantidad in stock.Value.Values)
                {
                    if (cantidad != 0)
                    {
                        todasCero = false;
                        break;
                    }
                }

                if (!todasCero)
                {
                    break;
                }
            }

            if (todasCero)
            {
                MessageBox.Show("No hay stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Form StockDisponible = new Form();
                StockDisponible.Text = "Stock Disponible";
                StockDisponible.Size = new Size(800, 400);
                StockDisponible.StartPosition = FormStartPosition.CenterScreen;

                DataGridView dataGridView = new DataGridView();
                ConfigureDataGridView(dataGridView);
                StockDisponible.Controls.Add(dataGridView);

                foreach (var stock in todosLosStocks)
                {
                    AddRowsToDataGridView(dataGridView, stock.Key, stock.Value);
                }

                StockDisponible.ShowDialog();
            }

            void ConfigureDataGridView(DataGridView dgv)
            {
                dgv.Dock = DockStyle.Fill;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv.RowTemplate.Height = 40;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dgv.ColumnHeadersHeight = 40;
                dgv.Columns.Add("Producto", "Producto");
                dgv.Columns.Add("Sabor", "Sabor");
                dgv.Columns.Add("Cantidad", "Cantidad");
            }

            void AddRowsToDataGridView(DataGridView dgv, string producto, Dictionary<Sabor, int> diccionario)
            {
                foreach (var item in diccionario)
                {
                    Sabor sabor = item.Key;
                    int cantidad = item.Value;
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgv, producto, sabor.ToString(), cantidad);
                    SetRowBackgroundColor(row, cantidad);
                    dgv.Rows.Add(row);
                }
            }

            void SetRowBackgroundColor(DataGridViewRow row, int cantidad)
            {
                if (cantidad >= 1 && cantidad <= 20)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (cantidad == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.IndianRed;
                }
            }
        }


        /// <summary>
        /// Maneja el evento de clic en el botón de bizcochuelo, cocina diferentes sabores de bizcochuelo según la cantidad especificada y muestra mensajes según el resultado.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_bizcochuelo_Click(object sender, EventArgs e)
        {
            int cantidadChocolate = (int)cntd_bizchoco.Value;
            int cantidadVainilla = (int)cntd_bizvainilla.Value;
            int cantidadCoco = (int)cntd_bizcoco.Value;
            Dictionary<string, int> cocinados = new Dictionary<string, int>();

            if (cantidadCoco == 0 && cantidadChocolate == 0 && cantidadVainilla == 0)
            {
                MessageBox.Show("No ingresó cantidades a cocinar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < cantidadChocolate; i++)
                {
                    if (bizcochuelo.Cocinar(Sabor.Chocolate, 1))
                    {
                        if (cocinados.ContainsKey("Chocolate"))
                        {
                            cocinados["Chocolate"]++;
                        }
                        else
                        {
                            cocinados["Chocolate"] = 1;
                        }
                    }
                }

                for (int i = 0; i < cantidadVainilla; i++)
                {
                    if (bizcochuelo.Cocinar(Sabor.Vainilla, 1))
                    {
                        if (cocinados.ContainsKey("Vainilla"))
                        {
                            cocinados["Vainilla"]++;
                        }
                        else
                        {
                            cocinados["Vainilla"] = 1;
                        }
                    }
                }

                for (int i = 0; i < cantidadCoco; i++)
                {
                    if (bizcochuelo.Cocinar(Sabor.Coco, 1))
                    {
                        if (cocinados.ContainsKey("Coco"))
                        {
                            cocinados["Coco"]++;
                        }
                        else
                        {
                            cocinados["Coco"] = 1;
                        }
                    }
                }

                if (cocinados.Count > 0)
                {
                    StringBuilder mensaje = new StringBuilder();
                    mensaje.AppendLine("Se han cocinado los siguientes Bizcochuelos");

                    foreach (var item in cocinados)
                    {
                        mensaje.AppendLine($"bizcochuelos de {item.Key} = {item.Value} ");
                    }

                    MessageBox.Show(mensaje.ToString(), "Producción de bizcochuelo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(bizcochuelo.MensajeDeError("Cocinar"), "Producción de bizcochuelo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cntd_bizchoco.Value = 0;
                cntd_bizvainilla.Value = 0;
                cntd_bizcoco.Value = 0;
            }
        }



        /// <summary>
        /// Maneja el evento de clic en el botón de gelatina, cocina diferentes sabores de gelatina según la cantidad especificada y muestra mensajes según el resultado.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_gelatina_Click(object sender, EventArgs e)
        {
            int cantidadframbuesa = (int)cntd_gelframbuesa.Value;
            int cantidadfrutilla = (int)cntd_gelfrutilla.Value;
            int cantidadcereza = (int)cntd_gelcereza.Value;
            Dictionary<string, int> cocinados = new Dictionary<string, int>();

            if (cantidadframbuesa == 0 && cantidadfrutilla == 0 && cantidadcereza == 0)
            {
                MessageBox.Show("No ingresó cantidades a cocinar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < cantidadframbuesa; i++)
                {
                    if (gelatina.Cocinar(Sabor.Frambuesa, 1))
                    {
                        if (cocinados.ContainsKey("Frambuesa"))
                        {
                            cocinados["Frambuesa"]++;
                        }
                        else
                        {
                            cocinados["Frambuesa"] = 1;
                        }
                    }
                }

                for (int i = 0; i < cantidadfrutilla; i++)
                {
                    if (gelatina.Cocinar(Sabor.Frutilla, 1))
                    {
                        if (cocinados.ContainsKey("Frutilla"))
                        {
                            cocinados["Frutilla"]++;
                        }
                        else
                        {
                            cocinados["Frutilla"] = 1;
                        }
                    }
                }

                for (int i = 0; i < cantidadcereza; i++)
                {
                    if (gelatina.Cocinar(Sabor.Cereza, 1))
                    {
                        if (cocinados.ContainsKey("Cereza"))
                        {
                            cocinados["Cereza"]++;
                        }
                        else
                        {
                            cocinados["Cereza"] = 1;
                        }
                    }
                }

                if (cocinados.Count > 0)
                {
                    StringBuilder mensaje = new StringBuilder();
                    mensaje.AppendLine("Se han cocinado las siguientes Gelatinas");

                    foreach (var item in cocinados)
                    {
                        mensaje.AppendLine($"Gelatinas de {item.Key} = {item.Value} ");
                    }

                    MessageBox.Show(mensaje.ToString(), "Producción de gelatina", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(gelatina.MensajeDeError("Cocinar"), "Producción de gelatina", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cntd_gelframbuesa.Value = 0;
                cntd_gelfrutilla.Value = 0;
                cntd_gelcereza.Value = 0;
            }
        }


        /// <summary>
        /// Maneja el evento de clic en el botón de flan, cocina diferentes sabores de flan según la cantidad especificada y muestra mensajes según el resultado.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_flan_Click(object sender, EventArgs e)
        {
            int cantidadCaramelo = (int)cntd_flancaramelo.Value;
            int cantidadChocolate = (int)cntd_flanchoco.Value;
            int cantidadVainilla = (int)cntd_flanvainilla.Value;
            Dictionary<string, int> cocinados = new Dictionary<string, int>();

            if (cantidadCaramelo == 0 && cantidadChocolate == 0 && cantidadVainilla == 0)
            {
                MessageBox.Show("No ingresó cantidades a cocinar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < cantidadCaramelo; i++)
                {
                    if (flan.Cocinar(Sabor.Caramelo, 1))
                    {
                        if (cocinados.ContainsKey("Caramelo"))
                        {
                            cocinados["Caramelo"]++;
                        }
                        else
                        {
                            cocinados["Caramelo"] = 1;
                        }
                    }
                }

                for (int i = 0; i < cantidadChocolate; i++)
                {
                    if (flan.Cocinar(Sabor.Chocolate, 1))
                    {
                        if (cocinados.ContainsKey("Chocolate"))
                        {
                            cocinados["Chocolate"]++;
                        }
                        else
                        {
                            cocinados["Chocolate"] = 1;
                        }
                    }
                }

                for (int i = 0; i < cantidadVainilla; i++)
                {
                    if (flan.Cocinar(Sabor.Vainilla, 1))
                    {
                        if (cocinados.ContainsKey("Vainilla"))
                        {
                            cocinados["Vainilla"]++;
                        }
                        else
                        {
                            cocinados["Vainilla"] = 1;
                        }
                    }
                }

                if (cocinados.Count > 0)
                {
                    StringBuilder mensaje = new StringBuilder();
                    mensaje.AppendLine("Se han cocinado los siguientes Flanes");

                    foreach (var item in cocinados)
                    {
                        mensaje.AppendLine($"Flanes de {item.Key} = {item.Value} ");
                    }

                    MessageBox.Show(mensaje.ToString(), "Producción de Flan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(flan.MensajeDeError("Cocinar"), "Producción de Flan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cntd_flancaramelo.Value = 0;
                cntd_flanchoco.Value = 0;
                cntd_flanvainilla.Value = 0;
            }
        }
    }
}
