namespace FrmMenuPrincipal
{
    partial class FrmModificarMuebles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModificarMuebles));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lbxModificarMuebles = new System.Windows.Forms.ListBox();
            this.rtbInfoMuebles = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 631);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.White;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.Location = new System.Drawing.Point(105, 403);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(169, 52);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lbxModificarMuebles
            // 
            this.lbxModificarMuebles.BackColor = System.Drawing.Color.White;
            this.lbxModificarMuebles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxModificarMuebles.FormattingEnabled = true;
            this.lbxModificarMuebles.Location = new System.Drawing.Point(24, 121);
            this.lbxModificarMuebles.Name = "lbxModificarMuebles";
            this.lbxModificarMuebles.Size = new System.Drawing.Size(166, 247);
            this.lbxModificarMuebles.TabIndex = 13;
            this.lbxModificarMuebles.SelectedIndexChanged += new System.EventHandler(this.lbxModificarMuebles_SelectedIndexChanged);
            // 
            // rtbInfoMuebles
            // 
            this.rtbInfoMuebles.BackColor = System.Drawing.Color.White;
            this.rtbInfoMuebles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInfoMuebles.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.rtbInfoMuebles.Location = new System.Drawing.Point(225, 193);
            this.rtbInfoMuebles.Name = "rtbInfoMuebles";
            this.rtbInfoMuebles.Size = new System.Drawing.Size(150, 173);
            this.rtbInfoMuebles.TabIndex = 14;
            this.rtbInfoMuebles.Text = "";
            this.rtbInfoMuebles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbInfoMuebles_KeyPress);
            // 
            // FrmModificarMuebles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 479);
            this.Controls.Add(this.rtbInfoMuebles);
            this.Controls.Add(this.lbxModificarMuebles);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmModificarMuebles";
            this.Text = "Modificar Mueble";
            this.Load += new System.EventHandler(this.FrmModificarMuebles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ListBox lbxModificarMuebles;
        private System.Windows.Forms.RichTextBox rtbInfoMuebles;
    }
}