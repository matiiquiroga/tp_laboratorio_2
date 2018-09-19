using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double _numero;

        /// <summary>
        /// Valida que el string que se pasa como parametro sea un numero.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns> El numero validado. Caso contrario retornara 0.
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            bool validar = double.TryParse(strNumero, out retorno);

            if (validar)
                return retorno;

            return retorno = 0;
        }

        //Propiedades     
        public double getNumero()
        {
            return this._numero;
        }

        public string MyNumero
        {
            set
            {
                this._numero = ValidarNumero(value);
            }
        }

        /// Constructores 
        public Numero()
        {
            this._numero = 0;
        }
        public Numero(double numero)
        {
            this._numero = numero;
        }
        public Numero(string strNumero)
        {
            this.MyNumero = strNumero;
        }

        ///Operadores
        public static double operator +(Numero num1, Numero num2)
        {
            double resp = num1.getNumero() + num2.getNumero();
            return resp;
        }

        public static double operator -(Numero num1, Numero num2)
        {
            double resp = num1.getNumero() - num2.getNumero();
            return resp;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            double resp = num1.getNumero() * num2.getNumero();
            return resp;
        }

        public static double operator /(Numero num1, Numero num2)
        {
            double resp = num1.getNumero() / num2.getNumero();
            return resp;
        }

        public string BinarioDecimal(string binario)
        {
            int i;
            int entero = 0;
            string Retorno = "";

            foreach (char item in binario)
                if (item != '0' && item != '1')
                    return "No se ingreso un numero binario";

            if (binario == "" || ReferenceEquals(binario, null))
            {
              Retorno = "Debes ingresar un valor valido";
            }      
            else
            {
                for (i = 1; i < binario.Length; i++)
                {
                    entero += int.Parse(binario[i - 1].ToString()) * (int)Math.Pow(2, binario.Length - i);
                }
                Retorno = entero.ToString();
            }

            return Retorno;
        }

        public string DecimalBinario(string binario)
        {
            int numero;
            string Retorno = "";

            if (int.TryParse(binario, out numero))
            {
                while (numero > 0)
                {
                    Retorno = (numero % 2).ToString() + Retorno;
                    numero = numero / 2;
                }
            }
            else
                Retorno = "Valor inválido";

            return Retorno;
        }

        public string DecimalBinario(double binario)
        {
            return DecimalBinario(binario.ToString());
        }
    }
}
