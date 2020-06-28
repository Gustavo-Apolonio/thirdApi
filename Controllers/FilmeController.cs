using Microsoft.AspNetCore.Mvc;

namespace thirdApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        Utils.FilmeConversor filmeConversor = new Utils.FilmeConversor();
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
    }
}