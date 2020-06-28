namespace thirdApi.Utils
{
    public class AtorConversor
    {
        public Models.TbAtor ToTableConversor(Models.Request.AtorRequest req)
        {
            Models.TbAtor ator = new Models.TbAtor();
            ator.NmAtor = req.Ator;
            ator.VlAltura = req.Altura;
            ator.DtNascimento = req.Nascimento;

            return ator;
        }

        public Models.Response.AtorResponse ToResponseConversor(Models.TbAtor ator)
        {
            Models.Response.AtorResponse resp = new Models.Response.AtorResponse(
                ator.IdAtor, ator.NmAtor, ator.VlAltura, ator.DtNascimento
            );

            return resp;
        }
    }
}