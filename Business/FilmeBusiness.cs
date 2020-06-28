using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace thirdApi.Business
{
    public class FilmeBusiness
    {
        Database.FilmeDatabase filmeDb = new Database.FilmeDatabase();
        
        public Models.TbFilme AdicionarFilme(Models.TbFilme filme)
        {
            if(filme.NmFilme == string.Empty)
                throw new ArgumentException("Nome Inválido.");

            if(filme.DsGenero == string.Empty)
                throw new ArgumentException("Gênero Inválido.");

            if(filme.NrDuracao == 0)
                throw new ArgumentException("Duração Inválida.");

            if(filme.VlAvaliacao < 0 || filme.VlAvaliacao > 10)
                throw new ArgumentException("Avalição Inválida.");

            if(filme.DtLancamento > DateTime.Now)
                throw new ArgumentException("Data de Lançamento Inválida.");

            filme = filmeDb.AdicionarFilme(filme);

            return filme;
        } 

        public List<Models.TbFilme> ConsultarFilmes()
        {
            List<Models.TbFilme> filmes = filmeDb.ConsultarFilmes();

            if(filmes.Count == 0)
                throw new ArgumentException("Não há filmes no Banco de Dados");

            return filmes;
        }
    }
}