using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interface;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Status Code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

                return Ok(listaFilmes);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="id">id do filme a ser deletado</param>
        /// <returns>StatusCode</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto com o novo filme a ser cadastrado</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um filme pelo seu id e o lista
        /// </summary>
        /// <param name="id">Id do filme a ser buscado</param>
        /// <returns>Status code</returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("O filme buscado não foi encontrado !");
                }

                return Ok(filmeBuscado);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualizar um filme passando seu Id pela URl
        /// </summary>
        /// <param name="filme">Objeto com filme que deseja atualizar</param>
        /// <param name="id">Id do filme que deseja atualizar</param>
        /// <returns></returns>
        [HttpPut("AtualizarPorId/{id}")]
        public IActionResult UpdateByUrl(FilmeDomain filme, int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filme.IdFilme);

                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdUrl(id, filme);

                        return Ok();
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }
                }
                return NotFound();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualizar um filme passando o id dele pelo corpo/JSON
        /// </summary>
        /// <param name="filme">Objeto com filme que deseja atualizar</param>
        /// <returns>Status Code</returns>
        [HttpPatch("Atualizar")]
        public IActionResult UpdateByBody(FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarIdCorpo(filme);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
