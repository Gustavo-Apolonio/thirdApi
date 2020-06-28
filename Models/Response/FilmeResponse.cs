using System;

namespace thirdApi.Models.Response
{
    public class FilmeResponse
    {
        public int? ID { get; set; }
        public string Filme { get; set; }
        public string Genero { get; set; }
        public int? Duracao { get; set; }
        public decimal? Avaliacao { get; set; }
        public bool Disponivel { get; set; }
        public DateTime Lancamento { get; set; }

        public FilmeResponse(int? id, string filme, string genero,
                            int? duracao, decimal? avaliacao,
                            bool disponivel, DateTime lancamento)
        {
            this.ID = id;
            this.Filme = filme;
            this.Genero = genero;
            this.Duracao = duracao;
            this.Avaliacao = avaliacao;
            this.Disponivel = disponivel;
            this.Lancamento = lancamento;
        }
    }
}