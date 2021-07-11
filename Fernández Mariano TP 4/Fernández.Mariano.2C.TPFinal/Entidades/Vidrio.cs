using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]

    public class Vidrio : Mueble
    {

        #region Atributos

        private const int PRECIOVIDRIO = 1289;//Precio en USD tonelada

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de sólo lectura que retorna el mueble fabricado con el formato Nombre + Tipo de Mueble
        /// </summary>
        public override string MuebleFabricado
        {
            get
            {
                return string.Format("{0} de {1}", this.Nombre , this.GetType().Name);
            }
        }

        /// <summary>
        /// Calcula el precio de la materia prima dependiendo del valor del vidrio por tonelada y 
        /// luego lo multiplica por la cantidad de unidades.
        /// </summary>
        public override float PrecioMateriaPrima
        {
            get
            {
                return this.peso * ((float)PRECIOVIDRIO / 1000) * this.unidades;//Valor por materia prima en kilo
            }
        }

        /// <summary>
        /// Calcula los costes de producción promedio dependiendo del uso de materiales, maquina y mano de obra , 
        /// y traslado más los sueldos de los empleados , cómo los empleados cobran el doble a la noche, 
        /// se duplican los costes. Por lo general para el vidrio los costes de producción son del 5% promedio por unidad.
        /// </summary>
        public override float CostesDeProducción
        {
            get
            {
                try
                {
                    float retorno = 0;

                    if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour < 6)
                    {
                        retorno += (this.PrecioMateriaPrima / 100) * 10;//Costos por horario 10%
                    }
                    else
                    {
                        retorno += (this.PrecioMateriaPrima / 100) * 5;//Costos por horario 5%

                    }

                    if(retorno<=0)
                    {
                        throw new MuebleExcepcion("Los valores deben ser mayores a cero");
                    }

                    return retorno;
                }
                catch(MuebleExcepcion)
                {
                    this.peso = 0;
                    return 0;
                }
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor parametrizado con los datos del Mueble de Vidrio
        /// </summary>
        /// <param name="nombre">Nombre del mueble</param>
        /// <param name="cantidad">Cantidad de unidades</param>
        /// <param name="peso">Su peso en kg</param>
        /// <param name="altura">Su altura en cm</param>
        /// <param name="anchura">Su anchura en cm</param>
        /// <param name="profundidad">Su profundidad en cm</param>
        public Vidrio(int id,string nombre, int cantidad, float peso, float altura, float anchura, float profundidad) : base(id,nombre, cantidad, peso, altura, anchura, profundidad)
        {

        }

        /// <summary>
        /// Constructor sin parametros que inicializa el nombre en un string vacio, las unidades en 1
        /// y todo lo demás en cero.
        /// </summary>
        public Vidrio() : this(0,string.Empty, 0, 0, 0, 0, 0)
        {

        }

        #endregion

        #region Métodos
        /// <summary>
        /// Sobrecarga del ToString que retorna las caracteristicas del mueble
        /// </summary>
        /// <returns>string con datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Tipo de Mueble: Vidrio\n");
            sb.Append(base.ToString());
            sb.AppendFormat("\nFecha y hora de Fabricación:{0}\n", this.fechaFabricacion);

            return sb.ToString();
        }


        /// <summary>
        /// Sobreescritura del método virtual de la clase base que calcula su Facturación del mueble de metal
        /// </summary>
        /// <returns>La facturación en string</returns>
        public override string Facturacion()
        {
            return base.Facturacion();
        }

        /// <summary>
        /// Retorna la información del mueble llamando al ToString() del this
        /// </summary>
        /// <returns></returns>
        public override string InformacionDelMueble()
        {
            return this.ToString();
        }

        /// <summary>
        /// Calcula un estimado precio final de la fabricación de un mueble en el que depende de la hora de su fabricación
        /// Si se fabrica entre las 20 hs hasta las 6 hs se cobrara entre un 10% sobre el valor de la materia prima debido al que en el horario nocturno se paga más
        /// Mientras que si es fuera de dicho horario se estimaria que su costo estaria entre un 5% de su valor, 
        /// también se debe agregar un 21% de IVA sobre la materia prima.
        /// </summary>
        /// <returns>Float con el costo total.</returns>
        protected override float CalcularCostoFinal()
        {
            try
            {
                float retorno = 0;

                retorno = this.PrecioMateriaPrima;

                retorno += this.CostesDeProducción;

                retorno += this.ValorIVA;

                if(retorno<=0)
                {
                    throw new MuebleExcepcion("Los valores deben ser mayores a cero");
                }

                return retorno;
            }
            catch(MuebleExcepcion)
            {
                this.peso = 0;
                return 0;
            }
        }

        #endregion

        #region Operadores 

        /// <summary>
        /// Sobrecarga del == que indica si dos vidrio de madera son iguales.
        /// </summary>
        /// <param name="v1">Mueble de vidrio 1</param>
        /// <param name="v2">Mueble de vidrio 2</param>
        /// <returns>Retorna true si los dos muebles de vidrio coinciden todos sus datos , excepto la cantidad
        /// de unidades que puede coincidir o no , sino retorna false</returns>
        public static bool operator ==(Vidrio v1, Vidrio v2)
        {
            bool retorno = false;

            if (v1.altura.Equals(v2.altura) && v1.peso.Equals(v2.peso) && v1.anchura.Equals(v2.anchura) && v1.profundidad.Equals(v2.profundidad) && v1.Nombre.Equals(v2.Nombre))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga distinto que indica si dos muebles de vidrio son diferentes
        /// </summary>
        /// <param name="v1">Mueble de vidrio 1</param>
        /// <param name="v2">Mueble de vidrio 2</param>
        /// <returns>Retorna true si son distintos y false si son iguales 
        /// con el mismo criterio del == </returns>
        public static bool operator !=(Vidrio v1, Vidrio v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Sobrecarga que me permite añadir más unidades a un mismo mueble , modificando sus costes también
        /// </summary>
        /// <param name="v1">Mueble de vidrio 1</param>
        /// <param name="v2">Mueble de vidrio 2</param>
        /// <returns>Retorna el mueble de vidrio con unidades agregadas</returns>
        public static Vidrio operator +(Vidrio v1, Vidrio v2)
        {
            Vidrio vidrio;
            int unidadesAux = v1.unidades + v2.unidades;

            vidrio = new Vidrio(v1.id,v1.Nombre, unidadesAux, v1.peso, v1.altura, v1.anchura, v1.profundidad);

            return vidrio;
        }

        #endregion
    }
}
