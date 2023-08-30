using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interface;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Busca um login pela seu email e senha
        /// </summary>
        /// <param name="email">Email da conta que deseja encontrar</param>
        /// <param name="senha">Senha da conta que deseja encontrar</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(string email, string senha)
        {
            try
            {
                // Faz chamada para o método de login
                UsuarioDomain usuarioDomain = _usuarioRepository.BuscarLogin(email, senha);

                if (usuarioDomain != null)
                {
                    // Login aprovado, você pode retornar um resultado com informações do usuário
                    return Ok(usuarioDomain);
                }
                else
                {
                    // Login falhou, retorna um status Unauthorized (401)
                    return Unauthorized();
                }
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

    }
}
