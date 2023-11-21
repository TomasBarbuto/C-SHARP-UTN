namespace ParcialLaboratorio2
{
    partial class VistaCocina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaCocina));
            btn_volveroperario = new Button();
            btn_stock = new Button();
            lbl_titulo = new Label();
            dt_fechahora = new DateTimePicker();
            lbl_nombreusuario = new Label();
            gbx_maquina3 = new GroupBox();
            lbl_flanvainilla = new Label();
            btn_flan = new Button();
            cntd_flanvainilla = new NumericUpDown();
            lbl_flanchoco = new Label();
            cntd_flanchoco = new NumericUpDown();
            lbl_flancaramelo = new Label();
            cntd_flancaramelo = new NumericUpDown();
            gbx_maquina2 = new GroupBox();
            btn_gelatina = new Button();
            lbl_gelacereza = new Label();
            cntd_gelcereza = new NumericUpDown();
            lbl_gelaframbuesa = new Label();
            cntd_gelfrutilla = new NumericUpDown();
            lbl_gelafrutilla = new Label();
            cntd_gelframbuesa = new NumericUpDown();
            gbx_maquina1 = new GroupBox();
            lbl_bizcoco = new Label();
            cntd_bizcoco = new NumericUpDown();
            lbl_bizvainilla = new Label();
            cntd_bizvainilla = new NumericUpDown();
            lbl_bizchoco = new Label();
            cntd_bizchoco = new NumericUpDown();
            btn_bizcochuelo = new Button();
            gbx_maquina3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cntd_flanvainilla).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cntd_flanchoco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cntd_flancaramelo).BeginInit();
            gbx_maquina2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cntd_gelcereza).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cntd_gelfrutilla).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cntd_gelframbuesa).BeginInit();
            gbx_maquina1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cntd_bizcoco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cntd_bizvainilla).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cntd_bizchoco).BeginInit();
            SuspendLayout();
            // 
            // btn_volveroperario
            // 
            btn_volveroperario.Location = new Point(688, 54);
            btn_volveroperario.Margin = new Padding(3, 2, 3, 2);
            btn_volveroperario.Name = "btn_volveroperario";
            btn_volveroperario.Size = new Size(132, 24);
            btn_volveroperario.TabIndex = 22;
            btn_volveroperario.Text = "Volver";
            btn_volveroperario.UseVisualStyleBackColor = true;
            btn_volveroperario.Click += btn_volveroperario_Click;
            // 
            // btn_stock
            // 
            btn_stock.Location = new Point(688, 26);
            btn_stock.Margin = new Padding(3, 2, 3, 2);
            btn_stock.Name = "btn_stock";
            btn_stock.Size = new Size(132, 24);
            btn_stock.TabIndex = 21;
            btn_stock.Text = "Consultar Stock";
            btn_stock.UseVisualStyleBackColor = true;
            btn_stock.Click += btn_stock_Click;
            // 
            // lbl_titulo
            // 
            lbl_titulo.AutoSize = true;
            lbl_titulo.BackColor = Color.Transparent;
            lbl_titulo.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_titulo.ForeColor = Color.FromArgb(191, 113, 44);
            lbl_titulo.Location = new Point(304, 66);
            lbl_titulo.Name = "lbl_titulo";
            lbl_titulo.Size = new Size(294, 55);
            lbl_titulo.TabIndex = 20;
            lbl_titulo.Text = "ZAFIRA S.A";
            lbl_titulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // dt_fechahora
            // 
            dt_fechahora.Location = new Point(41, 26);
            dt_fechahora.Margin = new Padding(3, 2, 3, 2);
            dt_fechahora.Name = "dt_fechahora";
            dt_fechahora.Size = new Size(241, 23);
            dt_fechahora.TabIndex = 19;
            // 
            // lbl_nombreusuario
            // 
            lbl_nombreusuario.AutoSize = true;
            lbl_nombreusuario.Location = new Point(41, 59);
            lbl_nombreusuario.Margin = new Padding(3, 2, 3, 2);
            lbl_nombreusuario.Name = "lbl_nombreusuario";
            lbl_nombreusuario.Size = new Size(71, 15);
            lbl_nombreusuario.TabIndex = 17;
            lbl_nombreusuario.Text = "OP40881706";
            lbl_nombreusuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbx_maquina3
            // 
            gbx_maquina3.Controls.Add(lbl_flanvainilla);
            gbx_maquina3.Controls.Add(btn_flan);
            gbx_maquina3.Controls.Add(cntd_flanvainilla);
            gbx_maquina3.Controls.Add(lbl_flanchoco);
            gbx_maquina3.Controls.Add(cntd_flanchoco);
            gbx_maquina3.Controls.Add(lbl_flancaramelo);
            gbx_maquina3.Controls.Add(cntd_flancaramelo);
            gbx_maquina3.Location = new Point(579, 165);
            gbx_maquina3.Margin = new Padding(3, 2, 3, 2);
            gbx_maquina3.Name = "gbx_maquina3";
            gbx_maquina3.Padding = new Padding(3, 2, 3, 2);
            gbx_maquina3.Size = new Size(241, 230);
            gbx_maquina3.TabIndex = 16;
            gbx_maquina3.TabStop = false;
            gbx_maquina3.Text = "COCINA-2";
            // 
            // lbl_flanvainilla
            // 
            lbl_flanvainilla.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_flanvainilla.AutoSize = true;
            lbl_flanvainilla.BackColor = Color.FromArgb(191, 113, 44);
            lbl_flanvainilla.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_flanvainilla.ForeColor = SystemColors.ActiveCaptionText;
            lbl_flanvainilla.Location = new Point(5, 151);
            lbl_flanvainilla.Name = "lbl_flanvainilla";
            lbl_flanvainilla.Size = new Size(115, 28);
            lbl_flanvainilla.TabIndex = 4;
            lbl_flanvainilla.Text = "Flan Vainilla";
            // 
            // btn_flan
            // 
            btn_flan.Location = new Point(121, 199);
            btn_flan.Margin = new Padding(3, 2, 3, 2);
            btn_flan.Name = "btn_flan";
            btn_flan.Size = new Size(79, 26);
            btn_flan.TabIndex = 13;
            btn_flan.Text = "Cocinar";
            btn_flan.UseVisualStyleBackColor = true;
            btn_flan.Click += btn_flan_Click;
            // 
            // cntd_flanvainilla
            // 
            cntd_flanvainilla.Location = new Point(200, 152);
            cntd_flanvainilla.Margin = new Padding(3, 2, 3, 2);
            cntd_flanvainilla.Name = "cntd_flanvainilla";
            cntd_flanvainilla.Size = new Size(36, 23);
            cntd_flanvainilla.TabIndex = 3;
            // 
            // lbl_flanchoco
            // 
            lbl_flanchoco.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_flanchoco.AutoSize = true;
            lbl_flanchoco.BackColor = Color.FromArgb(191, 113, 44);
            lbl_flanchoco.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_flanchoco.ForeColor = SystemColors.ActiveCaptionText;
            lbl_flanchoco.Location = new Point(7, 47);
            lbl_flanchoco.Name = "lbl_flanchoco";
            lbl_flanchoco.Size = new Size(141, 28);
            lbl_flanchoco.TabIndex = 4;
            lbl_flanchoco.Text = "Flan Chocolate";
            // 
            // cntd_flanchoco
            // 
            cntd_flanchoco.Location = new Point(201, 47);
            cntd_flanchoco.Margin = new Padding(3, 2, 3, 2);
            cntd_flanchoco.Name = "cntd_flanchoco";
            cntd_flanchoco.Size = new Size(36, 23);
            cntd_flanchoco.TabIndex = 3;
            // 
            // lbl_flancaramelo
            // 
            lbl_flancaramelo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_flancaramelo.AutoSize = true;
            lbl_flancaramelo.BackColor = Color.FromArgb(191, 113, 44);
            lbl_flancaramelo.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_flancaramelo.ForeColor = SystemColors.ActiveCaptionText;
            lbl_flancaramelo.Location = new Point(5, 98);
            lbl_flancaramelo.Name = "lbl_flancaramelo";
            lbl_flancaramelo.Size = new Size(136, 28);
            lbl_flancaramelo.TabIndex = 2;
            lbl_flancaramelo.Text = "Flan Caramelo";
            // 
            // cntd_flancaramelo
            // 
            cntd_flancaramelo.Location = new Point(200, 100);
            cntd_flancaramelo.Margin = new Padding(3, 2, 3, 2);
            cntd_flancaramelo.Name = "cntd_flancaramelo";
            cntd_flancaramelo.Size = new Size(36, 23);
            cntd_flancaramelo.TabIndex = 1;
            // 
            // gbx_maquina2
            // 
            gbx_maquina2.Controls.Add(btn_gelatina);
            gbx_maquina2.Controls.Add(lbl_gelacereza);
            gbx_maquina2.Controls.Add(cntd_gelcereza);
            gbx_maquina2.Controls.Add(lbl_gelaframbuesa);
            gbx_maquina2.Controls.Add(cntd_gelfrutilla);
            gbx_maquina2.Controls.Add(lbl_gelafrutilla);
            gbx_maquina2.Controls.Add(cntd_gelframbuesa);
            gbx_maquina2.Location = new Point(310, 165);
            gbx_maquina2.Margin = new Padding(3, 2, 3, 2);
            gbx_maquina2.Name = "gbx_maquina2";
            gbx_maquina2.Padding = new Padding(3, 2, 3, 2);
            gbx_maquina2.Size = new Size(241, 230);
            gbx_maquina2.TabIndex = 15;
            gbx_maquina2.TabStop = false;
            gbx_maquina2.Text = "COCINA-1";
            // 
            // btn_gelatina
            // 
            btn_gelatina.Location = new Point(122, 199);
            btn_gelatina.Margin = new Padding(3, 2, 3, 2);
            btn_gelatina.Name = "btn_gelatina";
            btn_gelatina.Size = new Size(79, 26);
            btn_gelatina.TabIndex = 6;
            btn_gelatina.Text = "Cocinar";
            btn_gelatina.UseVisualStyleBackColor = true;
            btn_gelatina.Click += btn_gelatina_Click;
            // 
            // lbl_gelacereza
            // 
            lbl_gelacereza.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_gelacereza.AutoSize = true;
            lbl_gelacereza.BackColor = Color.FromArgb(191, 113, 44);
            lbl_gelacereza.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_gelacereza.ForeColor = SystemColors.ActiveCaptionText;
            lbl_gelacereza.Location = new Point(5, 151);
            lbl_gelacereza.Name = "lbl_gelacereza";
            lbl_gelacereza.Size = new Size(147, 28);
            lbl_gelacereza.TabIndex = 4;
            lbl_gelacereza.Text = "Gelatina Cereza";
            // 
            // cntd_gelcereza
            // 
            cntd_gelcereza.Location = new Point(200, 152);
            cntd_gelcereza.Margin = new Padding(3, 2, 3, 2);
            cntd_gelcereza.Name = "cntd_gelcereza";
            cntd_gelcereza.Size = new Size(36, 23);
            cntd_gelcereza.TabIndex = 3;
            // 
            // lbl_gelaframbuesa
            // 
            lbl_gelaframbuesa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_gelaframbuesa.AutoSize = true;
            lbl_gelaframbuesa.BackColor = Color.FromArgb(191, 113, 44);
            lbl_gelaframbuesa.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_gelaframbuesa.ForeColor = SystemColors.ActiveCaptionText;
            lbl_gelaframbuesa.Location = new Point(5, 47);
            lbl_gelaframbuesa.Name = "lbl_gelaframbuesa";
            lbl_gelaframbuesa.Size = new Size(184, 28);
            lbl_gelaframbuesa.TabIndex = 4;
            lbl_gelaframbuesa.Text = "Gelatina Frambuesa";
            // 
            // cntd_gelfrutilla
            // 
            cntd_gelfrutilla.Location = new Point(200, 98);
            cntd_gelfrutilla.Margin = new Padding(3, 2, 3, 2);
            cntd_gelfrutilla.Name = "cntd_gelfrutilla";
            cntd_gelfrutilla.Size = new Size(36, 23);
            cntd_gelfrutilla.TabIndex = 3;
            // 
            // lbl_gelafrutilla
            // 
            lbl_gelafrutilla.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_gelafrutilla.AutoSize = true;
            lbl_gelafrutilla.BackColor = Color.FromArgb(191, 113, 44);
            lbl_gelafrutilla.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_gelafrutilla.ForeColor = SystemColors.ActiveCaptionText;
            lbl_gelafrutilla.Location = new Point(5, 98);
            lbl_gelafrutilla.Name = "lbl_gelafrutilla";
            lbl_gelafrutilla.Size = new Size(149, 28);
            lbl_gelafrutilla.TabIndex = 2;
            lbl_gelafrutilla.Text = "Gelatina Frutilla";
            // 
            // cntd_gelframbuesa
            // 
            cntd_gelframbuesa.Location = new Point(200, 47);
            cntd_gelframbuesa.Margin = new Padding(3, 2, 3, 2);
            cntd_gelframbuesa.Name = "cntd_gelframbuesa";
            cntd_gelframbuesa.Size = new Size(36, 23);
            cntd_gelframbuesa.TabIndex = 1;
            // 
            // gbx_maquina1
            // 
            gbx_maquina1.Controls.Add(lbl_bizcoco);
            gbx_maquina1.Controls.Add(cntd_bizcoco);
            gbx_maquina1.Controls.Add(lbl_bizvainilla);
            gbx_maquina1.Controls.Add(cntd_bizvainilla);
            gbx_maquina1.Controls.Add(lbl_bizchoco);
            gbx_maquina1.Controls.Add(cntd_bizchoco);
            gbx_maquina1.Controls.Add(btn_bizcochuelo);
            gbx_maquina1.Location = new Point(41, 165);
            gbx_maquina1.Margin = new Padding(3, 2, 3, 2);
            gbx_maquina1.Name = "gbx_maquina1";
            gbx_maquina1.Padding = new Padding(3, 2, 3, 2);
            gbx_maquina1.Size = new Size(241, 230);
            gbx_maquina1.TabIndex = 14;
            gbx_maquina1.TabStop = false;
            gbx_maquina1.Text = "HORNO";
            // 
            // lbl_bizcoco
            // 
            lbl_bizcoco.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_bizcoco.AutoSize = true;
            lbl_bizcoco.BackColor = Color.FromArgb(191, 113, 44);
            lbl_bizcoco.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_bizcoco.ForeColor = SystemColors.ActiveCaptionText;
            lbl_bizcoco.Location = new Point(5, 151);
            lbl_bizcoco.Name = "lbl_bizcoco";
            lbl_bizcoco.Size = new Size(163, 28);
            lbl_bizcoco.TabIndex = 4;
            lbl_bizcoco.Text = "Bizcochuelo coco";
            // 
            // cntd_bizcoco
            // 
            cntd_bizcoco.Location = new Point(200, 152);
            cntd_bizcoco.Margin = new Padding(3, 2, 3, 2);
            cntd_bizcoco.Name = "cntd_bizcoco";
            cntd_bizcoco.Size = new Size(36, 23);
            cntd_bizcoco.TabIndex = 3;
            // 
            // lbl_bizvainilla
            // 
            lbl_bizvainilla.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_bizvainilla.AutoSize = true;
            lbl_bizvainilla.BackColor = Color.FromArgb(191, 113, 44);
            lbl_bizvainilla.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_bizvainilla.ForeColor = SystemColors.ActiveCaptionText;
            lbl_bizvainilla.Location = new Point(5, 98);
            lbl_bizvainilla.Name = "lbl_bizvainilla";
            lbl_bizvainilla.Size = new Size(183, 28);
            lbl_bizvainilla.TabIndex = 4;
            lbl_bizvainilla.Text = "Bizcochuelo Vainilla";
            // 
            // cntd_bizvainilla
            // 
            cntd_bizvainilla.Location = new Point(200, 98);
            cntd_bizvainilla.Margin = new Padding(3, 2, 3, 2);
            cntd_bizvainilla.Name = "cntd_bizvainilla";
            cntd_bizvainilla.Size = new Size(36, 23);
            cntd_bizvainilla.TabIndex = 3;
            // 
            // lbl_bizchoco
            // 
            lbl_bizchoco.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_bizchoco.AutoSize = true;
            lbl_bizchoco.BackColor = Color.FromArgb(191, 113, 44);
            lbl_bizchoco.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_bizchoco.ForeColor = SystemColors.ActiveCaptionText;
            lbl_bizchoco.Location = new Point(5, 46);
            lbl_bizchoco.Name = "lbl_bizchoco";
            lbl_bizchoco.Size = new Size(209, 28);
            lbl_bizchoco.TabIndex = 2;
            lbl_bizchoco.Text = "Bizcochuelo Chocolate";
            // 
            // cntd_bizchoco
            // 
            cntd_bizchoco.Location = new Point(200, 47);
            cntd_bizchoco.Margin = new Padding(3, 2, 3, 2);
            cntd_bizchoco.Name = "cntd_bizchoco";
            cntd_bizchoco.Size = new Size(36, 23);
            cntd_bizchoco.TabIndex = 1;
            // 
            // btn_bizcochuelo
            // 
            btn_bizcochuelo.Location = new Point(119, 199);
            btn_bizcochuelo.Margin = new Padding(3, 2, 3, 2);
            btn_bizcochuelo.Name = "btn_bizcochuelo";
            btn_bizcochuelo.Size = new Size(79, 26);
            btn_bizcochuelo.TabIndex = 0;
            btn_bizcochuelo.Text = "Cocinar";
            btn_bizcochuelo.UseVisualStyleBackColor = true;
            btn_bizcochuelo.Click += btn_bizcochuelo_Click;
            // 
            // VistaCocina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(861, 421);
            ControlBox = false;
            Controls.Add(btn_volveroperario);
            Controls.Add(btn_stock);
            Controls.Add(lbl_titulo);
            Controls.Add(dt_fechahora);
            Controls.Add(lbl_nombreusuario);
            Controls.Add(gbx_maquina3);
            Controls.Add(gbx_maquina2);
            Controls.Add(gbx_maquina1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "VistaCocina";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zafira S.A (Cocina)";
            Load += VistaCocina_Load;
            gbx_maquina3.ResumeLayout(false);
            gbx_maquina3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cntd_flanvainilla).EndInit();
            ((System.ComponentModel.ISupportInitialize)cntd_flanchoco).EndInit();
            ((System.ComponentModel.ISupportInitialize)cntd_flancaramelo).EndInit();
            gbx_maquina2.ResumeLayout(false);
            gbx_maquina2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cntd_gelcereza).EndInit();
            ((System.ComponentModel.ISupportInitialize)cntd_gelfrutilla).EndInit();
            ((System.ComponentModel.ISupportInitialize)cntd_gelframbuesa).EndInit();
            gbx_maquina1.ResumeLayout(false);
            gbx_maquina1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cntd_bizcoco).EndInit();
            ((System.ComponentModel.ISupportInitialize)cntd_bizvainilla).EndInit();
            ((System.ComponentModel.ISupportInitialize)cntd_bizchoco).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_volveroperario;
        private Button btn_stock;
        private Label lbl_titulo;
        private DateTimePicker dt_fechahora;
        private Label lbl_nombreusuario;
        private GroupBox gbx_maquina3;
        private Label lbl_flanvainilla;
        private Button btn_flan;
        private NumericUpDown cntd_flanvainilla;
        private Label lbl_flanchoco;
        private NumericUpDown cntd_flanchoco;
        private Label lbl_flancaramelo;
        private NumericUpDown cntd_flancaramelo;
        private GroupBox gbx_maquina2;
        private Button btn_gelatina;
        private Label lbl_gelacereza;
        private NumericUpDown cntd_gelcereza;
        private Label lbl_gelaframbuesa;
        private NumericUpDown cntd_gelfrutilla;
        private Label lbl_gelafrutilla;
        private NumericUpDown cntd_gelframbuesa;
        private GroupBox gbx_maquina1;
        private Label lbl_bizcoco;
        private NumericUpDown cntd_bizcoco;
        private Label lbl_bizvainilla;
        private NumericUpDown cntd_bizvainilla;
        private Label lbl_bizchoco;
        private NumericUpDown cntd_bizchoco;
        private Button btn_bizcochuelo;
    }
}