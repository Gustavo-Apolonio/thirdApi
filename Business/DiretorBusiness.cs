using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace thirdApi.Business
{
    public class DiretorBusiness
    {
        Database.DiretorDatabase diretorDb = new Database.DiretorDatabase();
        Business.FilmeBusiness filmeBusiness = new FilmeBusiness();
        public Models.TbDiretor AdicionarDiretor(Models.TbDiretor diretor)
        {
            
            List<Models.TbFilme> filmes = filmeBusiness.ConsultarFilmes();

            if(diretor.NmDiretor == string.Empty)
                throw new ArgumentException("Nome Inválido.");

            if(diretor.DtNascimento >= DateTime.Now)
                throw new ArgumentException("Data de Nascimento Inválida.");

            double idadeDiretor = (DateTime.Now - diretor.DtNascimento).TotalDays / 365;
            if(idadeDiretor <= 17)
                throw new ArgumentException("O diretor não pode ser menor de idade.");

            if(diretor.IdFilme <= 0)
                throw new ArgumentException("ID Inválido.");

            if(filmes.All(x => x.IdFilme != diretor.IdFilme))
                throw new ArgumentException("ID do filme não existe.");

            diretor = diretorDb.AdicionarDiretor(diretor);

            return diretor;
        }

        public List<Models.TbDiretor> ConsultarDiretorFiltro(string nome)
        {
            if(nome == null)
                throw new ArgumentException("Nome inválido.");

            List<Models.TbDiretor> diretores = diretorDb.ConsultarDiretorFiltro(nome);

            return diretores;
        }

        public Models.TbDiretor ConsultarDiretor(int id)
        {
            List<Models.TbDiretor> diretores = this.ConsultarDiretores();

            if(id <= 0)
                throw new ArgumentException("ID Inválido.");

            if(diretores.All(x => x.IdDiretor != id))
                throw new ArgumentException("ID do diretor não existe.");

            Models.TbDiretor diretor = diretorDb.ConsultarDiretor(id);

            return diretor;
        }

        public List<Models.TbDiretor> ConsultarDiretores()
        {
            List<Models.TbDiretor> diretores = diretorDb.ConsultarDiretores();

            if(diretores.Count == 0)
                throw new ArgumentException("Não há diretores no Banco de Dados");

            return diretores;
        }

        public Models.TbDiretor AlterarDiretor(Models.TbDiretor atual, Models.TbDiretor novo)
        {
            List<Models.TbFilme> filmes = filmeBusiness.ConsultarFilmes();

            if(novo.NmDiretor == string.Empty)
                throw new ArgumentException("Nome Inválido.");

            if(novo.DtNascimento >= DateTime.Now)
                throw new ArgumentException("Data de Nascimento Inválida.");

            double idadeDiretor = (DateTime.Now - novo.DtNascimento).TotalDays / 365;
            if(idadeDiretor <= 17)
                throw new ArgumentException("O diretor não pode ser menor de idade.");

            if(novo.IdFilme <= 0)
                throw new ArgumentException("ID Inválido.");

            if(filmes.All(x => x.IdFilme != novo.IdFilme))
                throw new ArgumentException("ID do filme não existe.");

            atual = diretorDb.AlterarDiretor(atual, novo);

            return atual;
        }
    }
}