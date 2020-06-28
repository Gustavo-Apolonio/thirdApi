using System;

namespace thirdApi.Models.Request
{
    public class DiretorRequest
    {
       public string Diretor { get; set; }
       public DateTime Nascimento { get; set; }
       public int Filme { get; set; }

       public DiretorRequest(string nome, DateTime nascimento, int filme)
       {
           this.Diretor = nome;
           this.Nascimento = nascimento;
           this.Filme = filme;
       }
    }
}