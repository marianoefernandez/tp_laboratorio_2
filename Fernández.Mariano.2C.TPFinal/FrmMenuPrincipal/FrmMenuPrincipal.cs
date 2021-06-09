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
    public partial class FrmMenuPrincipal : Form
    {
        FrmVerMuebles frmVerMuebles = new FrmVerMuebles();
        FrmFabricarMueble frmFabricarMueble = new FrmFabricarMueble();
        FrmModificarMuebles frmModificarMuebles = new FrmModificarMuebles();
        FrmBorrarMueble frmBorrarMueble = new FrmBorrarMueble();

        /// <summary>
        /// Constructor por defecto del menú principal que deserializa el archivo binario cuando
        /// el menú se inicia
        /// </summary>
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            try
            {
                Fabrica.Muebles = Serializacion<List<Mueble>>.DeserializarBinario(Fabrica.Muebles, "Muebles.dat");
            }
            catch (Exception)
            {
                MessageBox.Show("Atención!. No se ha reconocido el archivo Muebles.dat, sin ese archivo no se guardaran los cambios hechos en el programa.");
            }
        }

        /// <summary>
        /// Boton que abre el FrmVerMuebles
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnVerMuebles_Click(object sender, EventArgs e)
        {
            this.frmVerMuebles.ShowDialog();
        }

        /// <summary>
        /// Boton que abre el Menú para Fabricar un Mueble
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnFabricarMueble_Click(object sender, EventArgs e)
        {
            this.frmFabricarMueble.ShowDialog();
        }

        /// <summary>
        /// Boton que permite salir del programa
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
        /// Load del menuPrincipal
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Abre el formulario que permite modificar los muebles
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnModificarMueble_Click(object sender, EventArgs e)
        {
            this.frmModificarMuebles.ShowDialog();
        }

        /// <summary>
        /// Boton que abre el formulario para eliminar un mueble
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnEliminarMueble_Click(object sender, EventArgs e)
        {
            this.frmBorrarMueble.ShowDialog();
        }

        /// <summary>
        /// Ocurre justo antes de que se cierre completamente el formulario, serializa los cambios hechos
        /// por el usuario.
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Serializacion<List<Mueble>>.SerializarBinario(Fabrica.Muebles, "Muebles.dat");
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error inesperado al guardar el archivo .dat, no se guardaron los datos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
