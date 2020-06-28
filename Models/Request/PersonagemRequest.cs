using System;

namespace thirdApi.Models.Request
{
    public class PersonagemRequest
    {
        public string Personagem { get; set; }
        public int Filme { get; set; }
        public int Ator { get; set; }

        public PersonagemRequest(string nome, int filme, int ator)
        {
            this.Personagem = nome;
            this.Filme = filme;
            this.Ator = ator;
        } 
    }
}