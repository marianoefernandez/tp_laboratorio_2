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
using Entidades;

namespace FrmMenuPrincipal
{
    public partial class FrmBorrarMueble : Form
    {
        private Mueble muebleSeleccionado;

        /// <summary>
        /// Constructor por defecto del Formulario de Eliminar mueble
        /// </summary>
        public FrmBorrarMueble()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load del formulario
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void FrmBorrarMueble_Load(object sender, EventArgs e)
        {
            this.RecargarLista();
        }

        /// <summary>
        /// Método que se ejecuta cada vez que se cambia de elemento en el listBox, cada vez que cambie
        /// de elemento se mostrara en el richTextBox la info de dicho mueble , si el mueble seleccionado
        /// es null, capturo su excepción para que no se cierre el programa
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void lbxBorrarMuebles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.muebleSeleccionado = Fabrica.Muebles[lbxBorrarMuebles.SelectedIndex];
                rtbInfoMuebles.Text = muebleSeleccionado.InformacionDelMueble();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Hubo un error al cargar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón que elimina el mueble de la lista si el usuario puso que si
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Fabrica.Muebles.Count > 0)
                {
                    DialogResult resultado = MessageBox.Show(string.Format("¿Está seguro que desea eliminar el mueble: \n{0}?  \nINFORMACIÓN DEL MUEBLE A BORRAR: \n{1} , \n\nATENCIÓN:Está Acción no se puede revertir", lbxBorrarMuebles.SelectedItem, this.muebleSeleccionado), "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes)
                    {
                        MessageBox.Show("¡Mueble eliminado con éxito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Fabrica.QuitarMueble = muebleSeleccionado;
                        this.RecargarLista();
                    }
                    else
                    {
                        this.Cancelar();
                    }
                }
                else
                {
                    MessageBox.Show("No hay ningun mueble para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Error inesperado al intentar eliminar un mueble", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Recarga el listBox
        /// </summary>
        private void RecargarLista()
        {
            this.lbxBorrarMuebles.DataSource = Fabrica.RetornarMuebles();
            if (Fabrica.Muebles.Count == 0)
            {
                rtbInfoMuebles.Text = string.Empty;
            }
        }

        /// <summary>
        /// Muestra mensaje de operación cancelada acción
        /// </summary>
        private void Cancelar()
        {
            MessageBox.Show("Operación cancelada", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
