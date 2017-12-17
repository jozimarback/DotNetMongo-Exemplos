using DotNet.Mongo.Repository.Entidades;

namespace DotNet.Mongo.Repository.Repositorios
{
    public class ContatoRepositorio : BaseRepositorio<Contato>
    {
        public ContatoRepositorio() : base("contato")
        {
        }
    }
}
