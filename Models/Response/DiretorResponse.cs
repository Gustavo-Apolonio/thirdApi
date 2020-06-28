using System;

namespace thirdApi.Models.Response
{
    public class DiretorResponse
    {
        public int? ID { get; set; }
        public string Diretor { get; set; }
        public DateTime Nascimento { get; set; }
        public int? Filme { get; set; }

        public DiretorResponse(int? id, string nome, DateTime nascimento, int? filme)
        {
            this.ID = id;
            this.Diretor = nome;
            this.Nascimento = nascimento;
            this.Filme = filme;
        }
    }
}