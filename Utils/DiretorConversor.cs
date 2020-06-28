namespace thirdApi.Utils
{
    public class DiretorConversor
    {
        public Models.TbDiretor ToTableConversor(Models.Request.DiretorRequest req)
        {
            Models.TbDiretor diretor = new Models.TbDiretor();
            diretor.NmDiretor = req.Diretor;
            diretor.DtNascimento = req.Nascimento;
            diretor.IdFilme = req.Filme;

            return diretor;
        }

        public Models.Response.DiretorResponse ToResponseConversor(Models.TbDiretor diretor)
        {
            Models.Response.DiretorResponse resp = new Models.Response.DiretorResponse(
                diretor.IdDiretor, diretor.NmDiretor, diretor.DtNascimento, diretor.IdFilme
            );

            return resp;
        }
    }
}