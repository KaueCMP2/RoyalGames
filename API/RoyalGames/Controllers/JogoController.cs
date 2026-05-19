using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalGames.Aplications.Services;
using RoyalGames.DTOs.JogoDto;
using RoyalGames.Exceptions;
using System.Security.Claims;

namespace RoyalGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly JogoService _service;

        public JogoController(JogoService service)
        {
            _service = service;
        }

        // autenticação do usuário
        private int ObterUsuarioIdLogado()
        {
            // busca no token/claims o valor armazenado como id do usuário
            // ClaimTypes.NameIdentifier geralmente guarda o ID do usuário no JWT
            string? idTexto = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(idTexto))
            {
                throw new DomainException("Usuário não autenticado");
            }

            // Converte o ID que veio como texto para inteiro
            // nosso UsuarioID no sistema está como int
            // as Claims (informações do usuário dentro do token) sempre são armazenadas como texto.
            return int.Parse(idTexto);
        }


        [HttpGet]
        public ActionResult<List<LerJogoDto>> Listar()
        {
            List<LerJogoDto> jogos = _service.Listar();

            //return StatusCode(200, Jogos);
            return Ok(jogos);
        }

        [HttpGet("{id}")]
        public ActionResult<LerJogoDto> ObterPorId(int id)
        {
            LerJogoDto jogo = _service.ObterPorId(id);

            if (jogo == null)
            {
                //return StatusCode(404);
                return NotFound();
            }

            return Ok(jogo);
        }

        [HttpGet("jogo/{id}/imagem")]
        public ActionResult obterImagem(int id)
        {
            var imagem = _service.ObterImagem(id);

            if (imagem == null)
            {
                //return StatusCode(404);
                return NotFound();
            }

            return Ok(imagem);
        }


        [HttpPost]
        [Consumes("multipart/form-data")] // Indica que recebe dados no formato multpart/from-data
        [Authorize] // exige login para adicionar Jogos
        public IActionResult Adicionar([FromForm] CriarJogoDto JogoDTO)
        {
            try
            {
                int usuarioId = ObterUsuarioIdLogado();

                // cadastro fica associado ao usuario logado
                _service.Adicionar(JogoDTO, usuarioId);

                return StatusCode(201);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Atualizar(int id, [FromForm] AtualizarJogoDto jogoDTO)
        {
            try
            {
                _service.Atualizar(id, jogoDTO);
                return NoContent();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
