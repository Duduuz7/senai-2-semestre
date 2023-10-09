using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Contexts;


namespace webapi.inlock.codefirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InlockContext ctx = new InlockContext();
        public void Atualizar(Guid id, EstudioDomain estudio)
        {
            EstudioDomain estudioBuscado = ctx.Estudio.Find(id)!;

            if (estudioBuscado != null)
            {
                estudioBuscado.Nome = estudio.Nome;
            }

            ctx.Update(estudioBuscado!);

            ctx.SaveChanges();
        }

        public EstudioDomain BuscarPorId(Guid id)
        {
            return ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id)!;
        }

        public void Cadastrar(EstudioDomain estudio)
        {
            ctx.Estudio.Add(estudio);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            EstudioDomain estudioBuscado = ctx.Estudio.Find(id)!;

            if (estudioBuscado != null)
            {
                ctx.Estudio.Remove(estudioBuscado);
            }

            ctx.SaveChanges();
        }

        public List<EstudioDomain> Listar()
        {
            return ctx.Estudio.ToList();
        }
    }
}
