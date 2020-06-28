namespace thirdApi.Database
{
    public class FilmeDatabase
    {
        Models.apidbContext ctx = new Models.apidbContext();

        public Models.TbFilme AdicionarFilme(Models.TbFilme filme)
        {
            ctx.Add(filme);
            ctx.SaveChanges();

            return filme;
        }
    }
}