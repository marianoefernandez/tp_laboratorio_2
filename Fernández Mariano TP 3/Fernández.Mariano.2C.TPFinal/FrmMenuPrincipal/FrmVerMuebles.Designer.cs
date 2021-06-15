namespace FrmMenuPrincipal
{
    partial class FrmVerMuebles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerMuebles));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtbMuebles = new System.Windows.Forms.RichTextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 631);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rtbMuebles
            // 
            this.rtbMuebles.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rtbMuebles.BackColor = System.Drawing.Color.White;
            this.rtbMuebles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMuebles.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtbMuebles.DetectUrls = false;
            this.rtbMuebles.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.rtbMuebles.Location = new System.Drawing.Point(29, 70);
            this.rtbMuebles.Name = "rtbMuebles";
            this.rtbMuebles.ReadOnly = true;
            this.rtbMuebles.ShortcutsEnabled = false;
            this.rtbMuebles.Size = new System.Drawing.Size(346, 326);
            this.rtbMuebles.TabIndex = 1;
            this.rtbMuebles.Text = "";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(106, 415);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(169, 52);
            this.btnImprimir.TabIndex = 9;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FrmVerMuebles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 479);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.rtbMuebles);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVerMuebles";
            this.Text = "Ver Muebles";
            this.Load += new System.EventHandler(this.FrmVerMuebles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rtbMuebles;
        private System.Windows.Forms.Button btnImprimir;
    }
}