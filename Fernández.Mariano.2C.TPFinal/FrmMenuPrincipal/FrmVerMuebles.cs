using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmMenuPrincipal
{
    public partial class FrmVerMuebles : Form
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FrmVerMuebles()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load, carga info de toda la fabrica
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void FrmVerMuebles_Load(object sender, EventArgs e)
        {
            rtbMuebles.Text = Fabrica.RetornarInformacionTotal();
        }

        /// <summary>
        /// Imprime la información de la Fabrica en un .txt, si llegara a haber un error captura 
        /// a cualquier excepcion del archivo que pueda dar error para que no se cierre el programa, 
        /// y notifica el error al usuario.
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Fabrica.Muebles.Count > 0)
                {
                    Facturacion.GenerarFabricaTxt(Environment.CurrentDirectory);
                    MessageBox.Show(string.Format("Archivo generado con exito en {0}", Environment.CurrentDirectory), "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se puede imprimir el archivo porque no hay ningun mueble en la Fabrica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error inesperado al imprimir el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
