using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero) : this(numero + "")
        {

        }

        public Operando(string strNumero)
        {
            Numero(strNumero);
        }

        private double ValidarOperando(string strNumero)
        {
            return double.Parse(strNumero);
        }

        private String Numero(string strNumero)
        {
            this.numero = ValidarOperando(strNumero);
            return numero.ToString();
        }

        private static bool EsBinario(string binario)
        {
            bool opcion = false;
            for(int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    return false;
                }
                else
                {
                    opcion = true;
                }
            }
            return opcion;
        }
        public static string BinarioDecimal(string binario)
        {
            string numeroDecimal = "";
            double potenciaDeDos = 0;
            for (int i = 1; i <= binario.Length; i++)
            {
                if (Operando.EsBinario(binario) == true)
                {
                    potenciaDeDos += double.Parse(binario[i - 1].ToString()) * (Math.Pow(2, binario.Length - i));
                }

            }
            numeroDecimal += potenciaDeDos;

            return numeroDecimal;
        }

        public static string DecimalBinario(double numero)
        {
            string numeroBin = "";
            while ((int)numero > 0)
            {
                numeroBin = ((int)numero % 2).ToString() + numeroBin;
                numero = numero / 2;
            }
            return numeroBin;
        }

        public static string DecimalBinario(string numero)
        {
            double numeroDecimal;
            for (int i = 0; i < numero.Length; i++)
            {
                if (numero[i] < '0' || numero[i] > '9')
                {
                    return "Valor invalida";
                }
            }
            return double.TryParse(numero, out numeroDecimal) ? DecimalBinario(numeroDecimal) : "Valor invalido";

        }      
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if(n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }
    }
}
