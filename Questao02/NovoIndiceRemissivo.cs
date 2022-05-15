using System;
using System.IO;
using System.Linq;

namespace Questao02
{
    public class NovoIndiceRemissivo
    {
        public string pathTXT { get; set; }
        public string pathIgnore { get; set; }
        public ConteudoArquivo conteudoPathTXT { get; set; } = new ConteudoArquivo();
        public ConteudoArquivo conteudoPathIgnore { get; set; } = new ConteudoArquivo();

        public NovoIndiceRemissivo(string pathTXT, string pathIgnore = "")
        {
            if (!File.Exists(pathTXT))
            {
                throw new ArgumentException("Caminho para o arquivo inválido ou arquivo não existe.");
            }

            if (pathIgnore != "" && File.Exists(pathIgnore))
            {
                this.pathIgnore = pathIgnore;
                CarregaConteudo(pathIgnore, conteudoPathIgnore);
            }
            this.pathTXT = pathTXT;
            CarregaConteudo(pathTXT, conteudoPathTXT);
        }


        public void CarregaConteudo(string path, ConteudoArquivo conteudo)
        {
            string[] texto = File.ReadAllLines(path);
            char[] caracteres = { ' ', '.', ',', ';', '<', '>', ':', '\\', '/', '|', '~', '^', '`', '`', '[', ']', '{', '}', '‘', '“', '!', '@', '#', '$', '%', '&', '*', '(', ')', '_', '+', '=' };
            string[] palavrasDaLinha;
            for (int indiceLinha = 0; indiceLinha < texto.Length; indiceLinha++)
            {
                palavrasDaLinha = texto[indiceLinha].Split(caracteres, StringSplitOptions.RemoveEmptyEntries);
                foreach (var palavra in palavrasDaLinha)
                {
                    Palavra novaPalavra = new(palavra, indiceLinha);
                    conteudo.Adiciona(novaPalavra, indiceLinha);
                }
            }
        }

        public void Imprime()
        {
            if (pathIgnore != "")
            {
                var palavrasFiltradas = conteudoPathTXT.ListaPalavras.Where(p => !conteudoPathIgnore.ListaPalavras
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
            else
            {
                conteudoPathTXT.Imprime();
            }
        }
    }
}
