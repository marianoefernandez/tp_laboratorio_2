using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Fabrica
    {

        #region Atributos

        private static List<Mueble> listaDeMuebles;

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de sólo escritura que me permite agregar un Mueble a la lista usando el operador +
        /// de la clase mueble pasandole en el value el mueble a agregar.
        /// </summary>
        public static Mueble AgregarMueble
        {
            set
            {
                Fabrica.listaDeMuebles += value;
            }
        }
        /// <summary>
        /// Propiedad de sólo escritura que me permite quitar un Mueble a la lista usando el operador + 
        /// de la clase mueble pasandole en el value el mueble a quitar.
        /// </summary>
        public static Mueble QuitarMueble
        {
            set
            {
                Fabrica.listaDeMuebles -= value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que reemplaza la lista por otra (set) o retorna dicha lista (get) , 
        /// se usa para la serialización/deserialización de la lista
        /// </summary>
        public static List<Mueble> Muebles
        {
            set
            {
                Fabrica.listaDeMuebles = value;
            }
            get
            {
                return Fabrica.listaDeMuebles;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor estático que inicializa la lista de muebles
        /// </summary>
        static Fabrica()
        {
            Fabrica.listaDeMuebles = new List<Mueble>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método estático que retorna la información de toda la fabrica llamando al ToString() de cada mueble
        /// </summary>
        /// <returns>String con todos los muebles creados.</returns>
        public static string RetornarInformacion()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Mueble mueble in Fabrica.listaDeMuebles)
            {
                sb.AppendFormat("{0}\n", mueble.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Método estático que retorna la información de toda la fabrica, su facturación, 
        /// el total de muebles fabricados, y el gasto total
        /// </summary>
        /// <returns>String con toda la info de la fabrica.</returns>
        public static string RetornarInformacionTotal()
        {
            StringBuilder sb = new StringBuilder();

            if (Fabrica.Muebles.Count > 0)
            {
                foreach (Mueble mueble in Fabrica.listaDeMuebles)
                {
                    sb.AppendFormat("{0}", mueble.InformacionDelMueble());
                    sb.AppendFormat("{0}", mueble.Facturacion());
                    sb.AppendLine("******************************************************************************");
                }

                sb.AppendFormat("\nTotal de muebles fabricados:{0} Muebles\n", Fabrica.CalcularUnidadesFabricadas());
                sb.AppendFormat("\nGasto total:{0:N2} $\n", Fabrica.CalcularGastoFabrica());
            }
            else
            {
                sb.Append("No se ha cargado ningun producto.");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Método estático que retorna la facturación total de la fabrica
        /// </summary>
        /// <returns>Toda la facturación de la fabrica</returns>
        public static string RetornarFacturacionTotal()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Mueble mueble in Fabrica.listaDeMuebles)
            {
                sb.AppendFormat("{0}\n", mueble.Facturacion());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Método estático que calcula el gasto total de la fabrica pasandole el casteo explicito float
        /// del objeto mueble, si llega a haber un error en los valores, retorna cero y limpia
        /// la lista por las dudas.
        /// </summary>
        /// <returns>Retorna float con el gasto total</returns>
        public static float CalcularGastoFabrica()
        {
            try
            {
                float gastoTotal = 0;

                foreach (Mueble mueble in Fabrica.listaDeMuebles)
                {
                    gastoTotal += (float)mueble;
                }

                if (gastoTotal <= 0 && Fabrica.listaDeMuebles.Count > 0)
                {
                    throw new FabricaExcepcion("Error en la Fabrica, no pueden haber gastos iguales a cero si se cargo al menos un producto");
                }

                return gastoTotal;
            }
            catch(FabricaExcepcion)
            {
                Fabrica.listaDeMuebles.Clear();
                return 0;
            }
        }

        /// <summary>
        /// Método estático que retorna la cantidad de unidades fabricadas por toda la fabrica usando 
        /// un casteo explicito de int del objeto mueble , si llega a haber un error en las unidades
        /// retorna cero y limpia la lista por las dudas.
        /// </summary>
        /// <returns>Retorna un entero de todos los muebles fabricados por la fabrica</returns>
        public static int CalcularUnidadesFabricadas()
        {
            try
            {
                int unidades = 0;

                foreach (Mueble mueble in Fabrica.listaDeMuebles)
                {
                    unidades += (int)mueble;
                }

                if(unidades < 1 && Fabrica.listaDeMuebles.Count > 0)
                {
                    throw new FabricaExcepcion("Error en la Fabrica, no pueden haber unidades menores a 1 si hay cargado al menos un elemento");
                }

                return unidades;
            }
            catch(FabricaExcepcion)
            {
                Fabrica.listaDeMuebles.Clear();
                return 0;
            }
        }

        /// <summary>
        /// Método estático que retorna una lista de strings con el nombre del mueble, con el objetivo
        /// de usarse en el listbox al eliminar o modificar si la lista da null retorna la lista
        /// con un string vacio cargado.
        /// </summary>
        /// <returns>retorna una lista de strings con los nombres de los muebles</returns>
        public static List<string> RetornarMuebles()
        {
            try
            {
                List<string> lista = new List<string>();

                foreach (Mueble mueble in Fabrica.Muebles)
                {
                    lista.Add(mueble.MuebleFabricado);
                }

                return lista;
            }
            catch(NullReferenceException)
            {
                List<string> lista = new List<string>();
                lista.Add(string.Empty);
                return lista;
            }
        }

        #endregion

    }
}
