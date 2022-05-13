using System;
namespace Questao04
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }

        public Cliente(string cpf, string nome)
        {
            Cpf = cpf;
            Nome = nome;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(!(obj is Cliente))
            {
                return false;
            }
            return Cpf.Equals(((Cliente)obj).Cpf);
        }

        public override int GetHashCode()
        {
            return Cpf.GetHashCode();
        }
    }
}
