using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Taller
    {
        #region Enumerado

        public enum ETipo
        {
            Ciclomotor,
            Sedan,
            SUV,
            Todos
        }

        #endregion

        #region Atributos

        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        #endregion

        #region Constructores
        /// <summary>
        /// Instancia la lista de Vehiculos
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Sobrecarga el constructor privado e instancia el espacio disponible
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Taller(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.SUV:
                        if (v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;

                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;

                    case ETipo.Sedan:
                        if(v is Sedan)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;

                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>String con los datos</returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Agregará un elemento a la lista, si el vehiculo ya existe retorna el taller sin modificaciones
        /// </summary>
        /// <param name="t">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>El taller actualizado o no</returns>
        public static Taller operator +(Taller t, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in t.vehiculos)
            {
                if (v == vehiculo)
                {
                    return t;
                    break;
                }
            }

            if(t.espacioDisponible>t.vehiculos.Count)
            {
                t.vehiculos.Add(vehiculo);
            }

            return t;
        }
        /// <summary>
        /// Quitará un elemento de la lista, si el vehiculo no existe, retorna el taller sin cambios
        /// </summary>
        /// <param name="t">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>El taller actualizado o no</returns>
        public static Taller operator -(Taller t, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in t.vehiculos)
            {
                if (v == vehiculo)
                {
                    t.vehiculos.Remove(vehiculo);
                    break;
                }
            }

            return t;
        }
        #endregion
    }
}
