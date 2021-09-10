using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("ApplicationException/JsonOptions")]

    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [Authorize(Roles = "administrador, comum")]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> listaJogos = _jogoRepository.ListarJogos();

            return Ok(listaJogos);
        }

        [Authorize(Roles = "administrador, comum")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado!");
            }

            return Ok(jogoBuscado);
        }

        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            _jogoRepository.CadastrarJogo(novoJogo);

            return StatusCode(201);
        }

        [Authorize(Roles = "administrador")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, JogoDomain jogoAtualizado)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Jogo não encontrado!",
                            erro = true
                        }

                    );
            }

            try
            {
                _jogoRepository.AtualizarJogo(id, jogoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "administrador")]
        [HttpDelete("excluir/id")]
        public IActionResult Delete(int id)
        {
            _jogoRepository.Deletarjogo(id);

            return NoContent();
        }
    }
}
