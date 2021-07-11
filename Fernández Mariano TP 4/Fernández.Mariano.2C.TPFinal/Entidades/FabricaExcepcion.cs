using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FabricaExcepcion:Exception
    {
        /// <summary>
        /// Excepción perteneciente a la Fabrica en cuestión.
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción</param>
        public FabricaExcepcion(string mensaje):base(mensaje)
        {

        }
        
        /// <summary>
        /// Sobrecarga que se le pasa un mensaje génerico.
        /// </summary>
        public FabricaExcepcion():this("Error en la Fabrica")
        {

        }
    }
}
