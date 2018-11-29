using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public class Profesor : Universitario
    {
         Queue<Universidad.EClases> _clasesDelDia;
         static Random _random;

        #region CONSTRUCTORES

        public Profesor()
        {
        }

        static Profesor()
        {
            Profesor._random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this.RandomClases();
        }

        #endregion

        #region METODOS

        private void RandomClases()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 4));
            this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 4));
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Universidad.EClases item in _clasesDelDia)
            {
                sb.AppendLine("\nCLASES DEL DÍA:" + item.ToString());
            }

            return sb.ToString();
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        #endregion

        #region OPERADORES

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }

        #endregion

    }
}
