using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace thirdApi.Business
{
    public class AtorBusiness
    {
        Database.AtorDatabase atorDb = new Database.AtorDatabase();

        public Models.TbAtor AdicionarAtor(Models.TbAtor ator)
        {
            if(ator.NmAtor == string.Empty)
                throw new ArgumentException("Nome Inválido.");

            if(ator.VlAltura <= 0)
                throw new ArgumentException("Altura Inválida.");

            if(ator.DtNascimento >= DateTime.Now)
                throw new ArgumentException("Data de Nascimento Inválida.");

            ator = atorDb.AdicionarAtor(ator);

            return ator;
        }

        public List<Models.TbAtor> ConsultarAtorFiltro(string nome)
        {
            if(nome == null)
                throw new ArgumentException("Nome Inválido.");

            List<Models.TbAtor> atores = atorDb.ConsultarAtorFiltro(nome);

            return atores;
        }

        public List<Models.TbAtor> ConsultarAtores()
        {
            List<Models.TbAtor> atores = atorDb.ConsultarAtores();

            if(atores.Count == 0)
                throw new ArgumentException("Não há atores no banco de dados.");

            return atores;
        }

        public Models.TbAtor ConsultarAtor(int id)
        {
            List<Models.TbAtor> atores = this.ConsultarAtores();

            if(id <= 0)
                throw new ArgumentException("ID Inválido.");

            if(atores.All(x => x.IdAtor != id))
                throw new ArgumentException("O ID do ator não existe.");

            Models.TbAtor ator = atorDb.ConsultarAtor(id);

            return ator;
        }
        
        public Models.TbAtor AlterarAtor(Models.TbAtor atual, Models.TbAtor novo)
        {
            if(novo.NmAtor == string.Empty)
                throw new ArgumentException("Nome Inválido.");

            if(novo.VlAltura <= 0)
                throw new ArgumentException("Altura Inválida.");

            if(novo.DtNascimento >= DateTime.Now)
                throw new ArgumentException("Data de Nascimento Inválida.");

            atual = atorDb.AlterarAtor(atual, novo);

            return atual;
        }

        public Models.TbAtor DeletarAtor(Models.TbAtor ator)
        {
            ator = atorDb.DeletarAtor(ator);

            return ator;
        }
    }
}