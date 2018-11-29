using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;


namespace ClasesInstanciables
{
    public class Jornada
    {
         List<Alumno> _alumnos;
         Universidad.EClases _clase;
         Profesor _instructor;

        #region PROPIEDADES

        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
            set
            {
                this._alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this._instructor;
            }
            set
            {
                this._instructor = value;
            }
        }

        #endregion

        #region CONSTRUCTORES

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region METODOS

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());
            sb.AppendLine("\nAlumnos: \n");

            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("\n---------------------------------\n");

            return sb.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto text = new Texto();

            if (text.Guardar("Jornada.txt", jornada.ToString()))
            {
                retorno = true;
            }

            return retorno;
        }

        public static string Leer()
        {
            string dato = "";
            Texto text = new Texto();

            text.Leer("Jornada.txt", out dato);

            return dato;
        }

        #endregion

        #region OPERADORES

        public static bool operator ==(Jornada jornada, Alumno alu)
        {
            bool retorno = false;

            foreach (Alumno item in jornada._alumnos)
            {
                if (item == alu)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Jornada jornada, Alumno alu)
        {
            return !(jornada == alu);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
            }
            return j;
        }

        #endregion
    }
}
