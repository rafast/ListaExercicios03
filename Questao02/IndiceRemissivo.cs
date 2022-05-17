using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Questao02
{
    public class IndiceRemissivo
    {
        public string pathTXT { get; set; }
        public string pathIgnore { get; set; }
        public Dictionary<string, List<int>> frequenciaPalavras = new Dictionary<string, List<int>>();
        public string[] palavrasIgnoreList = Array.Empty<string>();

        public IndiceRemissivo(string pathTXT, string pathIgnore = "")
        {
            if (!File.Exists(pathTXT))
            {
                throw new ArgumentException("Caminho para o arquivo inválido ou arquivo não existe.");
            }

            if (pathIgnore != "" && File.Exists(pathIgnore))
            {
                this.pathIgnore = pathIgnore;
                CarregarIgnoreList();
            }
            this.pathTXT = pathTXT;
            ContagemPalavras();
        }

        public void ContagemPalavras()
        {
            string[] texto = File.ReadAllLines(pathTXT);
            char[] caracteres = {' ', '.', ',', ';', '<', '>', ':', '\\', '/', '|', '~', '^', '`', '`', '[', ']', '{', '}', '‘', '“', '!', '@', '#', '$', '%', '&', '*', '(', ')', '_', '+', '=' };
            string[] palavrasDaLinha;
            for (int indiceLinha = 0; indiceLinha < texto.Length; indiceLinha++)
            {
                palavrasDaLinha = texto[indiceLinha].Split(caracteres, StringSplitOptions.RemoveEmptyEntries);
                foreach (var palavra in palavrasDaLinha)
                {
                    if (!frequenciaPalavras.ContainsKey(palavra.ToUpper()))
                    {
                        frequenciaPalavras.Add(palavra.ToUpper(), new List<int>() { indiceLinha });
                    }
                    else
                    {
                        frequenciaPalavras[palavra.ToUpper()].Add(indiceLinha);
                    }
                }
            }
        }

        public void Imprime()
        {
            if (palavrasIgnoreList.Length > 0)
            {
                AplicarIgnoreList();
            }
            foreach (var palavra in frequenciaPalavras.OrderBy(p => p.Key))
            {
                if (palavrasIgnoreList.Contains(palavra.Key.ToLower()))
                {
                    Console.WriteLine("PALAVRA CONTIDA NO IGNORE LIST!!");
                }
                Console.Write($"{palavra.Key} ({palavra.Value.Count}) ");
                foreach (var linha in palavra.Value.Distinct())
                {
                    Console.Write($"{linha+1}, ");
                }
                Console.WriteLine();
            }
        }

        public void CarregarIgnoreList()
        {
            string texto = File.ReadAllText(pathIgnore);
            char[] caracteres = { ' ', '.', ',', ';', '<', '>', ':', '\\', '/', '|', '~', '^', '`', '`', '[', ']', '{', '}', '‘', '“', '!', '@', '#', '$', '%', '&', '*', '(', ')', '_', '+', '=' };
            palavrasIgnoreList = texto.Split(caracteres, StringSplitOptions.RemoveEmptyEntries);
        }

        public void AplicarIgnoreList()
        {
            
        }
    }
}
