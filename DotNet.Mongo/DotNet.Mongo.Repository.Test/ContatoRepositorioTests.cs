using DotNet.Mongo.Repository.Entidades;
using DotNet.Mongo.Repository.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace DotNet.Mongo.Repository.Test
{
    [TestClass]
    public class ContatoRepositorioTests
    {
        private readonly ContatoRepositorio contatoRepositorio = new ContatoRepositorio();

        [TestMethod]
        public void DeveInserirUmRegistro()
        {
            var contato = new Contato()
            {
                Nome = "Teste",
                Telefone = new Collection<Telefone>()
                {
                    new Telefone{ Ddd=47,Numero=989085525, Tipo=Enumeradores.TipoTelefone.Celular}
                }
            };
            contatoRepositorio.Inserir(contato);

            Assert.IsNotNull(contatoRepositorio.Obter(contato.Id));
        }
    }
}