namespace FrmMenuPrincipal
{
    partial class FrmNuevoMueble
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevoMueble));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnImprimirMueble = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.rtbNuevoMueble = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(410, 475);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnImprimirMueble
            // 
            this.btnImprimirMueble.BackColor = System.Drawing.Color.White;
            this.btnImprimirMueble.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimirMueble.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImprimirMueble.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnImprimirMueble.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnImprimirMueble.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirMueble.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImprimirMueble.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirMueble.Image")));
            this.btnImprimirMueble.Location = new System.Drawing.Point(56, 411);
            this.btnImprimirMueble.Name = "btnImprimirMueble";
            this.btnImprimirMueble.Size = new System.Drawing.Size(189, 43);
            this.btnImprimirMueble.TabIndex = 9;
            this.btnImprimirMueble.UseVisualStyleBackColor = false;
            this.btnImprimirMueble.Click += new System.EventHandler(this.btnImprimirMueble_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(251, 411);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(87, 43);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // rtbNuevoMueble
            // 
            this.rtbNuevoMueble.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rtbNuevoMueble.BackColor = System.Drawing.Color.White;
            this.rtbNuevoMueble.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNuevoMueble.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtbNuevoMueble.DetectUrls = false;
            this.rtbNuevoMueble.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.rtbNuevoMueble.Location = new System.Drawing.Point(35, 70);
            this.rtbNuevoMueble.Name = "rtbNuevoMueble";
            this.rtbNuevoMueble.ReadOnly = true;
            this.rtbNuevoMueble.ShortcutsEnabled = false;
            this.rtbNuevoMueble.Size = new System.Drawing.Size(343, 325);
            this.rtbNuevoMueble.TabIndex = 11;
            this.rtbNuevoMueble.Text = "";
            // 
            // FrmNuevoMueble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 475);
            this.Controls.Add(this.rtbNuevoMueble);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimirMueble);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNuevoMueble";
            this.Text = "FrmNuevoMueble";
            this.Load += new System.EventHandler(this.FrmNuevoMueble_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnImprimirMueble;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.RichTextBox rtbNuevoMueble;
    }
}