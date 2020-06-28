using System;

namespace thirdApi.Models.Response
{
    public class AtorResponse
    {
        public int ID { get; set; }
        public string Ator { get; set; }
        public decimal Altura { get; set;}
        public DateTime Nascimento { get; set; }

        public AtorResponse(int id, string nome, decimal altura, DateTime nascimento)
        {
            this.ID = id;
            this.Ator = nome;
            this.Altura = altura;
            this.Nascimento = nascimento;
        }
    }
}