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
    public partial class FrmFabricarMueble : Form
    {

        private Mueble mueble;

        /// <summary>
        /// Constructor por defecto del Fabricar un Mueble
        /// </summary>
        public FrmFabricarMueble()
        {
            InitializeComponent();
            Limpiar();
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void FrmFabricarMueble_Load(object sender, EventArgs e)
        {
            CargarEnum<eColor>(this.cmbColor);
            CargarEnum<eTipoMueble>(this.cmbTipo);
            CargarEnum<eTipoDeMadera>(this.cmbTipoMadera);
            CargarEnum<eTipoDeMetal>(this.cmbTipoMetal);
        }

        /// <summary>
        /// Método génerico que carga un Enumerado a un combobox
        /// </summary>
        /// <typeparam name="T">Elemento génerico</typeparam>
        /// <param name="combobox">Objeto combobox</param>
        private void CargarEnum<T>(ComboBox combobox) where T : struct
        {
            // Carga
            combobox.DataSource = Enum.GetValues(typeof(T));
            // Lectura
            T enumerado;
            Enum.TryParse<T>(combobox.SelectedValue.ToString(), out enumerado);
        }

        /// <summary>
        /// Método que sólo deja que se escriban letras en el txtNombre
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == 32 || e.KeyChar == 8))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// Método que sólo deja que se escriban números en el txtPeso
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == 32 || e.KeyChar == 8 || e.KeyChar == 44))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// Método que sólo deja que se escriban números en el txtAltura
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPeso_KeyPress(sender, e);
        }

        /// <summary>
        /// Método que sólo deja que se escriban números en el txtAnchura
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void txtAnchura_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPeso_KeyPress(sender, e);
        }

        /// <summary>
        /// Método que sólo deja que se escriban números en el txtProfundidad
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void txtProfundidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPeso_KeyPress(sender, e);
        }

        /// <summary>
        /// Boton que llama a la función Limpiar()
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (!FrmMenuPrincipal.seEstaFabricando)
            {
                Limpiar();
            }
            else
            {
                MessageBox.Show("Se está fabricando el mueble, no limpie los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia los textbox y setea el NumericUpDown de unidades en 1
        /// </summary>
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.nudUnidades.Text = "1";
            this.txtPeso.Text = string.Empty;
            this.txtAltura.Text = string.Empty;
            this.txtAnchura.Text = string.Empty;
            this.txtProfundidad.Text = string.Empty;
        }

        /// <summary>
        /// Agrega un mueble a la lista
        /// </summary>
        /// <returns>true si se agrego, false si es null</returns>
        private bool AgregarMueble()
        {
            int id = FrmMenuPrincipal.idAutoIncremental;
            id++;
            try
            {
                switch ((Enum)this.cmbTipo.SelectedItem)
                {
                    case eTipoMueble.Madera:
                        this.mueble = new Madera(id,txtNombre.Text, (int)nudUnidades.Value, Convert.ToSingle(txtPeso.Text), Convert.ToSingle(txtAltura.Text), Convert.ToSingle(txtAnchura.Text), Convert.ToSingle(txtProfundidad.Text), (eColor)cmbColor.SelectedItem, (eTipoDeMadera)cmbTipoMadera.SelectedItem);
                        break;
                    case eTipoMueble.Metal:
                        this.mueble = new Metal(id,txtNombre.Text, (int)nudUnidades.Value, Convert.ToSingle(txtPeso.Text), Convert.ToSingle(txtAltura.Text), Convert.ToSingle(txtAnchura.Text), Convert.ToSingle(txtProfundidad.Text), (eColor)cmbColor.SelectedItem, (eTipoDeMetal)cmbTipoMetal.SelectedItem);
                        break;
                    case eTipoMueble.Vidrio:
                        this.mueble = new Vidrio(id,txtNombre.Text, (int)nudUnidades.Value, Convert.ToSingle(txtPeso.Text), Convert.ToSingle(txtAltura.Text), Convert.ToSingle(txtAnchura.Text), Convert.ToSingle(txtProfundidad.Text));
                        break;
                }

                FrmMenuPrincipal.idAutoIncremental = id;

                return !(this.mueble is null);
            }
            catch(NullReferenceException)
            {
                return false;
            }

        }

        /// <summary>
        /// Interfiere en la interfaz del Form para que sólo muestre los parametros 
        /// que se necesitan en dicho momento dependiendo del tipo de mueble
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((Enum)this.cmbTipo.SelectedItem)
            {
                case eTipoMueble.Madera:
                    this.lblColor.Visible = true;
                    this.cmbColor.Visible = true;
                    this.cmbTipoMadera.Visible = true;
                    this.lblTipoMadera.Visible = true;
                    this.cmbTipoMetal.Visible = false;
                    this.lblTipoMetal.Visible = false;
                    break;

                case eTipoMueble.Metal:
                    this.cmbTipoMetal.Visible = true;
                    this.lblTipoMetal.Visible = true;
                    this.cmbTipoMadera.Visible = false;
                    this.lblTipoMadera.Visible = false;
                    if ((Enum)this.cmbTipoMetal.SelectedItem is eTipoDeMetal.Acero)
                    {
                        this.cmbColor.Visible = true;
                        this.lblColor.Visible = true;
                    }
                    break;

                case eTipoMueble.Vidrio:
                    this.lblColor.Visible = false;
                    this.cmbColor.Visible = false;
                    this.cmbTipoMadera.Visible = false;
                    this.lblTipoMadera.Visible = false;
                    this.cmbTipoMetal.Visible = false;
                    this.lblTipoMetal.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Interfiere en la interfaz del Form para que sólo muestre los parametros 
        /// que se necesitan en dicho momento dependiendo del tipo de metal
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void cmbTipoMetal_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(!((Enum)this.cmbTipo.SelectedItem is eTipoMueble.Madera))
            {
                switch ((Enum)this.cmbTipoMetal.SelectedItem)
                {

                    case eTipoDeMetal.Acero:
                        this.lblColor.Visible = true;
                        this.cmbColor.Visible = true;
                        this.cmbTipoMadera.Visible = false;
                        this.lblTipoMadera.Visible = false;
                        break;

                    case eTipoDeMetal.Aluminio:
                        this.lblColor.Visible = false;
                        this.cmbColor.Visible = false;
                        this.cmbTipoMadera.Visible = false;
                        this.lblTipoMadera.Visible = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Fabrica el mueble agregandolo a la lista de muebles usando el método AgregarMueble
        /// Una vez que lo agrega abre otro form con la info del mueble agregado.
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnFabricar_Click(object sender, EventArgs e)
        {
            if(!FrmMenuPrincipal.seEstaFabricando)
            {
                FrmMenuPrincipal.EventoFabricar += FabricarMueble;
                FrmMenuPrincipal.seEstaFabricando = true;
                this.MinimizeBox = true;
                this.DesactivarControles();
                MessageBox.Show("Mueble fabricandose, espere 30 segundos. No cierre este formulario, minimicelo.", "Fabricando...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Se está fabricando actualmente un mueble.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que se ejecuta cada vez que se fabrica un mueble
        /// </summary>
        public void FabricarMueble()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    MiDelegado d = new MiDelegado(this.FabricarMueble);
                    this.Invoke(d);
                }
                else
                {
                    if (CamposLlenos())
                    {
                        if (AgregarMueble())
                        {
                            if (this.mueble.ValidarMedidas())
                            {
                                MessageBox.Show("Mueble fabricado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (FrmMessegeBoxPersonalizado.opcion == 0)
                                {
                                    bool flag = true;
                                    string unidades;

                                    foreach (Mueble m in Fabrica.Muebles)
                                    {
                                        if (mueble.GetType() == m.GetType() && mueble == m && Fabrica.Muebles.Count > 0)
                                        {
                                            MueblesDBO.AgregarUnidades((int)nudUnidades.Value + RetornarUnidades(m), DateTime.Now, m.Id);
                                            flag = false;
                                            break;
                                        }
                                    }

                                    Fabrica.AgregarMueble = this.mueble;

                                    if (flag)
                                    {
                                        MueblesDBO.GuardarMueble(mueble);
                                    }
                                }
                                else
                                {
                                    Fabrica.AgregarMueble = this.mueble;
                                }

                                FrmNuevoMueble frmNuevoMueble = new FrmNuevoMueble(this.mueble);
                                frmNuevoMueble.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Las medidas y el peso deben ser mayores de cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hubo un error al fabricar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hay campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.ActivarControles();
                    this.MinimizeBox = false;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Error imprevisto al fabricar el mueble", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Por las dudas
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Por si ocurre cualquier excepción referida al archivo
            }
        }

        /// <summary>
        /// Define si los campos están llenos o no
        /// </summary>
        /// <returns>True si están todos llenos, false si no</returns>
        private bool CamposLlenos()
        {
            return (!(this.txtAltura.Text == string.Empty || this.txtNombre.Text == string.Empty || this.txtAnchura.Text == string.Empty || this.txtPeso.Text == string.Empty || this.txtProfundidad.Text == string.Empty));
        }

        /// <summary>
        /// Solo permite escribir números en el NumericUpDown
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void nudUnidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPeso_KeyPress(sender, e);
        }

        /// <summary>
        /// No permite escribir en el combobox de tipo de madera
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void cmbTipoMadera_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbTipo_KeyPress(sender, e);
        }

        /// <summary>
        /// No permite escribir en el combobox de tipo de madera
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void cmbTipoMetal_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbTipo_KeyPress(sender, e);
        }

        /// <summary>
        /// No permite escribir en el combobox de color
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void cmbColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbTipo_KeyPress(sender, e);
        }

        /// <summary>
        /// No permite escribir en el combobox de tipo del mueble
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void cmbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        /// <summary>
        /// Retorna las unidades del mueble que se pasa
        /// </summary>
        /// <param name="mueble">Mueble</param>
        /// <returns>Cantidad de muebles</returns>
        private int RetornarUnidades(Mueble mueble)
        {
            string unidades = "0";
            if (mueble.Unidades != "Un solo mueble")
            {
                unidades = mueble.Unidades.Replace(" muebles", "");
            }
            else
            {
                unidades = "1";
            }

            return Convert.ToInt32(unidades);
        }

        /// <summary>
        /// Tiene lugar cuando se cierra el form, no se puede cerrar el form cuando se está fabricando un mueble nuevo.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void FrmFabricarMueble_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(FrmMenuPrincipal.seEstaFabricando)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar este form mientras se está fabricando un mueble, por favor minimicelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Desactiva los controles del form
        /// </summary>
        private void DesactivarControles()
        {
            this.txtNombre.Enabled = false;
            this.txtAltura.Enabled = false;
            this.txtAnchura.Enabled = false;
            this.txtPeso.Enabled = false;
            this.txtProfundidad.Enabled = false;
            this.nudUnidades.Enabled = false;
            this.cmbColor.Enabled = false;
            this.cmbTipo.Enabled = false;
            this.cmbTipoMadera.Enabled = false;
            this.cmbTipoMetal.Enabled = false;
        }

        /// <summary>
        /// Activa los controles del form
        /// </summary>
        private void ActivarControles()
        {
            this.txtNombre.Enabled = true;
            this.txtAltura.Enabled = true;
            this.txtAnchura.Enabled = true;
            this.txtPeso.Enabled = true;
            this.txtProfundidad.Enabled = true;
            this.nudUnidades.Enabled = true;
            this.cmbColor.Enabled = true;
            this.cmbTipo.Enabled = true;
            this.cmbTipoMadera.Enabled = true;
            this.cmbTipoMetal.Enabled = true;
        }
    }
}
