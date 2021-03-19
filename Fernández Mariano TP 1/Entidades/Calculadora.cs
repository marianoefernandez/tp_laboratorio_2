using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Métodos
        /// <summary>
        /// Realiza una de las cuatro operaciones aritméticas entre dos objetos Numero y devuelve el resultado como double.
        /// Si el operador no es (+ - / *) realizará una suma.
        /// </summary>
        /// <param name="num1">Numero 1</param>
        /// <param name="num2">Numero 2</param>
        /// <param name="operador">Operador aritmético en formato string.</param>
        /// <returns>Devuelve un valor double o 0 en caso de division por 0.</returns>
        public static double Operar(Numero num1,Numero num2,string operador)
        {
            double retorno=0;
            operador = Calculadora.ValidarOperador(Convert.ToChar(operador));

            if (!object.Equals(null, num1) && !object.Equals(null, num2))//SI EL OBJETO ES DISTINTO DE NULL
            {
                switch (operador)
                {
                    case "+":
                        retorno = num1 + num2;
                        break;
                    case "-":
                        retorno = num1 - num2;
                        break;
                    case "*":
                        retorno = num1 * num2;
                        break;
                    case "/":
                        retorno = num1 / num2;
                        break;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Verifica que el char contenga un operador aritmético válido para una de las cuatro operaciones básicas:
        /// y retorna dicho operador. En caso de error devuelve "+".
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Devuelve valor string.</returns>
        private static string ValidarOperador(char operador)
        {
            string retorno;

            switch(operador)
            {
                case '-':
                    retorno = "-";
                    break;
                
                case '*':
                    retorno = "*";
                    break;
                
                case '/':
                    retorno = "/";
                    break;

                default:
                    retorno = "+";
                    break;

            }

            return retorno;
        }

        #endregion
    }

}
