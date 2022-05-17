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

            string jsonString = File.ReadAllText("/Users/rafast/Projects/ListaExercicios03/Questao01/clientes.json");
            //Console.WriteLine(jsonString);



            ClientesFromJSON clientes = new ClientesFromJSON();
            clientes.clientesJson = JsonConvert.DeserializeObject<List<ClientesFromString>>(jsonString);

            foreach (var cliente in clientes.clientesJson)
            {
                cliente.Validacao();
                Console.WriteLine(cliente.Nome);
                cliente.ImprimeErros();
                //Console.WriteLine(cliente.Nome);
                //Console.WriteLine(cliente.Cpf);
                //Console.WriteLine(cliente.Dt_nascimento);
                //Console.WriteLine(cliente.Renda_mensal);
                //Console.WriteLine(cliente.Estado_civil);
                //Console.WriteLine(cliente.Dependentes);
               
            }

        }
    }
}
