using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestearFabricaFernandez
{
    [TestClass]
    public class TestearMuebles
    {
        #region Carga de Datos
        /// <summary>
        /// Carga todos los datos a la lista para que se testeen
        /// </summary>
        public void CargaDeDatos()
        {
            Mueble sillaMaderaRoble = new Madera(1,"silla de madera", 3, (float)2.6, 38, 32, 29, eColor.Rojo, eTipoDeMadera.Roble);
            Mueble sillaMaderaRoble2 = new Madera(2,"Silla de madera", 7, (float)2.6, 38, 32, 29, eColor.Rojo, eTipoDeMadera.Roble);
            Mueble mesaMaderaAbedul = new Madera(3,"Mesa de madera", 9, (float)8.7, 65, 51, 44, eColor.Negro, eTipoDeMadera.Abedul);
            Mueble escritorioMaderaPino = new Madera(4,"Escritorio de madera", 5, (float)6.9, 46, 40, 38, eColor.Sin, eTipoDeMadera.Pino);
            Mueble sillaMetalAluminio = new Metal(5,"Silla de aluminio", 1, (float)4.4, 41, 34, 25, eColor.Violeta, eTipoDeMetal.Aluminio);//Deberia setear el color en Sin
            Mueble mesaMetalAcero = new Metal(6,"Mesa de acero", 2, (float)9.9, 66, 49, 41, eColor.Verde, eTipoDeMetal.Acero);
            Mueble mesaVidrio = new Vidrio(7,"Mesa de vidrio", 4, (float)7.6, 61, 47, 43);

            Fabrica.AgregarMueble = sillaMaderaRoble;
            Fabrica.AgregarMueble = sillaMaderaRoble2;
            Fabrica.AgregarMueble = mesaMaderaAbedul;
            Fabrica.AgregarMueble = escritorioMaderaPino;
            Fabrica.AgregarMueble = sillaMetalAluminio;
            Fabrica.AgregarMueble = mesaMetalAcero;
            Fabrica.AgregarMueble = mesaVidrio;

            Mueble mesaVidrio2 = new Vidrio();//Por defecto, no deberia dejar de agregar a la lista
            Mueble mesaMadera = new Madera();//Por defecto, no deberia dejar de agregar a la lista
            Mueble sillaMetal = new Metal();//Por defecto, no deberia dejar de agregar a la lista

            Fabrica.AgregarMueble = mesaVidrio2;//NO SE AGREGA A LA LISTA
            Fabrica.AgregarMueble = mesaMadera;//NO SE AGREGA A LA LISTA
            Fabrica.AgregarMueble = sillaMetal;//NO SE AGREGA A LA LISTA
        }
        #endregion

        /// <summary>
        /// Testea que todos los campos del mueble esten correctos y no den "NO DISPONIBLE" y el nombre no sea nulo y que el mueble fabricado no sea un string vacio
        /// </summary>
        [TestMethod]
        public void CamposCorrectos()
        {

            //ARRANGE
            CargaDeDatos();
            bool resultado;

            try
            {
                foreach (Mueble mueble in Fabrica.Muebles)//Siempre testeo los datos de la fabrica ya que otros datos no se van a cargar en ningún lado
                {
                    //ACT
                    resultado = (mueble.ValidarMedidas() && !(mueble.MuebleFabricado.Equals(string.Empty)));

                    //ASSERT
                    Assert.IsTrue(resultado);
                }
                Fabrica.Muebles.Clear();
            }
            catch (MuebleExcepcion)
            {
                Assert.IsFalse(false);
            }
        }

        /// <summary>
        /// Testea que el mueble no sea nulo
        /// </summary>
        [TestMethod]
        public void MuebleNotNull()
        {
            //ARRANGE y ACT
            CargaDeDatos();
            try
            {
                foreach (Mueble mueble in Fabrica.Muebles)//Siempre testeo los datos de la fabrica ya que otros datos no se van a cargar en ningún lado
                {
                    //ASSERT
                    Assert.IsNotNull(mueble);
                }
                Fabrica.Muebles.Clear();
            }
            catch(NullReferenceException)
            {
                Assert.IsFalse(false);
            }
        }

        /// <summary>
        /// Testea que ninguna propiedad de la lista retorne como valor un cero, ya que el programa no lo permite
        /// </summary>
        [TestMethod]
        public void ValoresIncoherentes()
        {
            bool resultado;
            CargaDeDatos();
            try
            {
                //ARRANGE
                foreach (Mueble mueble in Fabrica.Muebles)//Siempre testeo los datos de la fabrica ya que otros datos no se van a cargar en ningún lado
                {
                    //ACT 
                    resultado = mueble.ValoresIncoherentes();
                    //ASSERT
                    Assert.IsTrue(resultado);
                }
                Fabrica.Muebles.Clear();
            }
            catch(MuebleExcepcion)
            {
                Assert.IsTrue(false);
            }
        }

        /// <summary>
        /// Testea que dos muebles sean iguales
        /// </summary>
        /// <param name="m1">Mueble 1</param>
        /// <param name="m2">Mueble 2</param>
        [TestMethod]
        public void MueblesIguales()
        {
            //ARRANGE
            Madera madera1 = new Madera(1,"Silla", 2, 8, 22, 33, 12, eColor.Rojo, eTipoDeMadera.Roble);
            Madera madera2 = new Madera(1,"Silla", 2, 8, 22, 33, 12, eColor.Rojo, eTipoDeMadera.Roble);
            Metal metal1 = new Metal(2,"Mesa", 4, 9, 20, 37, 12, eColor.Rojo, eTipoDeMetal.Acero);
            Metal metal2 = new Metal(2,"Mesa", 9, 9, 20, 37, 12, eColor.Rojo, eTipoDeMetal.Acero);
            Vidrio vidrio1 = new Vidrio(3,"Mesa", 11, 3, 25, 31, 11);
            Vidrio vidrio2 = new Vidrio(3,"Mesa", 5, 3, 25, 31, 11);
            bool resultado;

            //ACT
            resultado = madera1 == madera2;

            //ASSERT
            Assert.IsTrue(resultado);

            //ACT
            resultado = metal1 == metal2;

            //ASSERT
            Assert.IsTrue(resultado);

            //ACT
            resultado = vidrio1 == vidrio2;

            //ASSERT
            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Testea si se agrega un mueble
        /// </summary>
        [TestMethod]
        public void TestearAgregarMueble()
        {
            //ARRANGE
            Madera madera = new Madera(1,"Silla", 2, 8, 22, 33, 12, eColor.Rojo, eTipoDeMadera.Roble);
            bool resultado = false;

            //ACT
            Fabrica.AgregarMueble = madera;

            foreach (Mueble mueble in Fabrica.Muebles)
            {
                if(mueble.Equals(madera))
                {
                    resultado = true;
                    Fabrica.QuitarMueble = madera;
                    break;
                }
            }

            //ASSERT
            Assert.IsTrue(resultado);
        }
    }
}
