using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace Entidades
{
    public static class MueblesDBO
    {

        #region Atributos
        private static string conexion = "Data Source = .; Database = Muebles; Trusted_Connection = True;";
        private static SqlConnection miConexion;//Puente
        private static SqlCommand miComando;//Quien lleva la consulta
        private static SqlDataReader info;//Quien trae la información
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad génerica que retorna la información del mueble en el que se están escribiendo los datos.
        /// </summary>
        public static SqlDataReader Info
        {
            get
            {
                return MueblesDBO.info;
            }
        }

        /// <summary>
        /// Propiedad estática que si se le pone true, cierra todas las conexiones
        /// </summary>
        public static bool CerrarConexiones
        {
            set
            {
                if(value)
                {
                    MueblesDBO.miConexion.Close();
                    MueblesDBO.Info.Close();
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor estático que inicia la conexión a la base de datos.
        /// </summary>
        static MueblesDBO()
        {
            try
            {
                MueblesDBO.miConexion = new SqlConnection(conexion);
                MueblesDBO.miConexion.Open();
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Guarda el mueble "Insert" en la base de datos
        /// </summary>
        /// <param name="mueble">Mueble que se guarda</param>
        /// <returns>True si se agrego, sino false</returns>
        public static bool GuardarMueble(Mueble mueble)
        {
            bool retorno = false;
            string consulta = string.Empty;
            string unidades = string.Empty;
            try
            {
                if (mueble.Unidades != "Un solo mueble")
                {
                    unidades = mueble.Unidades.Replace(" muebles", "");
                }
                else
                {
                    unidades = "1";
                }

                if (mueble is Madera)
                {
                    consulta = string.Format("insert into Mueble (Nombre,Peso,Altura,Anchura,Profundidad,Unidades,FechaFabricacion,Color,Material,Tipo) VALUES ('{0}',{1},{2},{3},{4},{5},'{6}','{7}','{8}','{9}');",mueble.Nombre,mueble.Peso.Replace(" kg", ""),mueble.Altura.Replace(" cm", ""), mueble.Anchura.Replace(" cm", ""),mueble.Profundidad.Replace(" cm", ""),unidades,mueble.FechaDeFabricacion,((Madera)mueble).Color, "Madera", ((Madera)mueble).TipoDeMadera);
                }
                else if(mueble is Metal)
                {
                    consulta = string.Format("insert into Mueble (Nombre,Peso,Altura,Anchura,Profundidad,Unidades,FechaFabricacion,Color,Material,Tipo) VALUES ('{0}',{1},{2},{3},{4},{5},'{6}','{7}','{8}','{9}');", mueble.Nombre, mueble.Peso.Replace(" kg", ""), mueble.Altura.Replace(" cm", ""), mueble.Anchura.Replace(" cm", ""), mueble.Profundidad.Replace(" cm", ""), unidades, mueble.FechaDeFabricacion, ((Metal)mueble).Color, "Metal", ((Metal)mueble).TipoDeMetal);
                }
                else if (mueble is Vidrio)
                {
                    consulta = string.Format("insert into Mueble (Nombre,Peso,Altura,Anchura,Profundidad,Unidades,FechaFabricacion,Color,Material,Tipo) VALUES ('{0}',{1},{2},{3},{4},{5},'{6}','{7}','{8}','{9}');", mueble.Nombre, mueble.Peso.Replace(" kg", ""), mueble.Altura.Replace(" cm", ""), mueble.Anchura.Replace(" cm", ""), mueble.Profundidad.Replace(" cm", ""), unidades, mueble.FechaDeFabricacion, eColor.Sin,"Vidrio" , "Sin tipo");
                }
                MueblesDBO.miComando = new SqlCommand();
                MueblesDBO.miComando.Connection = MueblesDBO.miConexion;
                MueblesDBO.miComando.CommandType = System.Data.CommandType.Text;

                if (MueblesDBO.miComando != null && MueblesDBO.miConexion != null)
                {
                    MueblesDBO.miComando.CommandText = consulta;
                    MueblesDBO.info = MueblesDBO.miComando.ExecuteReader();
                    retorno = true;
                }

                MueblesDBO.info.Close();
            }
            catch(Exception)
            {
                return false;
            }
            return retorno;
        }

        /// <summary>
        /// Retorna la lista de muebles con todos los datos que hay en la database
        /// </summary>
        /// <param name="consulta">La consulta con la que va a filtrar los datos</param>
        /// <returns>Lista de muebles con los datos de la base de datos</returns>
        public static List<Mueble> RetornarMuebles(string consulta)
        {

            List<Mueble> muebles = new List<Mueble>();
            Mueble muebleAux;

            try
            {
                MueblesDBO.miComando = new SqlCommand();
                MueblesDBO.miComando.Connection = MueblesDBO.miConexion;
                MueblesDBO.miComando.CommandType = System.Data.CommandType.Text;

                if (MueblesDBO.miComando != null && MueblesDBO.miConexion != null)
                {
                    MueblesDBO.miComando.CommandText = consulta;
                    MueblesDBO.info = MueblesDBO.miComando.ExecuteReader();

                    while (MueblesDBO.info.Read())
                    {
                        switch(MueblesDBO.info["Material"].ToString())
                        {
                            case "Madera":
                                muebleAux = new Madera
                                    (
                                    Convert.ToInt32(MueblesDBO.info["Id"].ToString()),
                                    MueblesDBO.info["Nombre"].ToString(),
                                    Convert.ToInt32(MueblesDBO.info["Unidades"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Peso"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Altura"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Anchura"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Profundidad"].ToString()),
                                    MueblesDBO.DevolverColor(),
                                    MueblesDBO.DevolverTipoMadera()
                                    );
                                muebleAux.CambiarFecha = DateTime.Parse(MueblesDBO.info["FechaFabricacion"].ToString());
                                muebles.Add(muebleAux);
                                break;

                            case "Metal":
                                muebleAux = new Metal
                                    (
                                    Convert.ToInt32(MueblesDBO.info["Id"].ToString()),
                                    MueblesDBO.info["Nombre"].ToString(),
                                    Convert.ToInt32(MueblesDBO.info["Unidades"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Peso"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Altura"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Anchura"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Profundidad"].ToString()),
                                    MueblesDBO.DevolverColor(),
                                    MueblesDBO.DevolverTipoMetal()
                                    );
                                muebleAux.CambiarFecha = DateTime.Parse(MueblesDBO.info["FechaFabricacion"].ToString());
                                muebles.Add(muebleAux);
                                break;

                            case "Vidrio":
                                muebleAux = new Vidrio
                                    (
                                    Convert.ToInt32(MueblesDBO.info["Id"].ToString()),
                                    MueblesDBO.info["Nombre"].ToString(),
                                    Convert.ToInt32(MueblesDBO.info["Unidades"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Peso"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Altura"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Anchura"].ToString()),
                                    Convert.ToSingle(MueblesDBO.info["Profundidad"].ToString())
                                    );
                                muebleAux.CambiarFecha = DateTime.Parse(MueblesDBO.info["FechaFabricacion"].ToString());
                                muebles.Add(muebleAux);
                                break;
                        }
                    }
                }
                MueblesDBO.info.Close();
            }
            catch(Exception)
            {

            }
            return muebles;
        }

        /// <summary>
        /// Modifica un mueble en la database
        /// </summary>
        /// <param name="nombre">Nuevo nombre</param>
        /// <param name="unidades">Unidades</param>
        /// <param name="peso">Nuevo peso</param>
        /// <param name="altura">Nueva altura</param>
        /// <param name="anchura">Nueva anchura</param>
        /// <param name="profundidad">Nueva Profundidad</param>
        /// <param name="fechaFabricacion">Nueva fecha, se deberia de usar la fecha actual</param>
        /// <param name="color">Nuevo color</param>
        /// <param name="material">Material</param>
        /// <param name="tipo">Tipo de Material</param>
        /// <param name="id">Id a modificar</param>
        /// <returns>True si se pudo modificar, sino false</returns>
        public static bool ModificarMueble(string nombre, int unidades, float peso, float altura, float anchura, float profundidad, DateTime fechaFabricacion, eColor color, string material, string tipo,int id)
        {
            bool retorno = false;
            string modificar = string.Format("update Mueble set Nombre = '{0}', Peso = {1}, Altura = {2}, Anchura = {3}, Profundidad = {4}, Unidades = {5}, FechaFabricacion = '{6}', Color = '{7}', Material = '{8}', Tipo = '{9}' where id = {10}; ", nombre, peso, altura,anchura,profundidad,unidades,fechaFabricacion,color,material,tipo,id);
            MueblesDBO.miComando = new SqlCommand();
            MueblesDBO.miComando.Connection = MueblesDBO.miConexion;
            MueblesDBO.miComando.CommandType = System.Data.CommandType.Text;

            if (MueblesDBO.miComando != null && MueblesDBO.miConexion != null)
            {
                MueblesDBO.miComando.CommandText = modificar;
                MueblesDBO.info = MueblesDBO.miComando.ExecuteReader();
                retorno = true;
            }

            MueblesDBO.info.Close();

            return retorno;
        }

        /// <summary>
        /// Permite agregar unidades a un mueble ya creado
        /// </summary>
        /// <param name="unidades">Cantidad de unidades que va a tener</param>
        /// <param name="fechaFabricacion">Fecha</param>
        /// <param name="id">Id a modificar</param>
        /// <returns></returns>
        public static bool AgregarUnidades(int unidades, DateTime fechaFabricacion, int id)
        {
            bool retorno = false;
            string modificar = string.Format("update Mueble set Unidades = {0} , FechaFabricacion = '{1}' where id = {2}; ",unidades, fechaFabricacion,id);
            MueblesDBO.miComando = new SqlCommand();
            MueblesDBO.miComando.Connection = MueblesDBO.miConexion;
            MueblesDBO.miComando.CommandType = System.Data.CommandType.Text;

            if (MueblesDBO.miComando != null && MueblesDBO.miConexion != null)
            {
                MueblesDBO.miComando.CommandText = modificar;
                MueblesDBO.info = MueblesDBO.miComando.ExecuteReader();
                retorno = true;
            }

            MueblesDBO.info.Close();

            return retorno;
        }

        /// <summary>
        /// Me permite borrar un mueble de la database
        /// </summary>
        /// <param name="id">Id a eliminar</param>
        /// <returns>True si se borro, false si no se pudo</returns>
        public static bool BorrarMueble(int id)
        {
            bool retorno = false;
            string borrar = string.Format("delete from Mueble where Id = {0}; ", id);
            MueblesDBO.miComando = new SqlCommand();
            MueblesDBO.miComando.Connection = MueblesDBO.miConexion;
            MueblesDBO.miComando.CommandType = System.Data.CommandType.Text;

            if (MueblesDBO.miComando != null && MueblesDBO.miConexion != null)
            {
                MueblesDBO.miComando.CommandText = borrar;
                MueblesDBO.info=MueblesDBO.miComando.ExecuteReader();
                retorno = true;
            }

            MueblesDBO.Info.Close();


            return retorno;
        }

        /// <summary>
        /// Devuelve el color del mueble que se toma en la database
        /// </summary>
        /// <returns>Color del mueble</returns>
        private static eColor DevolverColor()
        {
            eColor retorno=eColor.Sin;

            foreach (eColor color in Enum.GetValues(typeof(eColor)))
            {
                if (color.ToString() == MueblesDBO.info["Color"].ToString())
                {
                    retorno = color;
                }
            }
            return retorno;
        }
        
        /// <summary>
        /// Devuelve el tipo de madera del mueble que se está tomando en la database
        /// </summary>
        /// <returns>El tipo de madera de ese mueble</returns>
        private static eTipoDeMadera DevolverTipoMadera()
        {
            eTipoDeMadera retorno = eTipoDeMadera.Roble;

            foreach (eTipoDeMadera tipo in Enum.GetValues(typeof(eTipoDeMadera)))
            {
                if (tipo.ToString() == MueblesDBO.info["Tipo"].ToString())
                {
                    retorno = tipo;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Devuelve el tipo de metal del mueble que se está tomando en la database
        /// </summary>
        /// <returns>El tipo de metal del mueble actual</returns>
        private static eTipoDeMetal DevolverTipoMetal()
        {
            eTipoDeMetal retorno = eTipoDeMetal.Acero;

            foreach (eTipoDeMetal tipo in Enum.GetValues(typeof(eTipoDeMetal)))
            {
                if (tipo.ToString() == MueblesDBO.info["Tipo"].ToString())
                {
                    retorno = tipo;
                }
            }
            return retorno;
        }

        #endregion
    }
}
