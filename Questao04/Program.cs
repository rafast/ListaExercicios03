using System;
using System.Collections.Generic;

namespace Questao04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Questao 04");
            List<int> listaInteiros = new();
            listaInteiros.Add(1);
            listaInteiros.Add(2);
            listaInteiros.Add(2);
            listaInteiros.Add(4);
            listaInteiros.Add(4);
            listaInteiros.Add(5);
            foreach (var item in listaInteiros.RemoveRepetidos())
            {
                Console.WriteLine(item);
            }

            List<string> nomes = new();
            nomes.Add("Rafael");
            nomes.Add("Rafael");
            nomes.Add("Nick");
            nomes.Add("Rafael");
            foreach (var nome in nomes.RemoveRepetidos())
            {
                Console.WriteLine(nome);
            }

            List<Cliente> clientes = new();
            Cliente fernanda = new ("32154323434", "Cora Coralina");
            Cliente maria = new ("32154323434", "Joanna de Angelis");
            Cliente chico = new ("32112332112", "Chico Xavier");
            Cliente andre = new ("32154323434", "Andre Luiz");
            Cliente emmanuel = new ("32112332123", "Emmanuel");
            clientes.Add(fernanda);
            clientes.Add(maria);
            clientes.Add(chico);
            clientes.Add(andre);
            clientes.Add(emmanuel);
            foreach (var cliente in clientes.RemoveRepetidos())
            {
                Console.WriteLine($"{cliente.Cpf} - {cliente.Nome}");
            }


        }
    }
}
