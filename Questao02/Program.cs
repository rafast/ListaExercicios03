using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Questao02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testando a Questao 02");
            IndiceRemissivo indiceRemissivo = new("/Users/rafael/Projects/ListaExercicios03/Questao02/texto.txt", "/Users/rafael/Projects/ListaExercicios03/Questao02/ignore.txt");
            //IndiceRemissivo indiceRemissivo = new("/Users/rafael/Projects/ListaExercicios03/Questao02/texto.txt");
            indiceRemissivo.Imprime();
        }
    }
}
