using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Interfaces
{
    public interface IEstudioRepository
    {
        List<EstudioDomain> Listar();

        EstudioDomain BuscarPorId(Guid id);

        void Cadastrar(EstudioDomain estudio);

        void Atualizar(Guid id, EstudioDomain estudio);

        void Deletar(Guid id);

        //List<EstudioDomain> ListarComJogos();
    }
}
