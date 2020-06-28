namespace thirdApi.Utils
{
    public class FilmeConversor
    {
        public Models.Response.FilmeResponse ToResponseConversor(Models.TbFilme filme)
        {
            Models.Response.FilmeResponse resp = new Models.Response.FilmeResponse(
                filme.IdFilme, filme.NmFilme, filme.DsGenero, filme.NrDuracao,
                filme.VlAvaliacao, filme.BtDisponivel, filme.DtLancamento
            );

            return resp;
        }

        public Models.TbFilme ToTableConversor(Models.Request.FilmeRequest req)
        {
            Models.TbFilme filme = new Models.TbFilme();
            filme.NmFilme = req.Filme;
            filme.DsGenero = req.Genero;
            filme.NrDuracao = req.Duracao;
            filme.VlAvaliacao = req.Avaliacao;
            filme.BtDisponivel = req.Disponivel;
            filme.DtLancamento = req.Lancamento;

            return filme;
        }
    }
}