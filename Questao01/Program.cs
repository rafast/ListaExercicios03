using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Questao01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testando a Questao01!");

            string jsonString = File.ReadAllText("/Users/rafael/Projects/ListaExercicios03/Questao01/clientes.json");


            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonString);
            List<ClienteJSON> listaFinal = new();            

            foreach (var cliente in clientes)
            {
                var clienteJson = new ClienteJSON(cliente);
                clienteJson.Validacao();
                if (!clienteJson.TodosValidos())
                {
                    listaFinal.Add(clienteJson);
                }
            }

            var errosValidacao = JsonConvert.SerializeObject(listaFinal, Formatting.Indented);
            File.WriteAllText("/Users/rafael/Projects/ListaExercicios03/Questao01/errosValidacao.json", errosValidacao);



        }
    }
}
