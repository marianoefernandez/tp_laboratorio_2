using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {

        #region Enumerados
        public enum ETipo 
        {
            CuatroPuertas,
            CincoPuertas 
        }

        #endregion

        #region Atributos
        private ETipo tipo;
        #endregion

        #region Propiedades

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor que toma todos los parametros del Sedan
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color,ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color):this(marca,chasis,color,ETipo.CuatroPuertas)
        {

        }

        #endregion

        #region Métodos

        /// <summary>
        /// Publica todos los datos del Ciclomotor.
        /// </summary>
        /// <returns>Datos del Sedan</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendFormat("TIPO : {0}" , this.tipo);//Queda mejor visto con un AppendFormat
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
