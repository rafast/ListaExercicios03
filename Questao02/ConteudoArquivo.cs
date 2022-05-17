using System;
using System.Collections.Generic;
using System.Linq;

namespace Questao02
{
    public class ConteudoArquivo
    {
        public List<Palavra> ListaPalavras { get; set; }

        public ConteudoArquivo()
        {
            ListaPalavras = new List<Palavra>();
        }

        public void Adiciona(Palavra palavra, int indice)
        {
            var palavraOuDefault = ListaPalavras.Where(p => p.Nome == palavra.Nome).SingleOrDefault();

            if (palavraOuDefault == null)
            {
                ListaPalavras.Add(palavra);
            }
            else
            {
                palavraOuDefault.AddIndice(indice);
            }
        }

        public void Imprime()
        {
            foreach (var palavra in ListaPalavras.OrderBy(p => p.Nome))
            {
                Console.Write($"{palavra.Nome} ({palavra.IndicesLinha.Count()}) ");
                foreach (var linha in palavra.IndicesLinha.Distinct())
                {
                    Console.Write($"{linha + 1}, ");
                }
                Console.WriteLine();
            }
        }

        public void Imprime(ConteudoArquivo ignoreList)
        {
            var palavrasFiltradas = ListaPalavras.Where(p => !ignoreList.ListaPalavras
                                                                     .Any(x => x.Nome == p.Nome))
                                                                     .OrderBy(z => z.Nome)
                                                                     .ToList();


            foreach (var palavra in palavrasFiltradas)
            {
                Console.Write($"{palavra.Nome} ({palavra.IndicesLinha.Count()}) ");
                foreach (var linha in palavra.IndicesLinha.Distinct())
                {
                    Console.Write($"{linha + 1}, ");
                }
                Console.WriteLine();
            }
        }

    }
}
