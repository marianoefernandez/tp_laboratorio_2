using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmMenuPrincipal
{
    public partial class FrmModificarMuebles : Form
    {
        private Mueble muebleSeleccionado;

        /// <summary>
        /// Constructor por defecto del Form de modificar Muebles
        /// </summary>
        public FrmModificarMuebles()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void FrmModificarMuebles_Load(object sender, EventArgs e)
        {
            this.RecargarLista();
        }

        /// <summary>
        /// Método que se ejecuta cada vez que se cambia de elemento en el listBox, cada vez que cambie
        /// de elemento se mostrara en el richTextBox la info de dicho mueble
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void lbxModificarMuebles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.muebleSeleccionado = Fabrica.Muebles[lbxModificarMuebles.SelectedIndex];
                rtbInfoMuebles.Text = muebleSeleccionado.InformacionDelMueble();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Hubo un error al cargar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre el form para modificar el mueble seleccionado
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Fabrica.Muebles.Count>0)
                {
                    FrmModificarMueble frmModificarMueble = new FrmModificarMueble(this.muebleSeleccionado);
                    frmModificarMueble.ShowDialog();
                    this.RecargarLista();
                }
                else
                {
                    MessageBox.Show("No hay ningun mueble cargado para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Error inesperado en el mueble a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Recarga la lista
        /// </summary>
        private void RecargarLista()
        {
            this.lbxModificarMuebles.DataSource = Fabrica.RetornarMuebles();
            if (Fabrica.Muebles.Count==0)
            {
                rtbInfoMuebles.Text = string.Empty;
            }
        }

        /// <summary>
        /// No permite escribir en la info.
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void rtbInfoMuebles_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }
    }
}
