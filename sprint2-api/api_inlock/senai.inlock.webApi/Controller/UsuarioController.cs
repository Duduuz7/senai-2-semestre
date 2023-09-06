using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Busca um login pelo seu email e senha
        /// </summary>
        /// <param name="usuario">Objeto com o login</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                // Faz chamada para o método de login
                UsuarioDomain usuarioDomain = _usuarioRepository.Login(usuario.Email, usuario.Senha);

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
                    new Claim(ClaimTypes.Role, usuarioDomain.IdTipoUsuario.ToString()),

                    //Existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada","Valor Personalizado")
                };

                //2- Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-chave-autenticacao-webapi-dev"));

                //3- Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4- Gerar o token
                var token = new JwtSecurityToken
                (
                    //Emissor do token
                    issuer: "senai.inlock.webApi",

                    //Destinatário
                    audience: "senai.inlock.webApi",

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
