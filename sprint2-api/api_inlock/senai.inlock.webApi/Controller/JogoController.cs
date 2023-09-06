using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    [Authorize]
    public class JogoController : ControllerBase
    {

        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos cadastrados
        /// </summary>
        /// <returns>Status Code e a lista com os jogos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

                return Ok(listaJogos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="id">id do jogo que deseja deletar</param>
        /// <returns>Status Code</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "2")]
        public IActionResult Delete(int id)
        {
            try
            {
                _jogoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto com novo jgo</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
