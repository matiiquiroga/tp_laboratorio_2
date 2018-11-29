using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace ClasesAbstractas
{
    public abstract class Persona
    {
        string _nombre;
        string _apellido;
        int _dni;
        ENacionalidad _nacionalidad;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region PROPIEDADES

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDni(this._nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                this._dni= this.ValidarDni(this._nacionalidad, value);
            }
        }

        #endregion

        #region CONSTRUCTORES

        public Persona()
        {
            
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region METODOS

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", \n" + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino && (dato > 89999999 || dato < 1)) || (nacionalidad == ENacionalidad.Extranjero && (dato > 99999999 || dato < 90000000)))
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
            }

            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (dato.Length > 0 && dato.Length < 9 && int.TryParse(dato, out _dni))
            {
                _dni = this.ValidarDni(nacionalidad, _dni);
            }
            else
            {
                throw new DniInvalidoException("El DNI posee un error de formato.");
            }
            return _dni;
        }

        private string ValidarNombreApellido(string dato)
        {
            if (object.Equals(dato, null))
            {
                dato = " ";
            }
            else
            {
                for (int i = 0; i < dato.Length; i++)
                {
                    if (!char.IsLetter(dato[i]))
                    {
                        dato = " ";
                    }
                }
            }

            return dato;
        }
        #endregion
    }
}