using Microsoft.AspNetCore.Mvc;
using QuestaoDois.Models;
using QuestaoDois.Repository;

namespace QuestaoDois.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeiraController : ControllerBase
    {
        private readonly IFeiraRepository _repository;

        public FeiraController(IFeiraRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("projeto")]
        public IActionResult CadastrarProjeto(Projeto projeto)
        {
            var existente = _repository.ObterProjetoPorNumero(projeto.Numero);

            if (existente != null)
            {
                return BadRequest("Já existe um projeto com esse número");
            }

            _repository.CadastrarProjeto(projeto);
            return Ok("Projeto cadastrado com sucesso");
        }

        [HttpGet("projeto")]
        public IActionResult ListarProjetos()
        {
            return Ok(_repository.ListarProjetos());
        }

        [HttpPost("visita")]
        public IActionResult RegistrarVisita(Visita visita)
        {
            var projeto = _repository.ObterProjetoPorNumero(visita.NumeroProjeto);

            if (projeto == null)
            {
                return NotFound("Projeto não encontrado");
            }

            visita.DataVisita = DateTime.Now;
            _repository.RegistrarVisita(visita);
            return Ok("Visita registrada com sucesso");
        }

        [HttpGet("visita/{numero}")]
        public IActionResult ObterVisitas(int numero)
        {
            var projeto = _repository.ObterProjetoPorNumero(numero);

            if (projeto == null)
            {
                return NotFound("Projeto não encontrado");
            }

            var visitas = _repository.ObterVisitasPorProjeto(numero);
            return Ok(visitas);
        }
    }
}