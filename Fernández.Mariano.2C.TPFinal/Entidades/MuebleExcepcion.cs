using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MuebleExcepcion:Exception
    {
        public MuebleExcepcion(string mensaje) : base(mensaje)
        {

        }

        public MuebleExcepcion() : this("Error en el Mueble")
        {

        }
    }
}
