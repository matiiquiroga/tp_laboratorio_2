using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LstPaquetesInstanciada()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        public void TrackingIdRepetido()
        {
            Paquete p1 = new Paquete("repeating110", "011");
            Paquete p2 = new Paquete("repeating110", "011");
            Correo c = new Correo();
            c += p1;
            try
            {
                c += p2;
                Assert.Fail();
            }
            catch (TrackingIdRepetidoException)
            {
            }
        }
    }
}
