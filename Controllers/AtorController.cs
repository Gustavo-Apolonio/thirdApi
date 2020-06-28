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
    public class AtorController : ControllerBase
    {
        Utils.AtorConversor atorConversor = new Utils.AtorConversor();
        Business.AtorBusiness atorBusiness = new Business.AtorBusiness();
        [HttpPost]
        public ActionResult<Models.Response.AtorResponse> AdicionarAtor(Models.Request.AtorRequest req)
        {
            try
            {
                Models.TbAtor ator = atorConversor.ToTableConversor(req);

                ator = atorBusiness.AdicionarAtor(ator);

                Models.Response.AtorResponse resp = atorConversor.ToResponseConversor(ator);

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
        public ActionResult<List<Models.Response.AtorResponse>> ConsultarAtorFiltro(string nome)
        {
            try
            {
                List<Models.TbAtor> atores = atorBusiness.ConsultarAtorFiltro(nome);

                List<Models.Response.AtorResponse> resp = atores.Select(
                    x => atorConversor.ToResponseConversor(x)).ToList();

                return resp;
            }
            catch (System.Exception e)
            {
                return NotFound(
                    new Models.Response.ErrorResponse(404, e.Message)
                );
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Response.AtorResponse> ConsultarAtor(int id)
        {
            try
            {
                Models.Response.AtorResponse resp = atorConversor.ToResponseConversor(
                    atorBusiness.ConsultarAtor(id)
                );

                return resp;
            }
            catch (System.Exception e)
            {
                return NotFound(
                    new Models.Response.ErrorResponse(404, e.Message)
                );
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Models.Response.AtorResponse> AlterarAtor(int id, Models.Request.AtorRequest req)
        {
            try
            {
                Models.TbAtor atual = atorBusiness.ConsultarAtor(id);

                try
                {
                    Models.TbAtor novo = atorConversor.ToTableConversor(req);

                    atual = atorBusiness.AlterarAtor(atual, novo);

                    Models.Response.AtorResponse resp = atorConversor.ToResponseConversor(atual);

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

        [HttpDelete("{id}")]
        public ActionResult<Models.Response.AtorResponse> DeletarAtor(int id)
        {
            try
            {
                Models.TbAtor ator = atorBusiness.ConsultarAtor(id);

                ator = atorBusiness.DeletarAtor(ator);

                Models.Response.AtorResponse resp = atorConversor.ToResponseConversor(ator);

                return resp;
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