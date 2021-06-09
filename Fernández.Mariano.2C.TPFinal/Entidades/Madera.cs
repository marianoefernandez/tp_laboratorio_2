using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    #region Enumerados

    public enum eTipoDeMadera
    {
        Roble,
        Pino,
        Abedul
    }


    #endregion
    
    [Serializable]

    public class Madera : Mueble,IEsPintable
    {

        #region Atributos

        private const int PRECIOROBLE = 835;//Precio en USD tonelada
        private const int PRECIOPINO = 752;//Precio en USD tonelada
        private const int PRECIOABEDUL = 704;//Precio en USD tonelada 
        private const int IMPUESTOPORMADERADEROBLE = 10;

        private eColor color;
        private eTipoDeMadera tipoDeMadera;

        #endregion

        #region Propiedades

        /// <summary>
        /// Retorna true porque todas las maderas se pueden pintar
        /// </summary>
        public bool EsPintable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Retorna el precio del pintado que seria un 7% extra al valor de la materia prima
        /// </summary>
        public float PrecioPintado
        {
            get
            {
                return this.PrecioMateriaPrima / 100 * 7;
            }
        }

        /// <summary>
        /// Retorna un mueble de madera fabricado con su nombre + tipo de mueble + tipo de madera
        /// </summary>
        public override string MuebleFabricado
        {
            get
            {
                return string.Format("{0} de {1} de {2}", this.Nombre, this.GetType().Name, this.tipoDeMadera);
            }
        }

        /// <summary>
        /// Calcula el precio de la materia prima dependiendo del tipo de madera y su valor por tonelada y 
        ///luego lo multiplica por la cantidad de unidades.
        /// </summary>
        public override float PrecioMateriaPrima
        {
            get
            {
                try
                {
                    float retorno = 0;

                    switch (this.tipoDeMadera)
                    {
                        case eTipoDeMadera.Roble:
                            retorno = this.peso * ((float)PRECIOROBLE / 1000);//Valor por materia prima en kilo
                            break;

                        case eTipoDeMadera.Abedul:
                            retorno = this.peso * ((float)PRECIOABEDUL / 1000);//Valor por materia prima en kilo
                            break;

                        case eTipoDeMadera.Pino:
                            retorno = this.peso * ((float)PRECIOPINO / 1000);//Valor por materia prima en kilo
                            break;
                    }

                    if (retorno <= 0)
                    {
                        throw new MuebleExcepcion("El gasto tiene que ser mayor a 0");
                    }

                    return retorno * this.unidades;
                }
                catch(MuebleExcepcion)
                {
                    this.peso = 0;//Esto hace que por si hay algun error, el peso sea 0 y nunca pueda ser añadido a la lista.
                    return 0;
                }
            }
        }

        /// <summary>
        /// Calcula el impuesto que la ciudad cobra por talar la madera de roble
        /// </summary>
        private float Impuesto
        {
            get
            {
                return this.PrecioMateriaPrima / 100 * IMPUESTOPORMADERADEROBLE;//Impuesto del 10% por madera de roble
            }
        }

        /// <summary>
        /// Calcula los costes de producción promedio dependiendo del uso de materiales, maquina y mano de obra , 
        /// y traslado más los sueldos de los empleados , cómo los empleados cobran el doble a la noche, 
        /// se duplican los costes. Por lo general para la madera los costes de producción son del 7% promedio por unidad.
        /// </summary>
        public override float CostesDeProducción
        {
            get
            {
                try
                {
                    float retorno = 0;

                    if (DateTime.Now.Hour >= 20 || DateTime.Now.Hour < 6)
                    {
                        retorno += (this.PrecioMateriaPrima / 100) * 14;//Costos por horario 14%
                    }
                    else
                    {
                        retorno += (this.PrecioMateriaPrima / 100) * 7;//Costos por horario 7%

                    }

                    if (this.EsPintable && this.color != eColor.Sin)
                    {
                        retorno += this.PrecioPintado;
                    }

                    if(retorno<=0)
                    {
                        throw new MuebleExcepcion("Los costes deben ser mayores a cero");
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
        /// Constructor parametrizado con los datos del Mueble de Madera
        /// </summary>
        /// <param name="nombre">Nombre del mueble</param>
        /// <param name="unidades">Cantidad de unidades</param>
        /// <param name="peso">Su peso en kg</param>
        /// <param name="altura">Su altura en cm</param>
        /// <param name="anchura">Su anchura en cm</param>
        /// <param name="profundidad">Su profundidad en cm</param>
        /// <param name="color">Color del mueble</param>
        /// <param name="tipo">El tipo de madera</param>
        public Madera(string nombre, int unidades, float peso, float altura, float anchura, float profundidad, eColor color, eTipoDeMadera tipo) : base(nombre, unidades, peso, altura, anchura, profundidad)
        {
            this.color = color;
            this.tipoDeMadera = tipo;
        }
        /// <summary>
        /// Constructor por defecto que inicializa las unidades en 1, el nombre en string.empty, 
        /// sus datos en 0 y el color en sin y el tipo de madera de roble
        /// </summary>
        public Madera():this(string.Empty,0,0,0,0,0,eColor.Sin,eTipoDeMadera.Roble)
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
            sb.Append("Tipo de Mueble: Madera");
            sb.AppendFormat("\nTipo de Madera: {0}", this.tipoDeMadera);
            if (this.color == eColor.Sin)
            {
                sb.AppendFormat("\nColor:Sin pintar\n");
            }
            else
            {
                sb.AppendFormat("\nColor: {0}\n", this.color);
            }
            sb.Append(base.ToString());
            sb.AppendFormat("\nFecha y hora de Fabricación:{0}\n", this.fechaFabricacion);
            
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del método virtual Facturación.
        /// Podria haber hecho el base acá también, pero queria mostrar el impuesto al roble,  justo 
        /// después del gasto en Materia Prima y no antes ni después.
        /// </summary>
        /// <returns>string con la facturación del mueble</returns>
        public override string Facturacion()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Gasto en materia prima en {0}:{1:N2} $", this.Unidades,this.PrecioMateriaPrima);
            if (this.tipoDeMadera == eTipoDeMadera.Roble && this is Madera)
            {
                sb.AppendFormat("\nImpuesto al roble:{0:N2} $", this.Impuesto);
            }
            sb.AppendFormat("\nCostos de Producción:{0:N2} $", this.CostesDeProducción);
            sb.AppendFormat("\nIVA por Materia Prima:{0:N2} $", this.ValorIVA);
            sb.AppendFormat("\n\nCosto total de fabricación:{0:N2} $", this.CostoMueble);
            sb.AppendFormat("\nCosto total por unidad:{0:N2} $", this.CostoPorMueble);
            sb.AppendFormat("\n\nPrecio recomendado para distribuir:{0:N2} $", this.PrecioMueble);
            sb.AppendFormat("\nPrecio recomendado para distribuir por unidad:{0:N2} $\n\n", this.PrecioMuebleUnidad);

            return sb.ToString();
        }

        /// <summary>
        /// Retorna la información del mueble llamando al ToString() del this
        /// </summary>
        /// <returns>String con la info</returns>
        public override string InformacionDelMueble()
        {
            return this.ToString();
        }

        /// <summary>
        /// Calcula un estimado precio final de la fabricación de un mueble en el que depende de la hora de su fabricación
        /// Si se fabrica entre las 20 hs hasta las 6 hs se cobrara entre un 14% sobre el valor de la materia prima debido al que en el horario nocturno los empleados cobran el doble.
        /// Mientras que si es fuera de dicho horario se estimaria que su costo estaria entre un 7% de su valor, 
        /// también se debe agregar un 21% de IVA sobre la materia prima. Se cobrara un impuesto especial 
        /// de 10% sobre la madera de roble.  Si el color es distinto a "Sin" se le cobrara un 7% del precio de Materia Prima
        /// </summary>
        /// <returns>Un float con los datos</returns>
        protected override float CalcularCostoFinal()
        {
            try
            {
                float retorno = 0;

                retorno = this.PrecioMateriaPrima;

                if (this.tipoDeMadera == eTipoDeMadera.Roble)
                {
                    retorno += this.Impuesto;//Impuesto por roble
                }

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
        /// Sobrecarga del == que indica si dos muebles de madera son iguales.
        /// </summary>
        /// <param name="m1">Mueble de madera 1</param>
        /// <param name="m2">Mueble de madera 2</param>
        /// <returns>Retorna true si los dos muebles de madera coinciden todos sus datos , excepto la cantidad
        /// de unidades que puede coincidir o no , sino retorna false</returns>
        public static bool operator ==(Madera m1, Madera m2)
        {
            bool retorno = false;

            if(m1.altura.Equals(m2.altura) && m1.peso.Equals(m2.peso) && m1.anchura.Equals(m2.anchura) && m1.profundidad.Equals(m2.profundidad) && m1.Nombre.Equals(m2.Nombre) && m1.tipoDeMadera.Equals(m2.tipoDeMadera) && m1.color.Equals(m2.color))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga distinto que indica si dos muebles de madera son diferentes
        /// </summary>
        /// <param name="m1">Mueble de madera 1</param>
        /// <param name="m2">Mueble de madera 2</param>
        /// <returns>Retorna true si son distintos y false si son iguales 
        /// con el mismo criterio del == </returns>
        public static bool operator !=(Madera m1, Madera m2)
        {
            return !(m1 == m2);
        }

        /// <summary>
        /// Sobrecarga que me permite añadir más unidades a un mismo mueble , modificando sus costes también
        /// </summary>
        /// <param name="m1">Mueble de madera 1</param>
        /// <param name="m2">Mueble de madera 2</param>
        /// <returns>Retorna el mueble de madera con unidades agregadas</returns>
        public static Madera operator +(Madera m1, Madera m2)
        {
            Madera madera;
            int unidadesAux = m1.unidades + m2.unidades;

            madera = new Madera(m1.Nombre, unidadesAux, m1.peso, m1.altura, m1.anchura, m1.profundidad, m1.color, m1.tipoDeMadera);

            return madera;
        }

        #endregion
    }
}
