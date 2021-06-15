using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class Facturacion
    {

        #region Métodos

        /// <summary>
        /// Método estático que genera un .txt con la información del mueble. El nombre del archivo
        /// tiene las caracteristicas del mueble para que siempre se genere un txt distinto
        /// en caso de error , no guarda nada, simplemente capturo cualquiera de sus excepciones
        /// y me protejo de cualquier excepcion que pueda cerrar el programa
        /// </summary>
        /// <param name="ubicacionArchivo">Path donde se va a guardar el archivo</param>
        /// <param name="mueble">Objeto mueble</param>
        public static void GenerarUnMuebleTxt(string ubicacionArchivo,Mueble mueble)
        {
            try
            {
                ubicacionArchivo += string.Format("\\{0} {1} {2} {3} {4}.txt", mueble.MuebleFabricado, mueble.Peso, mueble.Altura, mueble.Anchura, mueble.Profundidad);
                StreamWriter archivoTxt = new StreamWriter(ubicacionArchivo);

                archivoTxt.Write(mueble.InformacionDelMueble() + mueble.Facturacion());

                archivoTxt.Close();
            }
            catch(Exception)
            {

            }
        }
        /// <summary>
        /// Método estático que genera un .txt con la información de la fabrica. 
        /// El nombre del archivo es Muebles Fernández.txt ya que no hay dos fabricas, 
        /// siempre que se imprime sobreescribe el anterior.
        ///en caso de error , no guarda nada, simplemente capturo cualquiera de sus excepciones
        /// y me protejo de cualquier excepcion que pueda cerrar el programa
        /// </summary>
        /// <param name="ubicacionArchivo">Path donde se va a guardar el archivo</param>
        public static void GenerarFabricaTxt(string ubicacionArchivo)
        {
            try
            {
                ubicacionArchivo += string.Format("\\Muebles Fernández.txt");
                StreamWriter archivoTxt = new StreamWriter(ubicacionArchivo);

                archivoTxt.Write(Fabrica.RetornarInformacionTotal());

                archivoTxt.Close();
            }
            catch(Exception)
            {

            }
        }

        #endregion

    }
}
