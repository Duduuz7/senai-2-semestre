using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interface;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controller
{
    /// <summary>
    /// Define que a rota de uma requisição será no seguinte formato
    /// dominio/api/nomeController
    /// Exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// Define que é um controlador de API
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que o tipo de resposta da API é JSON
    /// </summary>
    [Produces("application/json")]

    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instância do objeto _generoRepository para que haja referência aos métodos no repositório
        /// </summary>
        public GeneroController()
        {
            //Pega tudo do repositório de genero e guarda dentro do objeto _generoRepository
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método de listar os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                //Cria uma lista para receber os gêneros
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //Retorna o status code 200 ok e a lista de gêneros no formato JSON
                return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - Bad Request e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o método cadastrar gênero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisição</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                //Faz a chamada para o método cadastrar
                _generoRepository.Cadastrar(novoGenero);

                //Retorna um status code
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - Bad Request e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um gênero passando o id dele pelo corpo/JSON
        /// </summary>
        /// <param name="genero">objeto com gênero que deseja atualizar</param>
        /// <returns>Status Code</returns>
        [HttpPut("Atualizar")]
        public IActionResult UpdateIdBody(GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdCorpo(genero);

                        return NoContent();
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
                //Retorna um status code 400 - Bad Request e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método deletar gênero
        /// </summary>
        /// <returns>Status Code</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _generoRepository.Deletar(Id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - Bad Request e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca e mostra um gênero buscando ele pelo seu Id
        /// </summary>
        /// <param name="Id">Id do gênero a ser buscado</param>
        /// <returns>Status Code</returns>
        [HttpGet("BuscarPorId/{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(Id);

                if (generoBuscado == null)
                {
                    return NotFound("O genêro buscado não foi encontrado !");
                }

                return Ok(generoBuscado);

            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - Bad Request e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um gênero passando o id do gênero que deseja atualizar pela URL
        /// </summary>
        /// <param name="genero">Objeto com gênero que dejeta atualizar</param>
        /// <param name="id">Id do gênero que deseja atualizar</param>
        /// <returns>Status Code</returns>
        [HttpPut("AtualizarUrl/{id})")]
        public IActionResult UpdateByUrl(GeneroDomain genero, int id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdUrl(id, genero);

                        return NoContent();
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
                //Retorna um status code 400 - Bad Request e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }
    }
}
