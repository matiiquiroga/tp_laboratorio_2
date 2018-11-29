using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public class Alumno : Universitario
    {
        Universidad.EClases _claseQueToma;
        EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #region CONSTRUCTORES

        public Alumno() 
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.AlDia)
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region METODOS
        
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(base.MostrarDatos());
            datos.AppendFormat("ESTADO DE CUENTA: {0}\r\n", this._estadoCuenta.ToString());
            datos.AppendLine(this.ParticiparEnClase());

            return datos.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "\nTOMA CLASES DE: " + this._claseQueToma;
        }

        #endregion

        #region OPERADORES

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (!(a._claseQueToma == clase))
            {
                retorno = true;
            }

            return retorno;

        }

        #endregion
    }
}
