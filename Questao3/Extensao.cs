using System;
namespace Questao3
{
    public static class Extensao
    {
        public static bool IsArmstrong(this int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Argumento inválido. N deve ser um número inteiro positivo.");
            }
            int inteiroEntrada, ultimoDigito = 0, soma = 0, digitos = QuantidadeDigitos(n);
            inteiroEntrada = n;

            while (n > 0)
            {
                ultimoDigito = n % 10;
                soma += (int)Math.Pow(ultimoDigito, digitos);
                n /= 10;
            }

            return (soma == inteiroEntrada);
        }

        private static int QuantidadeDigitos(int n)
        {
            int digitos = 0;
            while (n > 0)
            {
                n /= 10;
                digitos++;
            }
            return digitos;
        }
    }
}
