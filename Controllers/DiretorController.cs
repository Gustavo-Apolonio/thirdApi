using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace thirdApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiretorController : ControllerBase
    {
        Utils.DiretorConversor diretorConversor = new Utils.DiretorConversor();
        Business.DiretorBusiness diretorBusiness = new Business.DiretorBusiness();

        [HttpPost]
        public ActionResult<Models.Response.DiretorResponse> AdicionarDiretor(Models.Request.DiretorRequest req)
        {
            try
            {
                Models.TbDiretor diretor = diretorConversor.ToTableConversor(req);

                diretor = diretorBusiness.AdicionarDiretor(diretor);

                Models.Response.DiretorResponse resp = diretorConversor.ToResponseConversor(diretor);

                return resp;
            }
            catch (System.Exception e)
            {
                return BadRequest(
                    new Models.Response.ErrorResponse(400, e.Message)
                );
            }
        }

        [HttpGet]
        public ActionResult<List<Models.Response.DiretorResponse>> ConsultarDiretorFiltro(string nome)
        {
            try
            {
                List<Models.TbDiretor> diretores = diretorBusiness.ConsultarDiretorFiltro(nome);

                List<Models.Response.DiretorResponse> diretoresResp = diretores.Select(
                    x => diretorConversor.ToResponseConversor(x)
                ).ToList();

                return diretoresResp;
            }
            catch (System.Exception e)
            {
                return BadRequest(
                    new Models.Response.ErrorResponse(400, e.Message)
                );
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Models.Response.DiretorResponse> AlterarDiretor(int id, Models.Request.DiretorRequest req)
        {
            try
            {
                Models.TbDiretor atual = diretorBusiness.ConsultarDiretor(id);

                try
                {
                    Models.TbDiretor novo = diretorConversor.ToTableConversor(req);

                    atual = diretorBusiness.AlterarDiretor(atual, novo);

                    Models.Response.DiretorResponse resp = diretorConversor.ToResponseConversor(atual);

                    return resp;
                }
                catch (System.Exception e)
                {
                    return BadRequest(
                        new Models.Response.ErrorResponse(400, e.Message)
                    );
                }
            }
            catch (System.Exception e)
            {
                return NotFound(
                    new Models.Response.ErrorResponse(404, e.Message)
                );
            }
        }
    }
}