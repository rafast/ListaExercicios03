using System;
using System.Collections.Generic;

namespace Questao02
{
    public class Palavra
    {
        public string Nome { get; set; }
        public List<int> IndicesLinha { get; set; }

        public Palavra(string nome, int primeiroIndice)
        {
            Nome = nome.ToUpper();
            IndicesLinha = new List<int>() { primeiroIndice };
        }

        public void AddIndice(int i)
        {
            IndicesLinha.Add(i);
        }
    }
}
