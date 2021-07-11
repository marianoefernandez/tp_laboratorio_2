using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    #region Enumerados

    public enum eColor
    {
        Sin,
        Blanco,
        Negro,
        Verde,
        Rojo,
        Azul,
        Amarillo,
        Naranja,
        Gris,
        Violeta,
        Rosa,
        Bordo
    }

    public enum eTipoMueble
    {
        Madera,
        Metal,
        Vidrio
    }

    #endregion

    [Serializable]

    public abstract class Mueble
    {

        #region Atributos

        protected string nombre;
        protected float peso;
        protected float altura;
        protected float anchura;
        protected float profundidad;
        protected DateTime fechaFabricacion;
        protected int unidades;
        protected const int IVA = 21;//Porcentaje de Iva
        protected float precioUnidad;
        protected int id;

        #endregion

        #region Propiedades

        /// <summary>
        /// Retorna la fecha de Fabricación del mueble
        /// </summary>
        public string FechaDeFabricacion
        {
            get
            {
                return string.Format(" {0}",this.fechaFabricacion);
            }
        }

        /// <summary>
        /// Permite cambiar la fecha del mueble, se usa para la database
        /// </summary>
        public DateTime CambiarFecha
        {
            set
            {
                this.fechaFabricacion = value;
            }
        }

        /// <summary>
        /// Propiedad de sólo lectura que retorna el id del mueble.
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Propiedad de sólo lectura el nombre del mueble si o si con la primer letra en Mayúscula.
        /// 
        /// </summary>
        public string Nombre
        {
            get
            {
                try
                {
                    string nombre = this.nombre;
                    char caracter = char.ToUpper(this.nombre[0]);

                    nombre = nombre.Insert(0, caracter.ToString());
                    nombre = nombre.Remove(1, 1);

                    return nombre;
                }
                catch(IndexOutOfRangeException)
                {
                    return "Vacio";
                }
            }
        }

        /// <summary>
        /// Propiedad abstracta de sólo lectura que retorna el mueble fabricado en un formato especifico 
        /// distinto en cada clase derivada.
        /// </summary>
        public abstract string MuebleFabricado
        {
            get;
        }

        /// <summary>
        /// Propiedad de lectura y escritura que retorna el mueble actual , está pensado para usarse 
        /// en la modificación
        /// </summary>
        public Mueble MuebleActual
        {
            get
            {
                return this;
            }
            set
            {
                this.MuebleActual = value;
            }
        }

        /// <summary>
        /// Propiedad de sólo lectura que retorna la cantidad de unidades en un string + el texto unidades
        /// si por alguna razón la cantidad de unidades es menor igual a cero retornaria "NO DISPONIBLE"
        /// </summary>
        public string Unidades
        {
            get
            {
                string retorno = this.unidades.ToString() + " muebles";

                if(this.unidades <= 0)
                {
                    retorno = "NO DISPONIBLE";
                }
                else if(this.unidades == 1)
                {
                    retorno = "Un solo mueble";
                }

                return retorno;
            }
        }

        /// <summary>
        /// Propiedad de sólo lectura que llama al método CalcularCostoFinal()
        /// </summary>
        protected float CostoMueble
        {
            get
            {
                return this.CalcularCostoFinal();
            }
        }

        /// <summary>
        /// Propiedad de sólo lectura que retorna el coste de un sólo mueble
        /// </summary>
        protected float CostoPorMueble
        {
            get
            {
                return this.CostoMueble / this.unidades;
            }
        }

        /// <summary>
        /// Propiedad de solo lectura que mostrara un precio recomendado al mercado del producto fabricado, calculara 
        /// los gastos de fabricación + su 10%
        /// </summary>
        public float PrecioMueble
        {
            get
            {

                return this.CostoMueble + (this.CostoMueble / 10);

            }

        }

        /// <summary>
        /// Propiedad de sólo lectura que retorna el precio recomendado de distribución de un sólo mueble
        /// </summary>
        protected float PrecioMuebleUnidad
        {
            get
            {
                return this.PrecioMueble / this.unidades;
            }
        }

        /// <summary>
        /// Propiedad de sólo lectura que calcula el gasto del IVA
        /// </summary>
        public float ValorIVA
        {
            get
            {
                return this.PrecioMateriaPrima / 100 * IVA;
            }
        }

        /// <summary>
        /// Propiedad abstracta que calcula el precio de la materia prima, su implementación será distinta
        /// en cada derivada
        /// </summary>
        public abstract float PrecioMateriaPrima
        {
            get;
        }

        /// <summary>
        /// Propiedad abstracta que calcula los costes de producción, su implementación será distinta
        /// en cada derivada
        /// </summary>
        public abstract float CostesDeProducción
        {
            get;
        }

        /// <summary>
        /// Propiedad de sólo lectura que retorna el peso en un string + el texto kg si por alguna razón
        /// el peso es negativo retornaria "NO DISPONIBLE"
        /// </summary>
        public string Peso
        {
            get
            {
                if (this.peso > 0)
                {
                    return this.peso.ToString() + " kg";
                }
                else
                {
                    return "NO DISPONIBLE";    
                }
            }
        }

        /// <summary>
        /// Propiedad de sólo lectura que retorna la altura en un string + el texto cm si por alguna razón
        /// la altura es negativa retornaria "NO DISPONIBLE"
        /// </summary>
        public string Altura
        {
            get
            {
                if (this.altura > 0)
                {
                    return this.altura.ToString() + " cm";
                }
                else
                {
                    return "NO DISPONIBLE";
                }
            }
        }

        /// <summary>
        /// Propiedad de sólo lectura que retorna la anchura en un string + el texto cm si por alguna razón
        /// la anchura es negativa retornaria "NO DISPONIBLE"
        /// </summary>
        public string Anchura
        {
            get
            {
                if (this.anchura > 0)
                {
                    return this.anchura.ToString() + " cm";
                }
                else
                {
                    return "NO DISPONIBLE";
                }
            }
        }

        /// <summary>
        /// Propiedad de sólo lectura que retorna la profundidad en un string + el texto cm si por alguna razón
        /// la profundidad es negativa retornaria "NO DISPONIBLE"
        /// </summary>
        public string Profundidad
        {
            get
            {
                if (this.profundidad > 0)
                {
                    return this.profundidad.ToString() + " cm";
                }
                else
                {
                    return "NO DISPONIBLE";
                }
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor parametrizado con los datos del Mueble
        /// </summary>
        /// <param name="id">Id del mueble</param>
        /// <param name="nombre">Nombre del mueble</param>
        /// <param name="unidades">Cantidad de unidades</param>
        /// <param name="peso">Su peso en kg</param>
        /// <param name="altura">Su altura en cm</param>
        /// <param name="anchura">Su anchura en cm</param>
        /// <param name="profundidad">Su profundidad en cm</param>
        public Mueble(int id,string nombre, int unidades, float peso, float altura, float anchura, float profundidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.peso = peso;
            this.altura = altura;
            this.anchura = anchura;
            this.profundidad = profundidad;
            this.fechaFabricacion = DateTime.Now;
            this.unidades = unidades;
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Sobrecarga del ToString() que retorna la información general del mueble
        /// </summary>
        /// <returns>String con la información</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Nombre del mueble:{0}", this.Nombre);
            sb.AppendFormat("\nId:{0}", this.Id);
            sb.AppendFormat("\nPeso:{0}", this.Peso);
            sb.AppendFormat("\nAltura:{0}", this.Altura);
            sb.AppendFormat("\nAnchura:{0}", this.Anchura);
            sb.AppendFormat("\nProfundidad:{0}", this.Profundidad);
            sb.AppendFormat("\nUnidades a fabricadas:{0}\n", this.Unidades);

            return sb.ToString();
        }

        /// <summary>
        /// Valida que las medidas de altura, peso, anchura o profundidad sean mayores a cero
        /// </summary>
        /// <returns>true si son mayores a cero, false si alguna o todas son cero</returns>
        public bool ValidarMedidas()
        {
            bool retorno = !(this.Altura == "NO DISPONIBLE" || this.Peso == "NO DISPONIBLE" || this.Anchura == "NO DISPONIBLE" || this.Profundidad == "NO DISPONIBLE");
            try
            {
                if(!retorno)
                {
                    throw new MuebleExcepcion("Los campos del mueble no están correctos");
                }
                return retorno;
            }
            catch
            {
                return retorno;
            }            
        }

        /// <summary>
        /// Valida que los valores que le paso al mueble sean coherentes
        /// </summary>
        /// <returns>Retorna true si el valor del mueble no es coherente sino false</returns>
        public bool ValoresIncoherentes()
        {
            bool retorno = !(this.PrecioMateriaPrima.Equals(0) || (float)this == 0 || this.CostesDeProducción.Equals(0) || this.PrecioMueble.Equals(0));
            try
            {
                if (!retorno)
                {
                    throw new MuebleExcepcion("No puede haber muebles sin gastos ni costes de producción");
                }
                return retorno;
            }
            catch
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que retorna la facturación del mueble actual
        /// </summary>
        /// <returns>string con la facturación del mueble</returns>
        public virtual string Facturacion()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\nGasto en materia prima en {0}:{1}", this.Unidades, this.PrecioMateriaPrima.FormatearPrecio());
            sb.AppendFormat("\nCostos de Producción:{0}", this.CostesDeProducción.FormatearPrecio());
            sb.AppendFormat("\nIVA por Materia Prima:{0}", this.ValorIVA.FormatearPrecio());
            sb.AppendFormat("\n\nCosto total de fabricación:{0}", this.CostoMueble.FormatearPrecio());
            sb.AppendFormat("\nCosto total por unidad:{0}", this.CostoPorMueble.FormatearPrecio());
            sb.AppendFormat("\n\nPrecio recomendado para distribuir:{0}", this.PrecioMueble.FormatearPrecio());
            sb.AppendFormat("\nPrecio recomendado para distribuir por unidad:{0}\n\n", this.PrecioMuebleUnidad.FormatearPrecio());

            return sb.ToString();
        }

        /// <summary>
        /// Método abstracto que retorna la información del mueble
        /// </summary>
        /// <returns></returns>
        public abstract string InformacionDelMueble();

        /// <summary>
        /// Método abstracto que calcula el Costo Final del mueble
        /// </summary>
        /// <returns></returns>
        protected abstract float CalcularCostoFinal();

        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga que indica si dos muebles son iguales llama a las sobrecargas == de sus derivadas ,
        /// dependiendo de que tipo de mueble sea.
        /// </summary>
        /// <param name="m1">Mueble 1</param>
        /// <param name="m2">Mueble 2</param>
        /// <returns>Retorna true si todos los datos del mueble son iguales menos sus unidades que pueden
        /// ser distintas, sino retorna false</returns>
        public static bool operator == (Mueble m1, Mueble m2)
        {
            bool retorno = false;
            
            if(m1 is Madera && m2 is Madera)
            {
                retorno = (Madera)m1 == (Madera)m2;
            }
            else if (m1 is Metal && m2 is Metal)
            {
                retorno = (Metal)m1 == (Metal)m2;
            }
            else if (m1 is Vidrio && m2 is Vidrio)
            {
                retorno = (Vidrio)m1 == (Vidrio)m2;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga que indica si un mueble es distinto a otro
        /// </summary>
        /// <param name="m1">Mueble 1</param>
        /// <param name="m2">Mueble 2</param>
        /// <returns>Retorna true si son distintos, sino false</returns>
        public static bool operator !=(Mueble m1, Mueble m2)
        {
            return !(m1 == m2);
        }

        /// <summary>
        /// Sobrecarga del + que indica agrega un mueble a la lista de muebles , si el mueble ya existe 
        /// no lo sobreescribe sino que agrega las unidades del mueble que es identico a ese.
        /// </summary>
        /// <param name="muebles">Lista de muebles</param>
        /// <param name="mueble">Objeto mueble</param>
        /// <returns>La lista actualizada</returns>
        public static List<Mueble> operator +(List<Mueble> muebles, Mueble mueble)
        {

            bool sonDistintos = true;
            int indiceAux = 0;
            Mueble muebleAux = mueble;

            foreach (Mueble m in muebles)
            {
                if (mueble.GetType() == m.GetType() && mueble == m)
                {
                    indiceAux = muebles.IndexOf(m);
                    muebleAux += m;
                    sonDistintos = false;
                    muebles.Insert(indiceAux,muebleAux);
                    muebles.RemoveAt(indiceAux + 1);
                    break;
                }
            }

            if(sonDistintos && mueble.ValidarMedidas())
            {
                muebles.Add(mueble);   
            }

            return muebles;
        }

        /// <summary>
        /// Sobrecarga del objeto mueble que retorna que agrega unidades a un mueble , se usa para agregar
        /// elementos a muebles iguales
        /// </summary>
        /// <param name="m1">Mueble 1</param>
        /// <param name="m2">Mueble 2</param>
        /// <returns>Nuevo mueble con la suma de las unidades del mueble 1 y las unidades del mueble 2</returns>
        public static Mueble operator +(Mueble m1, Mueble m2)
        {
            Mueble mueble = m1;

            if (m1 is Metal && m2 is Metal)
            {
                mueble = (Metal)mueble + (Metal)m2;
            }
            else if (m1 is Madera && m2 is Madera)
            {
                mueble = (Madera)mueble + (Madera)m2;
            }
            else if (m1 is Vidrio && m2 is Vidrio)
            {
                mueble = (Vidrio)mueble + (Vidrio)m2;
            }

            return mueble;
        }

        /// <summary>
        /// Sobrecarga - que quita un mueble de la lista de muebles siempre y cuando este mueble exista
        /// </summary>
        /// <param name="muebles">Lista de muebles</param>
        /// <param name="mueble">Mueble a eliminar</param>
        /// <returns>Lista actualizada</returns>
        public static List<Mueble> operator -(List<Mueble> muebles, Mueble mueble)
        {
            foreach (Mueble m in muebles)
            {
                if (mueble.GetType() == m.GetType() && mueble == m)
                {
                    muebles.Remove(mueble);
                    break;
                }
            }

            return muebles;
        }

        /// <summary>
        /// Conversión explicita float que retorna el costo del mueble , se usa para que la fabrica calcule
        /// el costo total de los muebles
        /// </summary>
        /// <param name="m">objeto Mueble</param>
        public static explicit operator float(Mueble m)
        {
            return m.CostoMueble;
        }

        /// <summary>
        /// Conversión explicita int que retorna la cantidad de unidades , se usa para que la fabrica calcule
        /// todos los muebles que han sido fabricados.
        /// </summary>
        /// <param name="m">objeto Mueble</param>
        public static explicit operator int(Mueble m)
        {
            return m.unidades;
        }


        #endregion
    }
}
