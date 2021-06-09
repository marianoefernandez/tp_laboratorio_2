using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestearFabricaFernandez
{
    [TestClass]
    public class TestearMuebles
    {
        /// <summary>
        /// Testea que todos los campos del mueble esten correctos y no den "NO DISPONIBLE" y el nombre no sea nulo y que el mueble fabricado no sea un string vacio
        /// </summary>
        [TestMethod]
        public void CamposCorrectos()
        {

            //ARRANGE
            bool resultado;
            foreach (Mueble mueble in Fabrica.Muebles)//Siempre testeo los datos de la fabrica ya que otros datos no se van a cargar en ningún lado
            { 
                //ACT
                resultado = (mueble.ValidarMedidas() && !(mueble.MuebleFabricado.Equals(string.Empty)));
                //ASSERT
                Assert.IsTrue(resultado);
            }
        }
        
        /// <summary>
        /// Testea que el mueble no sea nulo
        /// </summary>
        [TestMethod]
        public void MuebleNotNull()
        {
            //ARRANGE y ACT
            foreach (Mueble mueble in Fabrica.Muebles)//Siempre testeo los datos de la fabrica ya que otros datos no se van a cargar en ningún lado
            {                 
                //ASSERT
                Assert.IsNotNull(mueble);
            }
        }

        /// <summary>
        /// Testea que ninguna propiedad de la lista retorne como valor un cero, ya que el programa no lo permite
        /// </summary>
        [TestMethod]
        public void ValoresIncoherentes()
        {
            bool resultado;
            //ARRANGE
            foreach (Mueble mueble in Fabrica.Muebles)//Siempre testeo los datos de la fabrica ya que otros datos no se van a cargar en ningún lado
            {
                //ACT 
                resultado = !(mueble.PrecioMateriaPrima.Equals(0) || (float)mueble == 0 || mueble.CostesDeProducción.Equals(0) || mueble.PrecioMueble.Equals(0));
                //ASSERT
                Assert.IsTrue(resultado);
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
            Madera madera1 = new Madera("Silla", 2, 8, 22, 33, 12, eColor.Rojo, eTipoDeMadera.Roble);
            Madera madera2 = new Madera("Silla", 2, 8, 22, 33, 12, eColor.Rojo, eTipoDeMadera.Roble);
            Metal metal1 = new Metal("Mesa", 4, 9, 20, 37, 12, eColor.Rojo, eTipoDeMetal.Acero);
            Metal metal2 = new Metal("Mesa", 9, 9, 20, 37, 12, eColor.Rojo, eTipoDeMetal.Acero);
            Vidrio vidrio1 = new Vidrio("Mesa", 11, 3, 25, 31, 11);
            Vidrio vidrio2 = new Vidrio("Mesa", 5, 3, 25, 31, 11);
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
            Madera madera = new Madera("Silla", 2, 8, 22, 33, 12, eColor.Rojo, eTipoDeMadera.Roble);
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
