using Microsoft.AspNetCore.Mvc;
using QuestaoUm.Models;
using QuestaoUm.Repository;

namespace QuestaoUm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EleicaoController : ControllerBase
    {
        private readonly IEleicaoRepository _repository;

        public EleicaoController(IEleicaoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("candidato")]
        public IActionResult CadastrarCandidato(Candidato candidato)
        {
            var existente = _repository.ObterCandidatoPorNumero(candidato.Numero);

            if (existente != null)
            {
                return BadRequest("Já existe um candidato com esse número");
            }

            _repository.CadastrarCandidato(candidato);
            return Ok("Candidato cadastrado com sucesso");
        }

        [HttpGet("candidato")]
        public IActionResult ListarCandidatos()
        {
            return Ok(_repository.ListarCandidatos());
        }

        [HttpPost("voto")]
        public IActionResult RegistrarVoto(Voto voto)
        {
            var candidato = _repository.ObterCandidatoPorNumero(voto.NumeroCandidato);

            if (candidato == null)
            {
                return NotFound("Candidato não encontrado");
            }

            voto.DataVoto = DateTime.Now;
            _repository.RegistrarVoto(voto);
            return Ok("Voto registrado com sucesso");
        }

        [HttpGet("voto/{numero}")]
        public IActionResult ObterVotos(int numero)
        {
            var candidato = _repository.ObterCandidatoPorNumero(numero);

            if (candidato == null)
            {
                return NotFound("Candidato não encontrado");
            }

            var votos = _repository.ObterVotosPorCandidato(numero);
            return Ok(votos);
        }
    }
}