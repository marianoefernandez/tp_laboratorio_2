using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MuebleExtension
    {
        /// <summary>
        /// Método de extensión que formatea un precio con dos decimales y le agrega el $
        /// </summary>
        /// <param name="dato">Dato del precio</param>
        /// <returns></returns>
        public static string FormatearPrecio(this float dato)
        {
            return string.Format("{0:N2} $", dato);
        }
    }
}
