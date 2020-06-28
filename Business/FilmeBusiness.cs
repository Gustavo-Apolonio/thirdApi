using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace thirdApi.Business
{
    public class FilmeBusiness
    {
        Database.FilmeDatabase filmeDb = new Database.FilmeDatabase();
        Database.AtorDatabase atorDb = new Database.AtorDatabase();
        
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

        public Models.TbFilmeAtor AdicionarPersonagem(Models.TbFilmeAtor personagem)
        {
            if(personagem.NmPersonagem == string.Empty)
                throw new ArgumentException("Nome Inválido.");

            if(personagem.IdFilme <= 0)
                throw new ArgumentException("ID do filme Inválido.");

            if(personagem.IdAtor <= 0)
                throw new ArgumentException("ID do ator Inválido.");

            List<Models.TbAtor> atores = atorDb.ConsultarAtores();

            if(atores.All(x => x.IdAtor != personagem.IdAtor))
                throw new ArgumentException("ID do ator não existe.");

            personagem = filmeDb.AdicionarPersonagem(personagem);

            return personagem;
        }

        public void ConferirIdPersonagemFilme(int idFilme)
        {
            List<Models.TbFilme> filmes = this.ConsultarFilmes();

            if(idFilme <= 0)
                throw new ArgumentException("ID do filme Inválido.");
            
            if(filmes.All(x => x.IdFilme != idFilme))
                throw new ArgumentException("ID do filme não existe.");

        }

        public void ConferirIdFilmePersonagem(int idPersonagem, int idFilme)
        {
            List<Models.TbFilmeAtor> personagens = this.ConsultarPersonagensFilme(idFilme);

            if(idPersonagem <= 0)
                throw new ArgumentException("ID do personagem Inválido.");
            
            if(personagens.All(x => x.IdFilmeAtor != idPersonagem))
                throw new ArgumentException("ID do personagem não existe.");

        }

        public List<Models.TbFilmeAtor> ConsultarPersonagensFilme(int idFilme)
        {
            List<Models.TbFilmeAtor> personagens = filmeDb.ConsultarPersonagensFilme(idFilme);

            if(personagens.Count == 0)
                throw new ArgumentException("Não há personagens para esse filme no Banco de Dados.");

            return personagens;
        }

        public Models.TbFilmeAtor ConsultarPersonagemFilme(int idFilme, int idPersonagem)
        {
            List<Models.TbFilmeAtor> personagens = this.ConsultarPersonagensFilme(idFilme);

            if(idFilme <= 0)
                throw new ArgumentException("ID do filme Inválido.");

            if(idPersonagem <= 0)
                throw new ArgumentException("ID do personagem Inválido.");

            if(personagens.All(x => x.IdFilme != idFilme))
                throw new ArgumentException("O ID do filme não existe.");

            if(personagens.All(x => x.IdFilmeAtor != idPersonagem))
                throw new ArgumentException("O ID do personagem não existe.");

            Models.TbFilmeAtor personagem = filmeDb.ConsultarPersonagemFilme(idFilme, idPersonagem);

            return personagem;
        }

        public Models.TbFilmeAtor AlterarPersonagemFilme(Models.TbFilmeAtor atual, Models.TbFilmeAtor novo)
        {
            if(novo.NmPersonagem == string.Empty)
                throw new ArgumentException("Nome Inválido.");

            if(novo.IdFilme <= 0)
                throw new ArgumentException("ID do filme Inválido.");

            if(novo.IdAtor <= 0)
                throw new ArgumentException("ID do ator Inválido.");

            List<Models.TbAtor> atores = atorDb.ConsultarAtores();

            if(atores.All(x => x.IdAtor != novo.IdAtor))
                throw new ArgumentException("ID do ator não existe.");

            atual = filmeDb.AlterarPersonagemFilme(atual, novo);

            return atual;
        }

        public Models.TbFilmeAtor DeletarPersonagemFilme(Models.TbFilmeAtor personagem)
        {
            personagem = filmeDb.DeletarPersonagemFilme(personagem);

            return personagem;
        }
    }
}