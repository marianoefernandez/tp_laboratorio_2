using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {

        #region Atributos

        private double numero; 

        #endregion

        #region Propiedades
        /// <summary>
        /// Setea el número validando que sea un número.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto que setea el numero en 0, sobrecargo para reutilizar código
        /// </summary>
        public Numero() : this(0)//Inicializa en 0
        {
        }

        /// <summary>
        /// Constructor que usa la propiedad SetNumero para pasarle una cadena y retorne el número
        /// </summary>
        /// <param name="strNumero">String con el numero.</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Sobrecarga, que realiza absolutamente lo mismo que la anterior, sólo que se le pasa un double y no un string
        /// </summary>
        /// <param name="numero">Double del número.</param>
        public Numero(double numero) : this(numero.ToString())
        {
        }


        #endregion

        #region Métodos
        /// <summary>
        /// Comprueba que el valor recibido sea numerico
        /// </summary>
        /// <param name="strNumero">Número en string</param>
        /// <returns>Retorna el numero si existe, sino retorna 0</returns>
        private double ValidarNumero(string strNumero)
        {
            if (Double.TryParse(strNumero, out double retorno) == true)
            {

            }
            else
            {
                retorno = 0;
            }

            return retorno;

        }
        /// <summary>
        /// Verifica si el Número recibido contiene SOLO unos y ceros, y contiene al menos un número
        /// </summary>
        /// <param name="binario">String del número</param>
        /// <returns>true si es binario, false si tiene números distintos de 0/1 y la cadena está vacia</returns>
        private bool EsBinario(string binario)
        {
            bool retorno = false;
            int i;

            binario = binario.Replace(".", "");//Quita los puntos
            binario = binario.Replace("-", "");//Quita (-)
            binario = (binario.Contains(',')) ? binario.Remove(binario.IndexOf(',')) : binario;//Remueve comas

            if (binario.Trim('1', '0') == string.Empty)//Si sacando 1 y 0 da cadena vacia
            {
                retorno = true;//Es un número binario
            }

            return retorno;
        }

        /// <summary>
        /// Convierte string binario pasado, a decimal, retorna dicho decimal en string, caso contrario retorna "VALOR INVALIDO"
        /// </summary>
        /// <param name="binario">Número binario pasado en string</param>
        /// <returns>String del número decimal o "VALOR INVALIDO" si da error</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno="VALOR INVÁLIDO";
            double numDecimal = 0;

            if(EsBinario(binario)==true)
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    numDecimal += Convert.ToDouble(binario[i].ToString()) * Math.Pow(2, binario.Length - 1 - i);
                }
                retorno = numDecimal.ToString();
            }

            return retorno;
        }

        /// <summary>
        /// Convierte string pasado de número decimal a número binario, si no lo logra retorna "VALOR INVÁLIDO"
        /// </summary>
        /// <param name="numero">Numero decimal string a convertir a binario.</param>
        /// <returns>Devuelve número binario en string.</returns>
        public string DecimalBinario(string numero)
        {
            string retorno = "VALOR INVÁLIDO";
            if (double.TryParse(numero, out double numDecimal))
            {
                numDecimal = Math.Abs(Math.Truncate(numDecimal));
                retorno = (numDecimal == 0) ? "0" : "";
                while (numDecimal > 0)
                {
                    retorno = (numDecimal % 2) + retorno;
                    numDecimal = Math.Truncate(numDecimal / 2);
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convierte número double pasado de número decimal a número binario, si no lo logra retorna "VALOR INVÁLIDO"
        /// Es una sobrecarga del método anterior reutilizando el código anterior.
        /// </summary>
        /// <param name="numero">Numero decimal en double a convertir a binario.</param>
        /// <returns>Devuelve número binario en string.</returns>
        public string DecimalBinario(double numero)
        {
            return this.DecimalBinario(numero.ToString());
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Retorna la resta del n1 y del n2
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>double</returns>
        public static double operator -(Numero n1,Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Retorna la suma del n1 y del n2
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>double</returns>
        public static double operator +(Numero n1,Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Retorna el producto del n1 y del n2
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>double</returns>
        public static double operator *(Numero n1,Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Retorna la división del n1 y del n2, si n2 es cero retorna MinValue
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>double</returns>
        public static double operator /(Numero n1,Numero n2)
        {
            if(n2.numero==0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }


        #endregion

    }
}
