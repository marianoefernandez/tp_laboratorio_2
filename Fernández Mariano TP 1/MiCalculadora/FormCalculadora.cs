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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        #region Constructor
        /// <summary>
        /// Construye la Calculadora, inicializa los operadores del ComboBox, por defecto selecciona el (+)
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.SelectedItem = "+";
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Limpia la los datos de la calculadora
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "0";
            this.txtNumero2.Text = "0";
            this.cmbOperador.Text = "+";
            this.lblResultado.Text = "0";
        }
        /// <summary>
        /// Realiza la operación entre los dos números y el operador definido, para que el Form lo pueda mostrar llamando al Botón
        /// Devuelve NaN si se divide por cero
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>double con el resultado de la operación</returns>
        private static double Operar(string numero1,string numero2,string operador)
        {
            double retorno = double.NaN;
            if (double.TryParse(numero1, out double num1) && double.TryParse(numero2, out double num2))//Convierte string a double
            {
                retorno = Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);//Llamamos a Operar
            }


            if (retorno==double.MinValue)
            {
                retorno = double.NaN;
            }

            return retorno;
        }
        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Convierte el número de Binario a Decimal usando la Funcion BinarioDecimal de la clase Numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Numero().BinarioDecimal(this.lblResultado.Text);
        }
        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textResultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Boton que llama al método Operar del Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);

            if ((double.IsNaN(resultado)))
            {
                this.lblResultado.Text = "Valores invalidos";
            }
            else
            {
                this.lblResultado.Text = resultado.ToString();
            }


        }
        #endregion
        /// <summary>
        /// Limpia el form y lo vuelve por defecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// Convierte el número de Decimal a Binario usando la Funcion DecimalBinario de la clase Numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Numero().DecimalBinario(this.lblResultado.Text);
        }
    }
}
