using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repositories;
using System.Data;

namespace senai.inlock.webApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class EstudioController : ControllerBase
    {

        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Status Code e a lista com os estúdios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> listaEstudios = _estudioRepository.ListarTodos();

                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um estúdio
        /// </summary>
        /// <param name="id">id do estúdio que deseja deletar</param>
        /// <returns>Status Code</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "2")]
        public IActionResult Delete(int id)
        {
            try
            {
                _estudioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">objeto com novo estúdio cadastrado</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try
            {
                _estudioRepository.Cadastrar(novoEstudio);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
