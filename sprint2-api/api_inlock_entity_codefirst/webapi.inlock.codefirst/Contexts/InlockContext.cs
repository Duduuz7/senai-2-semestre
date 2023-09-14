using Microsoft.EntityFrameworkCore;
using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Contexts
{
    public class InlockContext : DbContext
    {
        /// <summary>
        /// Definição das entidades do banco de dados
        /// </summary>
        public DbSet<TiposUsuarioDomain> TiposUsuario { get; set; }
        public DbSet<UsuarioDomain> Usuario { get; set; }
        public DbSet<EstudioDomain> Estudio { get; set; }
        public DbSet<UsuarioDomain> Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE07-S15; Database=inlock_games_codeFirst; User Id=sa; Pwd=Senai@134; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
