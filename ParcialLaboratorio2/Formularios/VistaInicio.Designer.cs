namespace ParcialLaboratorio2
{
    partial class VistaInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaInicio));
            lbl_titulo = new Label();
            lbl_usuario = new Label();
            in_usuario = new TextBox();
            in_contraseña = new TextBox();
            lbl_contrasenia = new Label();
            btn_operario = new Button();
            btn_supervisor = new Button();
            btn_iniciocesion = new Button();
            SuspendLayout();
            // 
            // lbl_titulo
            // 
            lbl_titulo.AutoSize = true;
            lbl_titulo.BackColor = Color.Transparent;
            lbl_titulo.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_titulo.ForeColor = Color.FromArgb(191, 113, 44);
            lbl_titulo.Location = new Point(143, 97);
            lbl_titulo.Name = "lbl_titulo";
            lbl_titulo.Size = new Size(294, 55);
            lbl_titulo.TabIndex = 0;
            lbl_titulo.Text = "ZAFIRA S.A";
            lbl_titulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl_usuario
            // 
            lbl_usuario.AutoSize = true;
            lbl_usuario.BackColor = Color.Transparent;
            lbl_usuario.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_usuario.Location = new Point(143, 265);
            lbl_usuario.Margin = new Padding(0);
            lbl_usuario.Name = "lbl_usuario";
            lbl_usuario.Size = new Size(198, 29);
            lbl_usuario.TabIndex = 1;
            lbl_usuario.Text = "Ingrese Usuario";
            // 
            // in_usuario
            // 
            in_usuario.Location = new Point(143, 302);
            in_usuario.Name = "in_usuario";
            in_usuario.Size = new Size(305, 24);
            in_usuario.TabIndex = 2;
            // 
            // in_contraseña
            // 
            in_contraseña.Location = new Point(143, 404);
            in_contraseña.Name = "in_contraseña";
            in_contraseña.PasswordChar = '*';
            in_contraseña.Size = new Size(305, 24);
            in_contraseña.TabIndex = 3;
            // 
            // lbl_contrasenia
            // 
            lbl_contrasenia.AutoSize = true;
            lbl_contrasenia.BackColor = Color.Transparent;
            lbl_contrasenia.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_contrasenia.Location = new Point(143, 367);
            lbl_contrasenia.Margin = new Padding(0);
            lbl_contrasenia.Name = "lbl_contrasenia";
            lbl_contrasenia.Size = new Size(241, 29);
            lbl_contrasenia.TabIndex = 4;
            lbl_contrasenia.Text = "Ingrese Contraseña";
            // 
            // btn_operario
            // 
            btn_operario.BackColor = Color.Transparent;
            btn_operario.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_operario.ForeColor = Color.Black;
            btn_operario.Location = new Point(459, 550);
            btn_operario.Name = "btn_operario";
            btn_operario.Size = new Size(113, 49);
            btn_operario.TabIndex = 5;
            btn_operario.Text = "Operario";
            btn_operario.UseVisualStyleBackColor = false;
            btn_operario.Click += btn_operario_Click;
            // 
            // btn_supervisor
            // 
            btn_supervisor.BackColor = Color.Transparent;
            btn_supervisor.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_supervisor.ForeColor = Color.Black;
            btn_supervisor.Location = new Point(12, 550);
            btn_supervisor.Name = "btn_supervisor";
            btn_supervisor.Size = new Size(114, 49);
            btn_supervisor.TabIndex = 6;
            btn_supervisor.Text = "Supervisor";
            btn_supervisor.UseVisualStyleBackColor = false;
            btn_supervisor.Click += btn_supervisor_Click;
            // 
            // btn_iniciocesion
            // 
            btn_iniciocesion.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_iniciocesion.ForeColor = Color.Black;
            btn_iniciocesion.Location = new Point(223, 462);
            btn_iniciocesion.Name = "btn_iniciocesion";
            btn_iniciocesion.Size = new Size(143, 32);
            btn_iniciocesion.TabIndex = 7;
            btn_iniciocesion.Text = "Iniciar Sesion";
            btn_iniciocesion.UseVisualStyleBackColor = true;
            btn_iniciocesion.Click += btn_iniciocesion_Click;
            // 
            // VistaInicio
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(584, 611);
            Controls.Add(btn_iniciocesion);
            Controls.Add(btn_supervisor);
            Controls.Add(btn_operario);
            Controls.Add(lbl_contrasenia);
            Controls.Add(in_contraseña);
            Controls.Add(in_usuario);
            Controls.Add(lbl_usuario);
            Controls.Add(lbl_titulo);
            Font = new Font("Microsoft Sans Serif", 11.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "VistaInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zafira S.A";
            TransparencyKey = Color.FromArgb(224, 224, 224);
            Load += Inicio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_titulo;
        private Label lbl_usuario;
        private TextBox in_usuario;
        private TextBox in_contraseña;
        private Label lbl_contrasenia;
        private Button btn_operario;
        private Button btn_supervisor;
        private Button btn_iniciocesion;
    }
}