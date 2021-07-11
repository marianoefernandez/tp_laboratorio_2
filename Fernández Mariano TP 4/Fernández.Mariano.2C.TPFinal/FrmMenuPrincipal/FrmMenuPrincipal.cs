using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmMenuPrincipal
{
    public delegate void MiDelegado();

    public partial class FrmMenuPrincipal : Form
    {
        public static int idAutoIncremental;
        FrmVerMuebles frmVerMuebles;
        FrmFabricarMueble frmFabricarMueble;
        FrmModificarMuebles frmModificarMuebles;
        FrmBorrarMueble frmBorrarMueble;
        public FrmMessegeBoxPersonalizado frmMenssageBoxPersonalizado;
        public Thread hiloFabricar;
        public Thread hiloModificar;
        public static event MiDelegado EventoFabricar;
        public static event MiDelegado EventoModificar;
        public static bool seEstaFabricando = false;
        public static bool seEstaModificando = false;


        /// <summary>
        /// Constructor por defecto del menú principal que deserializa el archivo binario cuando
        /// el menú se inicia
        /// </summary>
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.frmMenssageBoxPersonalizado = new FrmMessegeBoxPersonalizado("¿Cómo desea cargar los datos?", "Atención", "Base de datos", "Serialización",SystemIcons.Warning.ToBitmap());
        }

        /// <summary>
        /// Boton que abre el FrmVerMuebles
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnVerMuebles_Click(object sender, EventArgs e)
        {
            this.frmVerMuebles = new FrmVerMuebles();
            this.frmVerMuebles.ShowDialog();
        }

        private void Asignar()
        {
            string error = string.Empty;
            try
            {
                if(FrmMessegeBoxPersonalizado.opcion == 1)
                {
                    Fabrica.Muebles = Serializacion<List<Mueble>>.DeserializarBinario(Fabrica.Muebles, "Muebles.dat");
                    error = "Atención!. No se ha reconocido el archivo Muebles.dat, sin ese archivo no se guardaran los cambios hechos en el programa.";
                    MessageBox.Show("Cargue por serialización");
                }
                else
                {
                    Fabrica.Muebles = MueblesDBO.RetornarMuebles("select * from Mueble");
                    MessageBox.Show("Cargue por database");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Boton que abre el Menú para Fabricar un Mueble
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnFabricarMueble_Click(object sender, EventArgs e)
        {
            this.frmFabricarMueble = new FrmFabricarMueble();
            this.frmFabricarMueble.Show();
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
            this.hiloFabricar = new Thread(EsperaFabricacion);
            this.hiloModificar = new Thread(EsperaModificacion);
            this.hiloFabricar.Start();
            this.hiloModificar.Start();
        }

        /// <summary>
        /// Calcula el ID Actual del último Mueble
        /// </summary>
        public void CalcularIDActual()
        {
            if(Fabrica.Muebles.Count>0)
            {
                Mueble mueble;
                mueble = Fabrica.Muebles.ElementAt(Fabrica.Muebles.Count-1);
                FrmMenuPrincipal.idAutoIncremental = mueble.Id;
            }
            else
            {
                FrmMenuPrincipal.idAutoIncremental = 0;
            }
        }

        /// <summary>
        /// Abre el formulario que permite modificar los muebles
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnModificarMueble_Click(object sender, EventArgs e)
        {
            this.frmModificarMuebles = new FrmModificarMuebles();
            this.frmModificarMuebles.Show();
        }

        /// <summary>
        /// Boton que abre el formulario para eliminar un mueble
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnEliminarMueble_Click(object sender, EventArgs e)
        {
            this.frmBorrarMueble = new FrmBorrarMueble();
            this.frmBorrarMueble.Show();
        }

        /// <summary>
        /// Ocurre justo antes de que se cierre completamente el formulario, serializa los cambios hechos
        /// por el usuario.
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            string error = string.Empty;
            try
            {
                if(this.hiloFabricar.IsAlive)
                {
                    this.hiloFabricar.Abort();
                }
                if (this.hiloModificar.IsAlive)
                {
                    this.hiloModificar.Abort();
                }

                if (FrmMessegeBoxPersonalizado.opcion == 1)
                {
                    Serializacion<List<Mueble>>.SerializarBinario(Fabrica.Muebles, "Muebles.dat");
                    error = "Atención!. No se ha reconocido el archivo Muebles.dat, sin ese archivo no se guardaran los cambios hechos en el programa.";
                }
                else
                {
                    MueblesDBO.CerrarConexiones = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se le pasara al Thread, hara la espera de 30 seg y llamara al Evento para fabricar el mueble.
        /// </summary>
        public void EsperaFabricacion()
        {
            while(true)
            {
                if(FrmMenuPrincipal.seEstaFabricando)
                {
                    Thread.Sleep(30000);
                    FrmMenuPrincipal.seEstaFabricando = false;
                    FrmMenuPrincipal.EventoFabricar.Invoke();
                }
            }
        }

        /// <summary>
        /// Se le pasara al Thread, hara la espera de 20 seg y llamara al Evento para modificar el mueble.
        /// </summary>
        public void EsperaModificacion()
        {
            while (true)
            {
                if (FrmMenuPrincipal.seEstaModificando)
                {
                    Thread.Sleep(20000);
                    FrmMenuPrincipal.seEstaModificando = false;
                    FrmMenuPrincipal.EventoModificar.Invoke();
                }
            }
        }

        /// <summary>
        /// Evento Shown del form
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void FrmMenuPrincipal_Shown(object sender, EventArgs e)
        {
            this.frmMenssageBoxPersonalizado.ShowDialog();
            this.Asignar();
            this.CalcularIDActual();
        }
    }
}
