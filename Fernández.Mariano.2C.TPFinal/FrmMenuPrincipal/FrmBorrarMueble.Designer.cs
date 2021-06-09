namespace FrmMenuPrincipal
{
    partial class FrmBorrarMueble
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBorrarMueble));
            this.rtbInfoMuebles = new System.Windows.Forms.RichTextBox();
            this.lbxBorrarMuebles = new System.Windows.Forms.ListBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbInfoMuebles
            // 
            this.rtbInfoMuebles.BackColor = System.Drawing.Color.White;
            this.rtbInfoMuebles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInfoMuebles.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.rtbInfoMuebles.Location = new System.Drawing.Point(226, 193);
            this.rtbInfoMuebles.Name = "rtbInfoMuebles";
            this.rtbInfoMuebles.Size = new System.Drawing.Size(150, 173);
            this.rtbInfoMuebles.TabIndex = 18;
            this.rtbInfoMuebles.Text = "";
            // 
            // lbxBorrarMuebles
            // 
            this.lbxBorrarMuebles.BackColor = System.Drawing.Color.White;
            this.lbxBorrarMuebles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxBorrarMuebles.FormattingEnabled = true;
            this.lbxBorrarMuebles.Location = new System.Drawing.Point(25, 121);
            this.lbxBorrarMuebles.Name = "lbxBorrarMuebles";
            this.lbxBorrarMuebles.Size = new System.Drawing.Size(166, 247);
            this.lbxBorrarMuebles.TabIndex = 17;
            this.lbxBorrarMuebles.SelectedIndexChanged += new System.EventHandler(this.lbxBorrarMuebles_SelectedIndexChanged);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.White;
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBorrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrar.Image")));
            this.btnBorrar.Location = new System.Drawing.Point(106, 403);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(169, 52);
            this.btnBorrar.TabIndex = 16;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 631);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // FrmBorrarMueble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 476);
            this.Controls.Add(this.rtbInfoMuebles);
            this.Controls.Add(this.lbxBorrarMuebles);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmBorrarMueble";
            this.Text = "Eliminar Mueble";
            this.Load += new System.EventHandler(this.FrmBorrarMueble_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInfoMuebles;
        private System.Windows.Forms.ListBox lbxBorrarMuebles;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}