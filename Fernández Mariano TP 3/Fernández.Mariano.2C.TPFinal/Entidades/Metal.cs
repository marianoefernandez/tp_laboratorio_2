using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    #region Enumerados

    public enum eTipoDeMetal
    {
        Acero,
        Aluminio
    }

    #endregion

    [Serializable]

    public class Metal : Mueble,IEsPintable
    {

        #region Atributos

        private const int PRECIOALUMINIO = 2014;//Precio en USD tonelada
        private const int PRECIOACERO = 747;//Precio en USD tonelada

        private eColor color;
        private eTipoDeMetal tipoDeMetal;

        #endregion

        #region Propiedades

        /// <summary>
        /// Retorna true si el metal es de acero, sino retorna false
        /// </summary>
        public bool EsPintable
        {
            get
            {
                bool retorno = false;
                
                if(this.tipoDeMetal == eTipoDeMetal.Acero)
                {
                    retorno = true;
                }
                
                return retorno;
            }
        }

        /// <summary>
        /// Retorna el precio del pintado que seria un 8% extra al valor de la materia prima
        /// </summary>
        public float PrecioPintado
        {
            get
            {
                return this.PrecioMateriaPrima / 100 * 8;
            }
        }

        /// <summary>
        /// Retorna un mueble de metal fabricado con su nombre + tipo de metal
        /// </summary>
        public override string MuebleFabricado
        {
            get
            {
                return string.Format("{0} de {1}", this.Nombre,this.tipoDeMetal);
            }
        }

        /// <summary>
        /// Calcula el precio de la materia prima dependiendo del tipo de metal y su valor por tonelada y 
        ///luego lo multiplica por la cantidad de unidades.
        /// </summary>
        public override float PrecioMateriaPrima
        {
            get
            {
                try
                {
                    float retorno = 0;

                    switch (this.tipoDeMetal)
                    {
                        case eTipoDeMetal.Aluminio:
                            retorno = this.peso * ((float)PRECIOALUMINIO / 1000);//Valor por materia prima en kilo
                            break;

                        case eTipoDeMetal.Acero:
                            retorno = this.peso * ((float)PRECIOACERO / 1000);//Valor por materia prima en kilo
                            break;
                    }

                    if (retorno <= 0)
                    {
                        throw new MuebleExcepcion("Los costes deben ser mayores a cero");
                    }

                    return retorno * this.unidades;
                }
                catch(MuebleExcepcion)
                {
                    this.peso = 0;
                    return 0;
                }
            }
        }

        /// <summary>
        /// Calcula los costes de producción promedio dependiendo del uso de materiales, maquina y mano de obra , 
        /// y traslado más los sueldos de los empleados , cómo los empleados cobran el doble a la noche, 
        /// se duplican los costes. Por lo general para el metal los costes de producción son del 10% promedio por unidad.
        /// Tambien si es de color se le suma el precio del pintado a los costes de producción.
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
                        retorno += (this.PrecioMateriaPrima / 100) * 20;//Costos por horario 20%
                    }
                    else
                    {
                        retorno += (this.PrecioMateriaPrima / 100) * 10;//Costos por horario 10%

                    }

                    if (this.EsPintable && this.color != eColor.Sin)
                    {
                        retorno += this.PrecioPintado;
                    }

                    if (retorno <= 0)
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
        /// Constructor parametrizado con los datos del Mueble de Metal
        /// Si el mueble es de Alumnio no se puede pintar
        /// </summary>
        /// <param name="nombre">Nombre del mueble</param>
        /// <param name="cantidad">Cantidad de unidades</param>
        /// <param name="peso">Su peso en kg</param>
        /// <param name="altura">Su altura en cm</param>
        /// <param name="anchura">Su anchura en cm</param>
        /// <param name="profundidad">Su profundidad en cm</param>
        /// <param name="color">Color del mueble, si es aluminio el color es sin</param>
        /// <param name="tipo">El tipo de metal</param>
        public Metal(string nombre, int cantidad, float peso, float altura, float anchura, float profundidad, eColor color, eTipoDeMetal tipo) : base(nombre, cantidad, peso, altura, anchura, profundidad)
        {
            if(tipo == eTipoDeMetal.Aluminio)
            {
                this.color = eColor.Sin;
            }
            else
            {
                this.color = color;
            }
            this.tipoDeMetal = tipo;
        }

        /// <summary>
        /// Constructor por defecto que inicializa las unidades en 1, el nombre en string.empty, 
        /// sus datos en 0 y el color en sin y el tipo de metal en aluminio.
        /// </summary>
        public Metal() : this(string.Empty, 0, 0, 0, 0, 0, eColor.Sin, eTipoDeMetal.Aluminio)
        {

        }

        #endregion

        #region Métodos

        /// <summary>
        /// Sobrecarga del ToString() que retorna la información del mueble de metal, si el mueble de metal
        /// es Aluminio no muestra la información del color.
        /// </summary>
        /// <returns>string con todos los datos del mueble de metal</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Tipo de Mueble: Metal");
            sb.AppendFormat("\nTipo de Metal: {0}", this.tipoDeMetal);
            if (this.color == eColor.Sin)
            {
                if(this.tipoDeMetal == eTipoDeMetal.Acero)
                {
                    sb.AppendFormat("\nColor:Sin pintar");
                }
                sb.AppendFormat("\n");

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
        /// Sobreescritura del método virtual de la clase base que calcula su Facturación del mueble de metal
        /// </summary>
        /// <returns>La facturación en string</returns>
        public override string Facturacion()
        {
            return base.Facturacion();
        }

        /// <summary>
        /// Metodo que llama al ToString() de la base para imprimir la información del metal.
        /// </summary>
        /// <returns>String con la info del metal</returns>
        public override string InformacionDelMueble()
        { 
            return this.ToString();
        }


        /// <summary>
        /// Calcula un estimado precio final de la fabricación de un mueble en el que depende de la hora de su fabricación
        /// Si se fabrica entre las 20 hs hasta las 6 hs se cobrara entre un 20% sobre el valor de la materia prima debido al que en el horario nocturno se paga más
        /// Mientras que si es fuera de dicho horario se estimaria que su costo estaria entre un 10% de su valor, también se debe agregar un 21% de IVA sobre la materia prima.
        ///  Si el color es distinto a "Sin" se le cobrara un 8% del precio de Materia Prima 
        ///  para cubrir el costo de pintado
        /// </summary>
        /// <returns>Float con el precio final</returns>
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
                    throw new MuebleExcepcion("El costo debe ser mayor a cero");
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
        /// Sobrecarga del == que indica si dos muebles de metal son iguales.
        /// </summary>
        /// <param name="m1">Mueble de metal 1</param>
        /// <param name="m2">Mueble de metal 2</param>
        /// <returns>Retorna true si los dos muebles de metal coinciden todos sus datos , excepto la cantidad
        /// de unidades que puede coincidir o no , sino retorna false</returns>
        public static bool operator == (Metal m1,Metal m2)
        {
            bool retorno = false;

            if (m1.altura.Equals(m2.altura) && m1.peso.Equals(m2.peso) && m1.anchura.Equals(m2.anchura) && m1.profundidad.Equals(m2.profundidad) && m1.Nombre.Equals(m2.Nombre) && m1.tipoDeMetal.Equals(m2.tipoDeMetal) && m1.color.Equals(m2.color))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga distinto que indica si dos muebles de metal son diferentes
        /// </summary>
        /// <param name="m1">Mueble de metal 1</param>
        /// <param name="m2">Mueble de metal 2</param>
        /// <returns>Retorna true si son distintos y false si son iguales 
        /// con el mismo criterio del == </returns>
        public static bool operator !=(Metal m1, Metal m2)
        {
            return !(m1 == m2);
        }

        /// <summary>
        /// Sobrecarga que me permite añadir más unidades a un mismo mueble , modificando sus costes también
        /// </summary>
        /// <param name="m1">Mueble de metal 1</param>
        /// <param name="m2">Mueble de metal 2</param>
        /// <returns>Retorna el mueble de metal con unidades agregadas</returns>
        public static Metal operator +(Metal m1, Metal m2)
        {
            Metal metal;
            int unidadesAux = m1.unidades + m2.unidades;

            metal = new Metal(m1.Nombre, unidadesAux, m1.peso, m1.altura, m1.anchura, m1.profundidad, m1.color, m1.tipoDeMetal);

            return metal;
        }

        #endregion
    }
}
