namespace ParcialLaboratorio2
{
    partial class VistaSupervisor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaSupervisor));
            label10 = new Label();
            dt_fechahora = new DateTimePicker();
            lbl_nombreusuario = new Label();
            btn_consultarstock = new Button();
            btn_cerrarsesion = new Button();
            btn_produccion = new Button();
            btn_pedirstock = new Button();
            dgv_supervisor = new DataGridView();
            btn_listaoperarios = new Button();
            btn_registrococina = new Button();
            btn_regproducido = new Button();
            btn_altausuarios = new Button();
            btn_bajausuarios = new Button();
            btn_modificarusuario = new Button();
            btn_enviarstock = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_supervisor).BeginInit();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.FromArgb(191, 113, 44);
            label10.Location = new Point(570, 21);
            label10.Name = "label10";
            label10.Size = new Size(294, 55);
            label10.TabIndex = 11;
            label10.Text = "ZAFIRA S.A";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // dt_fechahora
            // 
            dt_fechahora.Location = new Point(31, 21);
            dt_fechahora.Margin = new Padding(3, 2, 3, 2);
            dt_fechahora.Name = "dt_fechahora";
            dt_fechahora.Size = new Size(249, 23);
            dt_fechahora.TabIndex = 15;
            // 
            // lbl_nombreusuario
            // 
            lbl_nombreusuario.AutoSize = true;
            lbl_nombreusuario.Location = new Point(31, 54);
            lbl_nombreusuario.Margin = new Padding(3, 2, 3, 2);
            lbl_nombreusuario.Name = "lbl_nombreusuario";
            lbl_nombreusuario.Size = new Size(71, 15);
            lbl_nombreusuario.TabIndex = 14;
            lbl_nombreusuario.Text = "OP40881706";
            lbl_nombreusuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_consultarstock
            // 
            btn_consultarstock.Location = new Point(695, 206);
            btn_consultarstock.Margin = new Padding(3, 2, 3, 2);
            btn_consultarstock.Name = "btn_consultarstock";
            btn_consultarstock.Size = new Size(132, 24);
            btn_consultarstock.TabIndex = 19;
            btn_consultarstock.Text = "Consultar Stock";
            btn_consultarstock.UseVisualStyleBackColor = true;
            btn_consultarstock.Click += btn_consultarstock_Click;
            // 
            // btn_cerrarsesion
            // 
            btn_cerrarsesion.Location = new Point(31, 291);
            btn_cerrarsesion.Margin = new Padding(3, 2, 3, 2);
            btn_cerrarsesion.Name = "btn_cerrarsesion";
            btn_cerrarsesion.Size = new Size(132, 24);
            btn_cerrarsesion.TabIndex = 17;
            btn_cerrarsesion.Text = "Cerrar Sesion";
            btn_cerrarsesion.UseVisualStyleBackColor = true;
            btn_cerrarsesion.Click += btn_cerrarsesion_Click;
            // 
            // btn_produccion
            // 
            btn_produccion.Location = new Point(695, 291);
            btn_produccion.Margin = new Padding(3, 2, 3, 2);
            btn_produccion.Name = "btn_produccion";
            btn_produccion.Size = new Size(132, 24);
            btn_produccion.TabIndex = 21;
            btn_produccion.Text = "Produccion";
            btn_produccion.UseVisualStyleBackColor = true;
            btn_produccion.Click += btn_produccion_Click;
            // 
            // btn_pedirstock
            // 
            btn_pedirstock.Location = new Point(695, 234);
            btn_pedirstock.Margin = new Padding(3, 2, 3, 2);
            btn_pedirstock.Name = "btn_pedirstock";
            btn_pedirstock.Size = new Size(132, 24);
            btn_pedirstock.TabIndex = 20;
            btn_pedirstock.Text = "Pedir Stock";
            btn_pedirstock.UseVisualStyleBackColor = true;
            btn_pedirstock.Click += btn_pedirstock_Click;
            // 
            // dgv_supervisor
            // 
            dgv_supervisor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_supervisor.Location = new Point(214, 148);
            dgv_supervisor.Margin = new Padding(3, 2, 3, 2);
            dgv_supervisor.Name = "dgv_supervisor";
            dgv_supervisor.RowTemplate.Height = 29;
            dgv_supervisor.Size = new Size(441, 166);
            dgv_supervisor.TabIndex = 23;
            // 
            // btn_listaoperarios
            // 
            btn_listaoperarios.Location = new Point(31, 148);
            btn_listaoperarios.Margin = new Padding(3, 2, 3, 2);
            btn_listaoperarios.Name = "btn_listaoperarios";
            btn_listaoperarios.Size = new Size(132, 24);
            btn_listaoperarios.TabIndex = 24;
            btn_listaoperarios.Text = "Listar Operarios";
            btn_listaoperarios.UseVisualStyleBackColor = true;
            btn_listaoperarios.Click += btn_listaoperarios_Click;
            // 
            // btn_registrococina
            // 
            btn_registrococina.Location = new Point(695, 177);
            btn_registrococina.Margin = new Padding(3, 2, 3, 2);
            btn_registrococina.Name = "btn_registrococina";
            btn_registrococina.Size = new Size(132, 24);
            btn_registrococina.TabIndex = 25;
            btn_registrococina.Text = "Prod. Cocinados";
            btn_registrococina.UseVisualStyleBackColor = true;
            btn_registrococina.Click += btn_RegistroCocina_Click;
            // 
            // btn_regproducido
            // 
            btn_regproducido.Location = new Point(695, 148);
            btn_regproducido.Margin = new Padding(3, 2, 3, 2);
            btn_regproducido.Name = "btn_regproducido";
            btn_regproducido.Size = new Size(132, 24);
            btn_regproducido.TabIndex = 26;
            btn_regproducido.Text = "Prod. Fabricados";
            btn_regproducido.UseVisualStyleBackColor = true;
            btn_regproducido.Click += btn_RegProducido_Click;
            // 
            // btn_altausuarios
            // 
            btn_altausuarios.Location = new Point(31, 193);
            btn_altausuarios.Margin = new Padding(3, 2, 3, 2);
            btn_altausuarios.Name = "btn_altausuarios";
            btn_altausuarios.Size = new Size(132, 24);
            btn_altausuarios.TabIndex = 27;
            btn_altausuarios.Text = "Alta Usuarios";
            btn_altausuarios.UseVisualStyleBackColor = true;
            btn_altausuarios.Click += btn_altausuarios_Click;
            // 
            // btn_bajausuarios
            // 
            btn_bajausuarios.Location = new Point(31, 221);
            btn_bajausuarios.Margin = new Padding(3, 2, 3, 2);
            btn_bajausuarios.Name = "btn_bajausuarios";
            btn_bajausuarios.Size = new Size(132, 24);
            btn_bajausuarios.TabIndex = 28;
            btn_bajausuarios.Text = "Baja Usuarios";
            btn_bajausuarios.UseVisualStyleBackColor = true;
            btn_bajausuarios.Click += btn_bajausuarios_Click;
            // 
            // btn_modificarusuario
            // 
            btn_modificarusuario.Location = new Point(31, 250);
            btn_modificarusuario.Margin = new Padding(3, 2, 3, 2);
            btn_modificarusuario.Name = "btn_modificarusuario";
            btn_modificarusuario.Size = new Size(132, 24);
            btn_modificarusuario.TabIndex = 29;
            btn_modificarusuario.Text = "Mod. Usuarios";
            btn_modificarusuario.UseVisualStyleBackColor = true;
            btn_modificarusuario.Click += btn_modificarusuario_Click;
            // 
            // btn_enviarstock
            // 
            btn_enviarstock.Location = new Point(695, 262);
            btn_enviarstock.Margin = new Padding(3, 2, 3, 2);
            btn_enviarstock.Name = "btn_enviarstock";
            btn_enviarstock.Size = new Size(132, 24);
            btn_enviarstock.TabIndex = 30;
            btn_enviarstock.Text = "Enviar Stock";
            btn_enviarstock.UseVisualStyleBackColor = true;
            btn_enviarstock.Click += btn_enviarstock_Click;
            // 
            // VistaSupervisor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(861, 346);
            ControlBox = false;
            Controls.Add(btn_enviarstock);
            Controls.Add(btn_modificarusuario);
            Controls.Add(btn_bajausuarios);
            Controls.Add(btn_altausuarios);
            Controls.Add(btn_regproducido);
            Controls.Add(btn_registrococina);
            Controls.Add(btn_listaoperarios);
            Controls.Add(dgv_supervisor);
            Controls.Add(btn_produccion);
            Controls.Add(btn_pedirstock);
            Controls.Add(btn_consultarstock);
            Controls.Add(btn_cerrarsesion);
            Controls.Add(dt_fechahora);
            Controls.Add(lbl_nombreusuario);
            Controls.Add(label10);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "VistaSupervisor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zafira S.A (Supervisor)";
            Load += VistaSupervisor_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_supervisor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label10;
        private DateTimePicker dt_fechahora;
        private Label lbl_nombreusuario;
        private Button btn_consultarstock;
        private Button btn_cerrarsesion;
        private Button btn_produccion;
        private Button btn_pedirstock;
        private DataGridView dgv_supervisor;
        private Button btn_listaoperarios;
        private Button btn_registrococina;
        private Button btn_regproducido;
        private Button btn_altausuarios;
        private Button btn_bajausuarios;
        private Button btn_modificarusuario;
        private Button btn_enviarstock;
    }
}