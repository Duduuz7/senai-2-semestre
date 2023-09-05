using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interface
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto com novo estudio cadastrado</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Lista todos os estudios cadastrados
        /// </summary>
        /// <returns></returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Deleta um estudio
        /// </summary>
        /// <param name="id">Id do estudio que deseja deletar</param>
        void Deletar(int id);
    }
}
