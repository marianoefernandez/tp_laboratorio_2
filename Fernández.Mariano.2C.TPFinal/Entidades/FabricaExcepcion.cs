using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FabricaExcepcion:Exception
    {
        public FabricaExcepcion(string mensaje):base(mensaje)
        {

        }
        
        public FabricaExcepcion():this("Error en la Fabrica")
        {

        }
    }
}
