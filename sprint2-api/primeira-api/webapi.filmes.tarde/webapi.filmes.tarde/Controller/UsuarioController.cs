using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                // Faz chamada para o método de login
                UsuarioDomain usuarioDomain = _usuarioRepository.BuscarLogin(usuario.Email, usuario.Senha);

                if (usuarioDomain == null)
                {
                    // Login aprovado, você pode retornar um resultado com informações do usuário
                    return NotFound("Usuário não encontrado, email ou senha inválidos !");
                }
                //Caso encontre o usuárip buscado, prossegue para a criação do token

                //1- Definir as informaçoes(claims) que serão fornecidos no token (payload)
                var claims = new[]
                { 
                    //formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioDomain.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioDomain.Email),
                    new Claim(ClaimTypes.Role, usuarioDomain.Permissao),

                    //Existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada","Valor Personalizado")
                };

                //2- Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                //3- Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4- Gerar o token
                var token = new JwtSecurityToken
                (
                    //Emissor do token
                    issuer: "webapi.filmes.tarde",

                    //Destinatário
                    audience: "webapi.filmes.tarde",

                    //Dados definidos na claim (Payload)
                    claims: claims,

                    //Tempo de expiração
                    expires: DateTime.Now.AddMinutes(5),

                    //Credenciais do token
                    signingCredentials: creds

                );

                //5- Retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

    }
}






//try
//{
//    // Faz chamada para o método de login
//    UsuarioDomain usuarioDomain = _usuarioRepository.BuscarLogin(usuario.Email, usuario.Senha);

//    if (usuarioDomain == null)
//    {
//        // Login aprovado, você pode retornar um resultado com informações do usuário
//        return NotFound("Usuário não encontrado, email ou senha inválidos !");
//    }
//     return Ok(usuarioDomain);
//}
//catch (Exception erro)
//{
//    // Retorna um status code BadRequest (400) e a mensagem de erro
//    return BadRequest(erro.Message);
//}

//try
//{
//    // Faz chamada para o método de login
//    UsuarioDomain usuarioDomain = _usuarioRepository.BuscarLogin(usuario.Email, usuario.Senha);

//    if (usuarioDomain != null)
//    {
//        // Login aprovado, você pode retornar um resultado com informações do usuário
//        return Ok(usuarioDomain);
//    }
//    else
//    {
//        // Login falhou, retorna um status NotFound
//        return NotFound("Usuário não encontrado, email ou senha inválidos !");
//    }
//}
//catch (Exception erro)
//{
//    // Retorna um status code BadRequest (400) e a mensagem de erro
//    return BadRequest(erro.Message);
//}