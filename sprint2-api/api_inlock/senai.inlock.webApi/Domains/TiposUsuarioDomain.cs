using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class TiposUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "o título é obrigatório !")]
        public string? Titulo { get; set; }
    }
}
