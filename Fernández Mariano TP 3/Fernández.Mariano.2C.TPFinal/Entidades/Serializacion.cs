using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Entidades
{
    public static class Serializacion<T> where T : new()
    {

        #region Métodos
        /// <summary>
        /// Método génerico y estático que serializa un objeto a Xml
        /// </summary>
        /// <param name="item">objeto</param>
        /// <param name="path">ruta de archivo</param>
        /// <returns>true si salió bien, false si algo salio mal</returns>
        public static bool SerializarXml(T item, string path)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;

            try
            {
                writer = new XmlTextWriter(path,Encoding.UTF8);
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, item);
                return true;
            }
            catch(NullReferenceException)
            {
                return false;
            }
            finally
            {
                if(writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// Método génerico y estático que serializa un objeto a Binario
        /// </summary>
        /// <param name="item">objeto</param>
        /// <param name="path">ruta de archivo</param>
        /// <returns>true si salió bien, false si algo salio mal</returns>
        public static bool SerializarBinario(T item, string path)
        {
            Stream stream = null;
            BinaryFormatter serializer = null;

            try
            {
                stream = new FileStream(path,FileMode.Create);
                serializer = new BinaryFormatter();
                serializer.Serialize(stream, item);
                if (stream != null)
                {
                    stream.Close();
                }
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Método génerico y estático que deserializa un objeto a Xml
        /// </summary>
        /// <param name="item">objeto</param>
        /// <param name="path">ruta de archivo</param>
        /// <returns>El objeto deserializado</returns>
        public static T DeserializarXml(T item, string path)
        {
            try
            {
                T retorno = item;

                using(XmlTextReader reader = new XmlTextReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    retorno = (T)serializer.Deserialize(reader);
                }

                return retorno;
            }
            catch (Exception)
            {
                return item;
            }
        }

        /// <summary>
        /// Método génerico y estático que deserializa un objeto a Binario
        /// </summary>
        /// <param name="item">objeto</param>
        /// <param name="path">ruta de archivo</param>
        /// <returns>El objeto deserializado</returns>
        public static T DeserializarBinario(T item, string path)
        {
            Stream stream = null;
            BinaryFormatter serializer = null;
            try
            {
                T retorno = item;

                stream = new FileStream(path, FileMode.Open);
                serializer = new BinaryFormatter();
                retorno = (T)serializer.Deserialize(stream);

                if (stream != null)
                {
                    stream.Close();
                }

                return retorno;
            }
            catch (Exception)
            {
                return item;
            }
        }

        #endregion
    }
}
