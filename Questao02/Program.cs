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
            NovoIndiceRemissivo indiceRemissivo = new("/Users/rafael/Projects/ListaExercicios03/Questao02/texto.txt", "/Users/rafael/Projects/ListaExercicios03/Questao02/ignore.txt");
            indiceRemissivo.Imprime();
            //IndiceRemissivo indice = new IndiceRemissivo("/Users/rafael/Projects/ListaExercicios03/Questao02/texto.txt", "/Users/rafael/Projects/ListaExercicios03/Questao02/ignore.txt");
            //indice.Imprime();
            //char[] caracteres = { ' ', '.', ',', ';', '<', '>', ':', '\\', '/', '|', '~', '^', '`', '`', '[', ']', '{', '}', '‘', '“', '!', '@', '#', '$', '%', '&', '*', '(', ')', '_', '+', '=' };
            //string[] texto = System.IO.File.ReadAllLines("/Users/rafael/Projects/ListaExercicios03/Questao02/texto.txt");

            //Dictionary<string, List<int>> palavrasIndiceLinha = new Dictionary<string, List<int>>();
            //string[] palavrasDaLinha;

            //for (int indiceLinha = 0; indiceLinha < texto.Count(); indiceLinha++)
            //{
            //    palavrasDaLinha = texto[indiceLinha].Split(caracteres);
            //    foreach (var palavra in palavrasDaLinha)
            //    {
            //        if (!palavrasIndiceLinha.ContainsKey(palavra))
            //        {
            //            palavrasIndiceLinha.Add(palavra, new List<int>() { indiceLinha });
            //        }
            //        else
            //        {
            //            palavrasIndiceLinha[palavra].Add(indiceLinha);
            //        }
            //    }
            //}

            //foreach (var palavra in palavrasIndiceLinha)
            //{
            //    Console.Write($"{palavra.Key.ToUpper()} ({palavra.Value.Count}) apareceu nas linhas: ");
            //    foreach (var linha in palavra.Value)
            //    {
            //        Console.Write($"{linha} - ");
            //    }
            //    Console.WriteLine();
            //}
            //foreach (var item in palavrasIndiceLinha["mais"].ToArray())
            //{
            //    Console.WriteLine(item);
            //}

            //var dicionario = GetWordFrequency("/Users/rafael/Projects/ListaExercicios03/Questao02/texto.txt");
            //foreach (var item in dicionario.OrderBy(x => x.Key))
            //{
            //    Console.WriteLine($"Palavra: {item.Key.ToUpper()} aparece {item.Value} vezes");
            //}
        }

        private static Dictionary<string, int> GetWordFrequency(string file)
        {
            char[] caracteres = { ' ', '.', ',', ';', '<', '>', ':', '\\', '/', '|', '~', '^', '`', '`', '[', ']', '{', '}', '‘', '“', '!', '@', '#', '$', '%', '&', '*', '(', ')', '_', '+', '=' };
            return File.ReadLines(file)
                       .SelectMany(x => x.Split(caracteres))
                       .Where(x => x != string.Empty)
                       .GroupBy(x => x)
                       .ToDictionary(x => x.Key, x => x.Count());
        }        
    }
}
