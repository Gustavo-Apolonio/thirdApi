using System;

namespace thirdApi.Models.Request
{
    public class AtorRequest
    {
        public string Ator { get; set; }
        public decimal Altura { get; set;}
        public DateTime Nascimento { get; set; }

        public AtorRequest(string nome, decimal altura, DateTime nascimento)
        {
            this.Ator = nome;
            this.Altura = altura;
            this.Nascimento = nascimento;
        }
    }
}