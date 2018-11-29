using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador ingresado por el usuario.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns> retornara el operador seleccionado. Caso de error/null(cboBox) retornara +.
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if (operador == string.Empty)
            {
                return retorno;
            }
            else
            {
                switch (operador)
                {
                    case "+":
                        retorno = "+";
                        break;
                    case "-":
                        retorno = "-";
                        break;
                    case "*":
                        retorno = "*";
                        break;
                    case "/":
                        retorno = "/";
                        break;
                    default:
                        retorno = "+";
                        break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Realiza las operaciones sobrecargadas sobre los objetos de la clase Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns> El resultado de la operacion.
        public static  double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            string operadorValido = ValidarOperador(operador);

            switch (operadorValido)
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    if ( num2.getNumero() != 0)
                    {
                        retorno = num1 / num2;
                    }
                    else
                        retorno = 0;
                    break;
            }

            return retorno;
        }

    }
}
