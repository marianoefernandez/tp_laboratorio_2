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
    public partial class FrmNuevoMueble : Form
    { 
        Mueble mueble;
        /// <summary>
        /// Constructor que se le pasa el mueble que va a mostrar, cierra el formulario si hay error
        /// en el mueble que se genero.
        /// </summary>
        /// <param name="mueble">mueble que va a mostrar</param>
        public FrmNuevoMueble(Mueble mueble)
        {
            try
            {
                this.mueble = mueble;
                InitializeComponent();
                this.Text = mueble.MuebleFabricado;
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Error en el mueble fabricado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void FrmNuevoMueble_Load(object sender, EventArgs e)
        {
            this.rtbNuevoMueble.Text = this.mueble.InformacionDelMueble();
            this.rtbNuevoMueble.Text += this.mueble.Facturacion();

        }

        /// <summary>
        /// Permite salir del formulario
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea salir?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Imprime la información del mueble en un .txt, si llega a haber cualquier tipo de error
        /// en su impresión, captura esa excepción para que no se cierre el programa y muestra un mensaje de error
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnImprimirMueble_Click(object sender, EventArgs e)
        {
            try
            {
                Facturacion.GenerarUnMuebleTxt(Environment.CurrentDirectory, this.mueble);
                MessageBox.Show(string.Format("Archivo generado con exito en {0}", Environment.CurrentDirectory), "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Error inesperado al imprimir el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
