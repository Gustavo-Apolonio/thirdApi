using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;  

namespace thirdApi.Database
{
    public class AtorDatabase
    {
        Models.apidbContext ctx = new Models.apidbContext();

        public Models.TbAtor AdicionarAtor(Models.TbAtor ator)
        {
            ctx.Add(ator);
            ctx.SaveChanges();

            return ator;
        }

        public List<Models.TbAtor> ConsultarAtorFiltro(string nome)
        {
            List<Models.TbAtor> atores = ctx.TbAtor.Where(x => x.NmAtor.Contains(nome)).ToList();

            return atores;
        } 

        public Models.TbAtor ConsultarAtor(int id)
        {
            Models.TbAtor ator = ctx.TbAtor.First(x => x.IdAtor == id);

            return ator;
        }

        public List<Models.TbAtor> ConsultarAtores()
        {
            List<Models.TbAtor> atores = ctx.TbAtor.ToList();

            return atores;
        }

        public Models.TbAtor AlterarAtor(Models.TbAtor atual, Models.TbAtor novo)
        {
            atual.NmAtor = novo.NmAtor;
            atual.VlAltura = novo.VlAltura;
            atual.DtNascimento = novo.DtNascimento;

            ctx.SaveChanges();

            return atual;
        }

        public Models.TbAtor DeletarAtor(Models.TbAtor ator)
        {
            ctx.Remove(ator);
            ctx.SaveChanges();

            return ator;
        }
    }
}