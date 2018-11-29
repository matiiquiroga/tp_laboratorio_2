using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;

namespace TestUnitario
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestNull()
        {
            Profesor profesor = new Profesor(111, "Jonatan", "Fernandez", null, Persona.ENacionalidad.Argentino);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidad()
        {
            Alumno uno = new Alumno(222, "Alan", "Martinez", "3767464", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
        }

        [TestMethod]
        public void TestValorNumerico()
        {
            Alumno alumno = new Alumno(333, "Octavio", "Vargas", "1233213", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);

            Assert.IsInstanceOfType(alumno.DNI, typeof(int));
        }
    }
}
