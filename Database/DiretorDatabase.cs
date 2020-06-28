using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace thirdApi.Database
{
    public class DiretorDatabase
    {
        Models.apidbContext ctx = new Models.apidbContext();

        public Models.TbDiretor AdicionarDiretor(Models.TbDiretor diretor)
        {
            ctx.Add(diretor);
            ctx.SaveChanges();

            return diretor;
        }

        public List<Models.TbDiretor> ConsultarDiretorFiltro(string nome)
        {
            List<Models.TbDiretor> diretores = ctx.TbDiretor.Where(x => x.NmDiretor.Contains(nome))
                                                            .ToList();
            
            return diretores;
        }

        public Models.TbDiretor ConsultarDiretor(int id)
        {
            Models.TbDiretor diretor = ctx.TbDiretor.First(x => x.IdDiretor == id);

            return diretor;
        }

        public List<Models.TbDiretor> ConsultarDiretores()
        {
            List<Models.TbDiretor> diretores = ctx.TbDiretor.ToList();

            return diretores;
        }

        public Models.TbDiretor AlterarDiretor(Models.TbDiretor atual, Models.TbDiretor novo)
        {
            atual.NmDiretor = novo.NmDiretor;
            atual.DtNascimento = novo.DtNascimento;
            atual.IdFilme = novo.IdFilme;

            ctx.SaveChanges();
            
            return atual;
        }

        public Models.TbDiretor DeletarDiretor(Models.TbDiretor diretor)
        {
            ctx.Remove(diretor);
            ctx.SaveChanges();

            return diretor;
        }
    }
}