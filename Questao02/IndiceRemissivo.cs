using System;
using System.IO;
using System.Linq;

namespace Questao02
{
    public class IndiceRemissivo
    {
        public string pathTXT { get; set; }
        public string pathIgnore { get; set; }
        public ConteudoArquivo conteudoPathTXT { get; set; } = new ConteudoArquivo();
        public ConteudoArquivo conteudoPathIgnore { get; set; } = new ConteudoArquivo();

        public IndiceRemissivo(string pathTXT, string pathIgnore = "")
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
                conteudoPathTXT.Imprime(conteudoPathIgnore);
            }
            else
            {
                conteudoPathTXT.Imprime();
            }
        }
    }
}
