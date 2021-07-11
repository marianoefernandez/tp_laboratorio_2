using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MuebleExcepcion:Exception
    {
        /// <summary>
        /// Excepcion que se ejecuta si algun método de algun mueble da error
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción</param>
        public MuebleExcepcion(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Sobrecarga con un método génerico
        /// </summary>
        public MuebleExcepcion() : this("Error en el Mueble")
        {

        }
    }
}
