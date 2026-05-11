using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalGames.Aplications.Services;
using RoyalGames.DTOs.GeneroDto;
using RoyalGames.DTOs.PlataformaDto;
using RoyalGames.Exceptions;

namespace RoyalGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly GeneroService _service;
        public GeneroController(GeneroService service)
        {
         _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerGeneroDto>> Listar()
        {
            List<LerGeneroDto> generos = _service.Listar();
            return Ok(generos);
        }

        [HttpGet("{id}")]
        public ActionResult<LerGeneroDto> ObterPorId(int id)
        {
            LerGeneroDto generoDto = _service.ObterPorId(id);

            if (generoDto == null)
            {
                return NotFound();
            }

                return Ok(generoDto);
            }

        [HttpPost]
        //[Authorize]
        public ActionResult Adicionar(CriarGeneroDto criarGenero)
        {
            try
            {
                _service.Adicionar(criarGenero);
                return StatusCode(201);
            }
            catch (DomainException ex)
             {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        //[Authorize]
        public ActionResult Atualizar(int id, CriarGeneroDto criarGenero)
        {
            try
            {
                _service.Atualizar(id, criarGenero);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
      
    }
}
