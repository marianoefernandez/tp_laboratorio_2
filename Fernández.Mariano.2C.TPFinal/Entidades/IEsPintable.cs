using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IEsPintable
    {
        #region Propiedades 

        /// <summary>
        /// Define si el mueble es o no pintable
        /// </summary>
        bool EsPintable
        {
            get;
        }

        /// <summary>
        /// Calcula los costes de la pintura dependiendo del tipo de mueble que sea
        /// </summary>
        float PrecioPintado
        {
            get;
        }

        #endregion
    }
}
