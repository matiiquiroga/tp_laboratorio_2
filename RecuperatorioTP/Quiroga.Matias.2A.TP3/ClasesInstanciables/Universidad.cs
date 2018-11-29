using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        List<Alumno> _alumnos;
        List<Jornada> _jornada;
        List<Profesor> _profesores;

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

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

        public List<Jornada> Jornadas
        {
            get
            {
                return this._jornada;
            }
            set
            {
                this._jornada = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this._profesores;
            }
            set
            {
                this._profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this._jornada[i];
            }
            set
            {
                this._jornada[i] = value;
            }
        }

        #endregion

        #region CONSTRUCTORES

        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
        }

        #endregion

        #region METODOS

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");

            for (int i = 0; i < uni._jornada.Count; i++)
            {
                sb.AppendLine(uni._jornada[i].ToString());
                sb.AppendLine("<------------------------------------->");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region OPERADORES

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = new Profesor();

            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    retorno = item;
                    break;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }

            return retorno;
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = new Profesor();

            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    retorno = profesor;
                    break;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }

            return retorno;
        }

        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == clase)
                {
                    Jornada jornada = new Jornada(clase, profesor);

                    foreach (Alumno item in g.Alumnos)
                    {
                        if (item == clase)
                        {
                            jornada.Alumnos.Add(item);
                        }
                    }

                    g.Jornadas.Add(jornada);
                    return g;
                }
            }

            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u._profesores.Add(i);
            }

            return u;
        }

        public static bool Guardar(Universidad gim)
        {
            XML<Universidad> file = new XML<Universidad>();

            return file.Guardar("Universidad.xml", gim);
        }

        #endregion

    }
}