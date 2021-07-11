using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmMenuPrincipal
{
    public partial class FrmMessegeBoxPersonalizado : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        public static byte opcion;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public FrmMessegeBoxPersonalizado(string texto,string textoSuperior,string boton1,string boton2,Bitmap icono)
        {
            InitializeComponent();
            this.lblTexto.Text = texto;
            this.Text = textoSuperior;
            this.btnOpcion1.Text = boton1;
            this.btnOpcion2.Text = boton2;
            this.pbIcon.Image = icono;
            this.pbIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            SystemSounds.Exclamation.Play();
        }

        private void FrmMessegeBoxPersonalizado_Load(object sender, EventArgs e)
        {
            
        }

        private void FrmMessegeBoxPersonalizado_FormClosing(object sender, FormClosingEventArgs e)
        {
           //e.Cancel = true;
        }

        private void btnOpcion1_Click(object sender, EventArgs e)
        {
            FrmMessegeBoxPersonalizado.opcion = 0;
            this.Close();
        }

        private void btnOpcion2_Click(object sender, EventArgs e)
        {
            FrmMessegeBoxPersonalizado.opcion = 1;
            this.Close();
        }
    }
}
