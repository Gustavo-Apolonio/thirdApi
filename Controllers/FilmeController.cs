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
    public class FilmeController : ControllerBase
    {
        Utils.FilmeConversor filmeConversor = new Utils.FilmeConversor();
        Utils.PersonagemConversor personagemConversor = new Utils.PersonagemConversor();
        Business.FilmeBusiness filmeBusiness = new Business.FilmeBusiness();

        [HttpPost]
        public ActionResult<Models.Response.FilmeResponse> AdicionarFilme(Models.Request.FilmeRequest req)
        {
            try
            {
                Models.TbFilme filme = filmeConversor.ToTableConversor(req);

                filme = filmeBusiness.AdicionarFilme(filme);

                Models.Response.FilmeResponse resp = filmeConversor.ToResponseConversor(filme);

                return resp;
            }
            catch (System.Exception e)
            {
                return BadRequest(
                    new Models.Response.ErrorResponse(400, e.Message)
                );
            }
        }

        [HttpPost("{idFilme}/personagem")]
        public ActionResult<Models.Response.PersonagemResponse> AdicionarPersonagem(int idFilme, Models.Request.PersonagemRequest req)
        {
            try
            {
                filmeBusiness.ConferirIdPersonagemFilme(idFilme);

                try
                {
                    req.Filme = idFilme;

                    Models.TbFilmeAtor personagem = personagemConversor.ToTableConversor(req);

                    personagem = filmeBusiness.AdicionarPersonagem(personagem);

                    Models.Response.PersonagemResponse resp = personagemConversor.ToResponseConversor(personagem);

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

        [HttpGet("{idFilme}/personagem")]
        public ActionResult<List<Models.Response.PersonagemResponse>> ConsultarPersonagensFilme(int idFilme)
        {
            try
            {
                filmeBusiness.ConferirIdPersonagemFilme(idFilme);

                List<Models.TbFilmeAtor> personagens = filmeBusiness.ConsultarPersonagensFilme(idFilme);

                List<Models.Response.PersonagemResponse> resp = personagens.Select(
                    x => personagemConversor.ToResponseConversor(x)
                ).ToList();

                return resp;
            }
            catch (System.Exception e)
            {
                return NotFound(
                    new Models.Response.ErrorResponse(404, e.Message)
                );
            }
        }

        [HttpGet("{idFilme}/personagem/{idPersonagem}")]
        public ActionResult<Models.Response.PersonagemResponse> ConsultarPersonagemFilme(int idFilme, int idPersonagem)
        {
            try
            {
                filmeBusiness.ConferirIdPersonagemFilme(idFilme);

                filmeBusiness.ConferirIdFilmePersonagem(idPersonagem, idFilme);

                Models.TbFilmeAtor personagem = filmeBusiness.ConsultarPersonagemFilme(idFilme, idPersonagem);

                Models.Response.PersonagemResponse resp = personagemConversor.ToResponseConversor(personagem);

                return resp;
            }
            catch (System.Exception e)
            {
                return NotFound(
                    new Models.Response.ErrorResponse(404, e.Message)
                );
            }
        }


        [HttpPut("{idFilme}/personagem/{idPersonagem}")]
        public ActionResult<Models.Response.PersonagemResponse> AlterarPersonagemFilme(int idFilme,
                                                                                  int idPersonagem, 
                                                              Models.Request.PersonagemRequest req)
        {
            try
            {
                filmeBusiness.ConferirIdPersonagemFilme(idFilme);

                filmeBusiness.ConferirIdFilmePersonagem(idPersonagem, idFilme);
                
                try
                {
                    req.Filme = idFilme;

                    Models.TbFilmeAtor atual = filmeBusiness.ConsultarPersonagemFilme(idFilme, idPersonagem);

                    Models.TbFilmeAtor novo = personagemConversor.ToTableConversor(req);

                    atual = filmeBusiness.AlterarPersonagemFilme(atual, novo);

                    Models.Response.PersonagemResponse resp = personagemConversor.ToResponseConversor(atual);

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

        [HttpDelete("{idFilme}/personagem/{idPersonagem}")]
        public ActionResult<Models.Response.PersonagemResponse> DeletarFilme(int idFilme, int idPersonagem)
        {
            try
            {
                filmeBusiness.ConferirIdPersonagemFilme(idFilme);

                filmeBusiness.ConferirIdFilmePersonagem(idPersonagem, idFilme);

                Models.TbFilmeAtor personagem = filmeBusiness.ConsultarPersonagemFilme(idFilme, idPersonagem);

                personagem = filmeBusiness.DeletarPersonagemFilme(personagem);

                Models.Response.PersonagemResponse resp = personagemConversor.ToResponseConversor(personagem);

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