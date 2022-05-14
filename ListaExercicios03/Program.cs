using System;

namespace Questao03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testando a Questao 03");
            Console.WriteLine("Imprimindo todos os números de Armstrong no intervalo de 1 a 10.000");
            for (int i = 1; i <= 10000; i++)
            {
                if (i.IsArmstrong())
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}
