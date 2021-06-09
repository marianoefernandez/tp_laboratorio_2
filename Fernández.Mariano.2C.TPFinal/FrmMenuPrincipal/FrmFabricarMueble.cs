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
            Limpiar();
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
            try
            {
                switch ((Enum)this.cmbTipo.SelectedItem)
                {
                    case eTipoMueble.Madera:
                        this.mueble = new Madera(txtNombre.Text, (int)nudUnidades.Value, Convert.ToSingle(txtPeso.Text), Convert.ToSingle(txtAltura.Text), Convert.ToSingle(txtAnchura.Text), Convert.ToSingle(txtProfundidad.Text), (eColor)cmbColor.SelectedItem, (eTipoDeMadera)cmbTipoMadera.SelectedItem);
                        break;
                    case eTipoMueble.Metal:
                        this.mueble = new Metal(txtNombre.Text, (int)nudUnidades.Value, Convert.ToSingle(txtPeso.Text), Convert.ToSingle(txtAltura.Text), Convert.ToSingle(txtAnchura.Text), Convert.ToSingle(txtProfundidad.Text), (eColor)cmbColor.SelectedItem, (eTipoDeMetal)cmbTipoMetal.SelectedItem);
                        break;
                    case eTipoMueble.Vidrio:
                        this.mueble = new Vidrio(txtNombre.Text, (int)nudUnidades.Value, Convert.ToSingle(txtPeso.Text), Convert.ToSingle(txtAltura.Text), Convert.ToSingle(txtAnchura.Text), Convert.ToSingle(txtProfundidad.Text));
                        break;
                }

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
            if(CamposLlenos())
            {
                if(AgregarMueble())
                {
                    if(this.mueble.ValidarMedidas())
                    {
                        MessageBox.Show("Producto fabricado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Fabrica.AgregarMueble = this.mueble;
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
    }
}
