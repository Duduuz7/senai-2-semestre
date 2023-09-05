using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interface
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto com o novo jogo cadastrado</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Lista todos os jogos cadastrados
        /// </summary>
        /// <returns>Lista com todos os jogos cadastrados</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="id">Id do jogo que deseja deletar</param>
        void Deletar(int id);
    }
}
