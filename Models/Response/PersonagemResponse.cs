namespace thirdApi.Models.Response
{
    public class PersonagemResponse
    {
        public int ID { get; set; }
        public string Personagem { get; set; }
        public int Filme { get; set; }
        public int Ator { get; set; }

        public PersonagemResponse(int id, string nome, int filme, int ator)
        {
            this.ID = id;
            this.Personagem = nome;
            this.Filme = filme;
            this.Ator = ator;
        } 
    }
}