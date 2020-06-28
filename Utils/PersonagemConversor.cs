namespace thirdApi.Utils
{
    public class PersonagemConversor
    {
        public Models.TbFilmeAtor ToTableConversor(Models.Request.PersonagemRequest req)
        {
            Models.TbFilmeAtor personagem = new Models.TbFilmeAtor();
            personagem.NmPersonagem = req.Personagem;
            personagem.IdFilme = req.Filme;
            personagem.IdAtor = req.Ator;

            return personagem;
        }
        public Models.Response.PersonagemResponse ToResponseConversor(Models.TbFilmeAtor personagem)
        {
            Models.Response.PersonagemResponse response= new Models.Response.PersonagemResponse(
                personagem.IdFilmeAtor, personagem.NmPersonagem,
                personagem.IdFilme, personagem.IdAtor
            );

            return response;
        }
    }
}