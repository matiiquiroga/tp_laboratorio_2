using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        #region CONSTRUCTORES

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion

        #region METODOS

        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {

            return base.ToString() + "\n\nLEGAJO NUMERO:" + this._legajo.ToString();
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj is Universitario)
            {
                retorno = true;
            }

            return retorno;
        }

        #endregion

        #region OPERADORES

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (pg1 is Universitario && pg2 is Universitario)
            {
                if (pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        #endregion
    }
}
