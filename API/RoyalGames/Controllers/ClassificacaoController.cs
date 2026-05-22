using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalGames.Aplications.Services;
using RoyalGames.DTOs.ClassificacaoDto;

namespace RoyalGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificacaoController : ControllerBase
    {
        private readonly ClassificacaoService _service;
        public ClassificacaoController(ClassificacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerClassificacaoDto>> Listar()
        {
            return _service.Listar();
        }

        [HttpGet("{id}")]
        public ActionResult<LerClassificacaoDto> ObterClassificacaoPorId(int id)
        {
            return _service.ObterClassificacaoPorId(id);
        }
    }
}
