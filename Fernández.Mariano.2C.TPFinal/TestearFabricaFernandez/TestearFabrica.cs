using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestearFabricaFernandez
{
    [TestClass]
    public class TestearFabrica
    {
        /// <summary>
        /// Testea que el gasto total no sea cero si se agrego al menos un elemento
        /// </summary>
        [TestMethod]
        public void TestearGastoTotal()
        {
            //ARRANGE
            bool resultado=true;

            //ACT
            if (Fabrica.Muebles.Count > 0 && Fabrica.CalcularGastoFabrica() == 0)
            {
                resultado = false;
            }

            //ASSERT
            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Testea que no devuelva cadena vacia a la info si es que hay al menos un elemento
        /// </summary>
        [TestMethod]
        public void TestearInfo()
        {
            //ARRANGE
            bool resultado = true;

            //ACT
            if (Fabrica.Muebles.Count > 0 && Fabrica.RetornarInformacion() == string.Empty)
            {
                resultado = false;
            }

            //ASSERT
            Assert.IsTrue(resultado);
        }
    }
}
