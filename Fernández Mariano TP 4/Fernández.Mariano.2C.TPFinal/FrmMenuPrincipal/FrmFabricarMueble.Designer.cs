namespace FrmMenuPrincipal
{
    partial class FrmFabricarMueble
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFabricarMueble));
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblAnchura = new System.Windows.Forms.Label();
            this.lblProfundidad = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.txtAnchura = new System.Windows.Forms.TextBox();
            this.txtProfundidad = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.cmbTipoMadera = new System.Windows.Forms.ComboBox();
            this.lblTipoMadera = new System.Windows.Forms.Label();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.cmbTipoMetal = new System.Windows.Forms.ComboBox();
            this.lblTipoMetal = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFabricar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblFabricar = new System.Windows.Forms.Label();
            this.nudUnidades = new System.Windows.Forms.NumericUpDown();
            this.lblUnidades = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnidades)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(118, 68);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(119, 148);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(55, 13);
            this.lblPeso.TabIndex = 1;
            this.lblPeso.Text = "Peso (kg):";
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(119, 187);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(60, 13);
            this.lblAltura.TabIndex = 2;
            this.lblAltura.Text = "Altura (cm):";
            // 
            // lblAnchura
            // 
            this.lblAnchura.AutoSize = true;
            this.lblAnchura.Location = new System.Drawing.Point(119, 226);
            this.lblAnchura.Name = "lblAnchura";
            this.lblAnchura.Size = new System.Drawing.Size(73, 13);
            this.lblAnchura.TabIndex = 3;
            this.lblAnchura.Text = "Anchura (cm):";
            // 
            // lblProfundidad
            // 
            this.lblProfundidad.AutoSize = true;
            this.lblProfundidad.Location = new System.Drawing.Point(119, 265);
            this.lblProfundidad.Name = "lblProfundidad";
            this.lblProfundidad.Size = new System.Drawing.Size(90, 13);
            this.lblProfundidad.TabIndex = 4;
            this.lblProfundidad.Text = "Profundidad (cm):";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(120, 304);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(86, 13);
            this.lblTipo.TabIndex = 5;
            this.lblTipo.Text = "Tipo de mueble: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(121, 84);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(154, 20);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(122, 164);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(154, 20);
            this.txtPeso.TabIndex = 7;
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(122, 203);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(154, 20);
            this.txtAltura.TabIndex = 8;
            this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAltura_KeyPress);
            // 
            // txtAnchura
            // 
            this.txtAnchura.Location = new System.Drawing.Point(121, 242);
            this.txtAnchura.Name = "txtAnchura";
            this.txtAnchura.Size = new System.Drawing.Size(154, 20);
            this.txtAnchura.TabIndex = 9;
            this.txtAnchura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnchura_KeyPress);
            // 
            // txtProfundidad
            // 
            this.txtProfundidad.Location = new System.Drawing.Point(121, 281);
            this.txtProfundidad.Name = "txtProfundidad";
            this.txtProfundidad.Size = new System.Drawing.Size(154, 20);
            this.txtProfundidad.TabIndex = 10;
            this.txtProfundidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProfundidad_KeyPress);
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(121, 321);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(154, 21);
            this.cmbTipo.TabIndex = 11;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            this.cmbTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipo_KeyPress);
            // 
            // cmbTipoMadera
            // 
            this.cmbTipoMadera.FormattingEnabled = true;
            this.cmbTipoMadera.Location = new System.Drawing.Point(121, 362);
            this.cmbTipoMadera.Name = "cmbTipoMadera";
            this.cmbTipoMadera.Size = new System.Drawing.Size(154, 21);
            this.cmbTipoMadera.TabIndex = 13;
            this.cmbTipoMadera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoMadera_KeyPress);
            // 
            // lblTipoMadera
            // 
            this.lblTipoMadera.AutoSize = true;
            this.lblTipoMadera.Location = new System.Drawing.Point(119, 346);
            this.lblTipoMadera.Name = "lblTipoMadera";
            this.lblTipoMadera.Size = new System.Drawing.Size(87, 13);
            this.lblTipoMadera.TabIndex = 12;
            this.lblTipoMadera.Text = "Tipo de madera: ";
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(121, 400);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(154, 21);
            this.cmbColor.TabIndex = 15;
            this.cmbColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbColor_KeyPress);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(120, 384);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 14;
            this.lblColor.Text = "Color:";
            // 
            // cmbTipoMetal
            // 
            this.cmbTipoMetal.FormattingEnabled = true;
            this.cmbTipoMetal.Location = new System.Drawing.Point(121, 362);
            this.cmbTipoMetal.Name = "cmbTipoMetal";
            this.cmbTipoMetal.Size = new System.Drawing.Size(154, 21);
            this.cmbTipoMetal.TabIndex = 17;
            this.cmbTipoMetal.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMetal_SelectedIndexChanged);
            this.cmbTipoMetal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoMetal_KeyPress);
            // 
            // lblTipoMetal
            // 
            this.lblTipoMetal.AutoSize = true;
            this.lblTipoMetal.Location = new System.Drawing.Point(120, 346);
            this.lblTipoMetal.Name = "lblTipoMetal";
            this.lblTipoMetal.Size = new System.Drawing.Size(77, 13);
            this.lblTipoMetal.TabIndex = 16;
            this.lblTipoMetal.Text = "Tipo de metal: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 538);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // btnFabricar
            // 
            this.btnFabricar.BackColor = System.Drawing.Color.White;
            this.btnFabricar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFabricar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFabricar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnFabricar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnFabricar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFabricar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFabricar.Image = ((System.Drawing.Image)(resources.GetObject("btnFabricar.Image")));
            this.btnFabricar.Location = new System.Drawing.Point(86, 431);
            this.btnFabricar.Name = "btnFabricar";
            this.btnFabricar.Size = new System.Drawing.Size(93, 35);
            this.btnFabricar.TabIndex = 19;
            this.btnFabricar.UseVisualStyleBackColor = false;
            this.btnFabricar.Click += new System.EventHandler(this.btnFabricar_Click);
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
            this.btnLimpiar.Location = new System.Drawing.Point(206, 431);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(93, 35);
            this.btnLimpiar.TabIndex = 20;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblFabricar
            // 
            this.lblFabricar.AutoSize = true;
            this.lblFabricar.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFabricar.Location = new System.Drawing.Point(201, 424);
            this.lblFabricar.Name = "lblFabricar";
            this.lblFabricar.Size = new System.Drawing.Size(0, 25);
            this.lblFabricar.TabIndex = 21;
            // 
            // nudUnidades
            // 
            this.nudUnidades.Location = new System.Drawing.Point(121, 125);
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
            this.nudUnidades.TabIndex = 22;
            this.nudUnidades.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUnidades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudUnidades_KeyPress);
            // 
            // lblUnidades
            // 
            this.lblUnidades.AutoSize = true;
            this.lblUnidades.Location = new System.Drawing.Point(118, 109);
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Size = new System.Drawing.Size(55, 13);
            this.lblUnidades.TabIndex = 23;
            this.lblUnidades.Text = "Unidades:";
            // 
            // FrmFabricarMueble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 478);
            this.Controls.Add(this.lblUnidades);
            this.Controls.Add(this.nudUnidades);
            this.Controls.Add(this.lblFabricar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnFabricar);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFabricarMueble";
            this.Text = "Fabricar Mueble";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFabricarMueble_FormClosing);
            this.Load += new System.EventHandler(this.FrmFabricarMueble_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblAnchura;
        private System.Windows.Forms.Label lblProfundidad;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.TextBox txtAnchura;
        private System.Windows.Forms.TextBox txtProfundidad;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.ComboBox cmbTipoMadera;
        private System.Windows.Forms.Label lblTipoMadera;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ComboBox cmbTipoMetal;
        private System.Windows.Forms.Label lblTipoMetal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnFabricar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblFabricar;
        private System.Windows.Forms.NumericUpDown nudUnidades;
        private System.Windows.Forms.Label lblUnidades;
    }
}