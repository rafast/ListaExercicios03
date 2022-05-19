using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Questao01
{
    public class ClienteJSON
    {
        [JsonProperty("dados")]
        public Cliente cliente { get; set; } = new();

        [JsonProperty("erros")]
        public List<Erro> Erros { get; set; } = new();

        
        Dictionary<string, string> validacaoCampos { get; set; } = new();


        public ClienteJSON()
        {
        }

        public ClienteJSON(Cliente c)
        {
            cliente = c;
        }

        public void Validacao()
        {
            validacaoCampos = new Dictionary<string, string>();
            validacaoCampos.Add("Nome", validaNome(cliente.Nome));
            validacaoCampos.Add("Cpf", validaCPF(cliente.Cpf));
            DateTime dt;
            validacaoCampos.Add("Dt_nascimento", validaData(out dt, cliente.Dt_nascimento));
            float renda;
            validacaoCampos.Add("Renda_mensal", validaRenda(out renda, cliente.Renda_mensal));
            validacaoCampos.Add("Estado_civil", validaEstadoCivil(cliente.Estado_civil));
            validacaoCampos.Add("Dependentes", validaDependentes(cliente.Dependentes));
            validacaoCampos.Add("Erros", "Valido");
            validacaoCampos.Add("validacaoCampos", "Valido");

            foreach (var campo in validacaoCampos.Where(campo => campo.Value != "Valido"))
            {
                Erro erro = new Erro();
                erro.Campo = campo.Key;
                erro.Mensagem = campo.Value;
                Erros.Add(erro);
            }
        }

        private string validaNome(string nome)
        {
            string padrao = "^([a-zA-Z ]*?)\\s*([a-zA-Z]*)$";
            bool ehValido = Regex.IsMatch(nome, padrao) && (nome.Length > 4);
            return ehValido ? "Valido" : "O nome deve ter pelo menos 5 caracteres.";
        }

        private string validaCPF(string cpf)
        {
            bool ehValido = validadorCPF(cpf);
            return ehValido ? "Valido" : "CPF inválido.";
        }

        private string validaData(out DateTime data, string inputData)
        {
            bool ehValido = DateTime.TryParseExact(inputData,
                                         "dd/MM/yyyy",
                                         CultureInfo.InvariantCulture,
                                         DateTimeStyles.None,
                                         out data) && maiorIdade(data);
            return ehValido ? "Valido" : "A data deve estar no formato DD/MM/AAAA. E o cliente deve ter mais de 18 anos.";
        }

        private bool maiorIdade(DateTime data_nascimento)
        {
            var hoje = DateTime.Today;
            return (hoje.Year - data_nascimento.Year >= 18);
        }

        private string validaRenda(out float renda, string inputRendaMensal)
        {
            var culture = CultureInfo.GetCultureInfo("fr-FR");
            bool ehValido = (float.TryParse(inputRendaMensal, NumberStyles.Currency, culture, out renda)) && renda >= 0;
            return ehValido ? "Valido" : "A renda mensal deve ser um valor maior ou igual a zero e possuir vírgula decimal e duas casas decimais.";
        }

        private string validaEstadoCivil(string estado_civil)
        {
            bool ehValido = (estado_civil.ToUpper() == "C" ||
                estado_civil.ToUpper() == "S" ||
                estado_civil.ToUpper() == "V" ||
                estado_civil.ToUpper() == "D");
            return ehValido ? "Valido" : "Para o estado civil utilize: C, S, V ou D (maiúsculo ou minúsculo).";
        }

        private string validaDependentes(string dependentes)
        {
            int dependente;
            bool ehValido = (Int32.TryParse(dependentes, out dependente) &&
                                            (dependente >= 0 && dependente <= 10));
            return ehValido ? "Valido" : "O número de dependentes deve estar entre 0 e 10.";
        }

        //public void ImprimeErros()
        //{
        //    Console.WriteLine("O(s) campo(s) abaixo está(ão) inválido(s).");
        //    if (!TodosValidos())
        //    {
        //        foreach (var campo in validacaoCampos.Where(campo => campo.Value != "Valido"))
        //        {
        //            Console.WriteLine($"{campo.Key} - {campo.Value}");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        public bool TodosValidos()
        {
            var possuiInvalido = validacaoCampos.Where(campo => campo.Value != "Valido").Any();
            return !possuiInvalido;
        }

        public bool validadorCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            string dgsVerificadores;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if ((cpf == "00000000000") ||
                (cpf == "11111111111") ||
                (cpf == "22222222222") ||
                (cpf == "33333333333") ||
                (cpf == "44444444444") ||
                (cpf == "55555555555") ||
                (cpf == "66666666666") ||
                (cpf == "77777777777") ||
                (cpf == "88888888888") ||
                (cpf == "99999999999"))
            {
                return false;
            }
            if (cpf.Length != 11)

                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();
            dgsVerificadores = digito;
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();
            dgsVerificadores += digito;

            if ((dgsVerificadores) == cpf.Remove(0, 9))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
