namespace FrmMenuPrincipal
{
    partial class FrmModificarMueble
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModificarMueble));
            this.lblUnidades = new System.Windows.Forms.Label();
            this.nudUnidades = new System.Windows.Forms.NumericUpDown();
            this.lblFabricar = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.cmbTipoMetal = new System.Windows.Forms.ComboBox();
            this.lblTipoMetal = new System.Windows.Forms.Label();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.cmbTipoMadera = new System.Windows.Forms.ComboBox();
            this.lblTipoMadera = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtProfundidad = new System.Windows.Forms.TextBox();
            this.txtAnchura = new System.Windows.Forms.TextBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblProfundidad = new System.Windows.Forms.Label();
            this.lblAnchura = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUnidades
            // 
            this.lblUnidades.AutoSize = true;
            this.lblUnidades.Location = new System.Drawing.Point(119, 106);
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Size = new System.Drawing.Size(55, 13);
            this.lblUnidades.TabIndex = 47;
            this.lblUnidades.Text = "Unidades:";
            // 
            // nudUnidades
            // 
            this.nudUnidades.Location = new System.Drawing.Point(122, 122);
            this.nudUnidades.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudUnidades.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUnidades.Name = "nudUnidades";
            this.nudUnidades.Size = new System.Drawing.Size(155, 20);
            this.nudUnidades.TabIndex = 46;
            this.nudUnidades.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUnidades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudUnidades_KeyPress);
            // 
            // lblFabricar
            // 
            this.lblFabricar.AutoSize = true;
            this.lblFabricar.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFabricar.Location = new System.Drawing.Point(202, 421);
            this.lblFabricar.Name = "lblFabricar";
            this.lblFabricar.Size = new System.Drawing.Size(0, 25);
            this.lblFabricar.TabIndex = 45;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(207, 428);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(93, 35);
            this.btnLimpiar.TabIndex = 44;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.White;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.Location = new System.Drawing.Point(87, 428);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(93, 35);
            this.btnModificar.TabIndex = 43;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // cmbTipoMetal
            // 
            this.cmbTipoMetal.FormattingEnabled = true;
            this.cmbTipoMetal.Location = new System.Drawing.Point(122, 359);
            this.cmbTipoMetal.Name = "cmbTipoMetal";
            this.cmbTipoMetal.Size = new System.Drawing.Size(154, 21);
            this.cmbTipoMetal.TabIndex = 41;
            this.cmbTipoMetal.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMetal_SelectedIndexChanged);
            this.cmbTipoMetal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoMetal_KeyPress);
            // 
            // lblTipoMetal
            // 
            this.lblTipoMetal.AutoSize = true;
            this.lblTipoMetal.Location = new System.Drawing.Point(121, 343);
            this.lblTipoMetal.Name = "lblTipoMetal";
            this.lblTipoMetal.Size = new System.Drawing.Size(77, 13);
            this.lblTipoMetal.TabIndex = 40;
            this.lblTipoMetal.Text = "Tipo de metal: ";
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(122, 397);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(154, 21);
            this.cmbColor.TabIndex = 39;
            this.cmbColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbColor_KeyPress);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(121, 381);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 38;
            this.lblColor.Text = "Color:";
            // 
            // cmbTipoMadera
            // 
            this.cmbTipoMadera.FormattingEnabled = true;
            this.cmbTipoMadera.Location = new System.Drawing.Point(122, 359);
            this.cmbTipoMadera.Name = "cmbTipoMadera";
            this.cmbTipoMadera.Size = new System.Drawing.Size(154, 21);
            this.cmbTipoMadera.TabIndex = 37;
            // 
            // lblTipoMadera
            // 
            this.lblTipoMadera.AutoSize = true;
            this.lblTipoMadera.Location = new System.Drawing.Point(120, 343);
            this.lblTipoMadera.Name = "lblTipoMadera";
            this.lblTipoMadera.Size = new System.Drawing.Size(87, 13);
            this.lblTipoMadera.TabIndex = 36;
            this.lblTipoMadera.Text = "Tipo de madera: ";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(122, 317);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(154, 21);
            this.cmbTipo.TabIndex = 35;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            this.cmbTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipo_KeyPress);
            // 
            // txtProfundidad
            // 
            this.txtProfundidad.Location = new System.Drawing.Point(122, 278);
            this.txtProfundidad.Name = "txtProfundidad";
            this.txtProfundidad.Size = new System.Drawing.Size(154, 20);
            this.txtProfundidad.TabIndex = 34;
            this.txtProfundidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProfundidad_KeyPress);
            // 
            // txtAnchura
            // 
            this.txtAnchura.Location = new System.Drawing.Point(122, 239);
            this.txtAnchura.Name = "txtAnchura";
            this.txtAnchura.Size = new System.Drawing.Size(154, 20);
            this.txtAnchura.TabIndex = 33;
            this.txtAnchura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnchura_KeyPress);
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(123, 200);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(154, 20);
            this.txtAltura.TabIndex = 32;
            this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAltura_KeyPress);
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(123, 161);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(154, 20);
            this.txtPeso.TabIndex = 31;
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(122, 81);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(154, 20);
            this.txtNombre.TabIndex = 30;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(121, 301);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(86, 13);
            this.lblTipo.TabIndex = 29;
            this.lblTipo.Text = "Tipo de mueble: ";
            // 
            // lblProfundidad
            // 
            this.lblProfundidad.AutoSize = true;
            this.lblProfundidad.Location = new System.Drawing.Point(120, 262);
            this.lblProfundidad.Name = "lblProfundidad";
            this.lblProfundidad.Size = new System.Drawing.Size(90, 13);
            this.lblProfundidad.TabIndex = 28;
            this.lblProfundidad.Text = "Profundidad (cm):";
            // 
            // lblAnchura
            // 
            this.lblAnchura.AutoSize = true;
            this.lblAnchura.Location = new System.Drawing.Point(120, 223);
            this.lblAnchura.Name = "lblAnchura";
            this.lblAnchura.Size = new System.Drawing.Size(73, 13);
            this.lblAnchura.TabIndex = 27;
            this.lblAnchura.Text = "Anchura (cm):";
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(120, 184);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(60, 13);
            this.lblAltura.TabIndex = 26;
            this.lblAltura.Text = "Altura (cm):";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(120, 145);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(55, 13);
            this.lblPeso.TabIndex = 25;
            this.lblPeso.Text = "Peso (kg):";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(119, 65);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 24;
            this.lblNombre.Text = "Nombre:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 538);
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // FrmModificarMueble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 478);
            this.Controls.Add(this.lblUnidades);
            this.Controls.Add(this.nudUnidades);
            this.Controls.Add(this.lblFabricar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.cmbTipoMetal);
            this.Controls.Add(this.lblTipoMetal);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.cmbTipoMadera);
            this.Controls.Add(this.lblTipoMadera);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtProfundidad);
            this.Controls.Add(this.txtAnchura);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblProfundidad);
            this.Controls.Add(this.lblAnchura);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmModificarMueble";
            this.Text = "Modificar Mueble";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmModificarMueble_FormClosing);
            this.Load += new System.EventHandler(this.FrmModificarMueble_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUnidades;
        private System.Windows.Forms.NumericUpDown nudUnidades;
        private System.Windows.Forms.Label lblFabricar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ComboBox cmbTipoMetal;
        private System.Windows.Forms.Label lblTipoMetal;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ComboBox cmbTipoMadera;
        private System.Windows.Forms.Label lblTipoMadera;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtProfundidad;
        private System.Windows.Forms.TextBox txtAnchura;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblProfundidad;
        private System.Windows.Forms.Label lblAnchura;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}