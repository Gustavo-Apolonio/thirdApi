using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public List<Models.TbFilme> ConsultarFilmes()
        {
            List<Models.TbFilme> filmes = ctx.TbFilme.ToList();

            return filmes;
        }

        public Models.TbFilmeAtor AdicionarPersonagem(Models.TbFilmeAtor personagem)
        {
            ctx.TbFilmeAtor.Add(personagem);
            ctx.SaveChanges();

            return personagem;
        }

        public List<Models.TbFilmeAtor> ConsultarPersonagensFilme(int idFilme)
        {
            List<Models.TbFilmeAtor> personagens = ctx.TbFilmeAtor.Where(x => x.IdFilme == idFilme)
                                                                  .ToList();

            return personagens;
        }

        public Models.TbFilmeAtor ConsultarPersonagemFilme(int idFilme, int idPersonagem)
        {
            Models.TbFilmeAtor personagem = ctx.TbFilmeAtor.First(x => x.IdFilme == idFilme
                                                                    && x.IdFilmeAtor == idPersonagem);

            return personagem;
        }

        public Models.TbFilmeAtor AlterarPersonagemFilme(Models.TbFilmeAtor atual, Models.TbFilmeAtor novo)
        {
            atual.NmPersonagem = novo.NmPersonagem;
            atual.IdFilme = novo.IdFilme;
            atual.IdAtor = novo.IdAtor;

            ctx.SaveChanges();
            
            return atual;
        }

        public Models.TbFilmeAtor DeletarPersonagemFilme(Models.TbFilmeAtor personagem)
        {
            ctx.Remove(personagem);
            ctx.SaveChanges();

            return personagem;
        }
    }
}