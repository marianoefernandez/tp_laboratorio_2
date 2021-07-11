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
    public partial class FrmModificarMueble : Form
    {

        private Mueble nuevoMueble;
        private Mueble muebleAModificar;

        /// <summary>
        /// Constructor al que se le pasa el mueble a modificar desde el form del menú
        /// </summary>
        /// <param name="muebleAModificar"></param>
        public FrmModificarMueble(Mueble muebleAModificar)
        {
            try
            {
                InitializeComponent();
                Limpiar();
                this.muebleAModificar = muebleAModificar;
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Hubo un error al acceder al mueble a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
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
        /// Modifica el mueble de la lista y setea el nuevo mueble 
        /// </summary>
        /// <returns>true si se agrego, false si es null</returns>
        private bool ModificarMueble()
        {
            try
            {
                switch ((Enum)this.cmbTipo.SelectedItem)
                {
                    case eTipoMueble.Madera:
                        this.nuevoMueble = new Madera(muebleAModificar.Id,txtNombre.Text, (int)nudUnidades.Value, Convert.ToSingle(txtPeso.Text), Convert.ToSingle(txtAltura.Text), Convert.ToSingle(txtAnchura.Text), Convert.ToSingle(txtProfundidad.Text), (eColor)cmbColor.SelectedItem, (eTipoDeMadera)cmbTipoMadera.SelectedItem);
                        break;
                    case eTipoMueble.Metal:
                        this.nuevoMueble = new Metal(muebleAModificar.Id,txtNombre.Text, (int)nudUnidades.Value, Convert.ToSingle(txtPeso.Text), Convert.ToSingle(txtAltura.Text), Convert.ToSingle(txtAnchura.Text), Convert.ToSingle(txtProfundidad.Text), (eColor)cmbColor.SelectedItem, (eTipoDeMetal)cmbTipoMetal.SelectedItem);
                        break;
                    case eTipoMueble.Vidrio:
                        this.nuevoMueble = new Vidrio(muebleAModificar.Id,txtNombre.Text, (int)nudUnidades.Value, Convert.ToSingle(txtPeso.Text), Convert.ToSingle(txtAltura.Text), Convert.ToSingle(txtAnchura.Text), Convert.ToSingle(txtProfundidad.Text));
                        break;
                }

                return !(this.nuevoMueble is null);
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
            if (!((Enum)this.cmbTipo.SelectedItem is eTipoMueble.Madera))
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
        /// Modifica el mueble de la lista de muebles usando el método Modificar preguntandole al
        /// usuario si está seguro si desea modificarlo.
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!FrmMenuPrincipal.seEstaModificando)
            {
                DialogResult resultado = MessageBox.Show(string.Format("¿Está seguro que desea modificar el mueble: \n{0}?  \nINFORMACIÓN DEL MUEBLE A MODIFICAR: \n{1} , \n\nATENCIÓN:Está Acción no se puede revertir", this.muebleAModificar.MuebleFabricado, this.muebleAModificar.InformacionDelMueble()), "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    FrmMenuPrincipal.EventoModificar += Modificar;
                    FrmMenuPrincipal.seEstaModificando = true;
                    this.MinimizeBox = true;
                    this.DesactivarControles();
                    MessageBox.Show("Mueble modificandose, espere 20 segundos. No cierre este formulario, minimicelo.", "Fabricando...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.Cancelar();
                }
            }
            else
            {
                MessageBox.Show("Se está modificando actualmente un mueble.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que se ejecuta cada vez que se modifica un mueble
        /// </summary>
        public void Modificar()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    MiDelegado d = new MiDelegado(this.Modificar);
                    this.Invoke(d);
                }
                else
                {
                    int indiceMuebleAnterior = Fabrica.Muebles.IndexOf(muebleAModificar);
                    if (CamposLlenos())
                    {
                        if (ModificarMueble())
                        {
                            if (this.nuevoMueble.ValidarMedidas())
                            {
                                DialogResult resultado;
                                Fabrica.Muebles.Insert(indiceMuebleAnterior, this.nuevoMueble);
                                Fabrica.Muebles.RemoveAt(indiceMuebleAnterior + 1);
                                MessageBox.Show("Mueble modificado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (FrmMessegeBoxPersonalizado.opcion == 0)
                                {
                                    string tipo = this.RetornarTipo();
                                    MueblesDBO.ModificarMueble(
                                        txtNombre.Text,
                                        (int)nudUnidades.Value,
                                        Convert.ToSingle(txtPeso.Text),
                                        Convert.ToSingle(txtAltura.Text),
                                        Convert.ToSingle(txtAnchura.Text),
                                        Convert.ToSingle(txtProfundidad.Text),
                                        DateTime.Now,
                                        (eColor)cmbColor.SelectedItem,
                                        this.nuevoMueble.GetType().Name,
                                        tipo,
                                        this.muebleAModificar.Id
                                        );
                                }
                                resultado = MessageBox.Show("¿Desea generar un .txt de la Modificación?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                                if (resultado == DialogResult.Yes)
                                {
                                    Facturacion.GenerarUnMuebleTxt(Environment.CurrentDirectory, this.nuevoMueble);
                                    MessageBox.Show(string.Format("Archivo generado con exito en {0}", Environment.CurrentDirectory), "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    this.Cancelar();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Las medidas y el peso deben ser mayores de cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hubo un error al modificar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error imprevisto al modificar el mueble", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Por las dudas
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
        /// Load
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void FrmModificarMueble_Load(object sender, EventArgs e)
        {
            CargarEnum<eColor>(this.cmbColor);
            CargarEnum<eTipoMueble>(this.cmbTipo);
            CargarEnum<eTipoDeMadera>(this.cmbTipoMadera);
            CargarEnum<eTipoDeMetal>(this.cmbTipoMetal);
            DatosDelMuebleAModificar();
        }

        /// <summary>
        /// Boton que llama a la función Limpiar()
        /// </summary>
        /// <param name="sender">objeto sender</param>
        /// <param name="e">e</param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (!FrmMenuPrincipal.seEstaModificando)
            {
                Limpiar();
            }
            else
            {
                MessageBox.Show("Se está modificando el mueble, no limpie los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Retorna el tipo del nuevo mueble modificado para cargar en su database
        /// </summary>
        /// <returns>String con el tipo</returns>
        public string RetornarTipo()
        {
            string retorno = "Sin Tipo";
            if(this.nuevoMueble is Madera)
            {
                retorno = ((Madera)this.nuevoMueble).TipoDeMadera;
            }
            else if(this.nuevoMueble is Metal)
            {
                retorno = ((Metal)this.nuevoMueble).TipoDeMetal;
            }
            return retorno;
        }

        /// <summary>
        /// Muestra mensaje de operación cancelada acción
        /// </summary>
        private void Cancelar()
        {
            MessageBox.Show("Operación cancelada", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Carga los datos del formulario a modificar con todos los datos del mueble que se 
        /// está modificando, además cambia el nombre del form por el nombre del mueble que 
        /// se está modificando.
        /// </summary>
        private void DatosDelMuebleAModificar()
        {
            this.Text = string.Format("Modificando: {0}", this.muebleAModificar.MuebleFabricado);
            this.txtNombre.Text = this.muebleAModificar.Nombre;
            this.txtPeso.Text = this.muebleAModificar.Peso.Replace(" kg", "");
            this.txtAnchura.Text = this.muebleAModificar.Anchura.Replace(" cm", "");
            this.txtAltura.Text = this.muebleAModificar.Altura.Replace(" cm", "");
            this.txtProfundidad.Text = this.muebleAModificar.Profundidad.Replace(" cm", "");
            if (this.muebleAModificar.Unidades != "Un solo mueble")
            {
                this.nudUnidades.Text = this.muebleAModificar.Unidades.Replace(" muebles", "");
            }
            else
            {
                this.nudUnidades.Text = "1";
            }
            if(this.muebleAModificar is Madera || this.muebleAModificar is Metal)
            {
                if(this.muebleAModificar is Madera)
                {
                    this.cmbTipo.Text = "Madera";
                    this.cmbColor.Text = ((Madera)this.muebleAModificar).Color;
                    this.cmbTipoMadera.Text = ((Madera)this.muebleAModificar).TipoDeMadera;
                }
                else
                {
                    this.cmbTipo.Text = "Metal";
                    this.cmbColor.Text = ((Metal)this.muebleAModificar).Color;
                    this.cmbTipoMetal.Text = ((Metal)this.muebleAModificar).TipoDeMetal;
                }
            }else
            {
                this.cmbTipo.Text = "Vidrio";
            }
        }

        /// <summary>
        /// Tiene lugar cuando se cierra el form, no se puede cerrar el form cuando se está modificando un mueble.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void FrmModificarMueble_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FrmMenuPrincipal.seEstaModificando)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar este form mientras se está modificando un mueble, por favor minimicelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
