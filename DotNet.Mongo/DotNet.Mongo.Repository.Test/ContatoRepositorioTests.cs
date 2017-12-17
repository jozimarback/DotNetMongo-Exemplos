using DotNet.Mongo.Repository.Entidades;
using DotNet.Mongo.Repository.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace DotNet.Mongo.Repository.Test
{
    [TestClass]
    public class ContatoRepositorioTests
    {
        private ContatoRepositorio contatoRepositorio;

        [TestInitialize]
        public void IncializacaoDeTestes()
        {
            contatoRepositorio = new ContatoRepositorio();
        }

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


        [TestMethod]
        public void DeveAlterarUmRegistro()
        {
            var id = "5a36746afbc8223738f4541d";
            var novoNomeParaContato = "Contato Alterado";

            var contato = contatoRepositorio.Obter(id);
            contato.Nome = novoNomeParaContato;
            contatoRepositorio.Atualizar(contato);

            var contatoAlterado = contatoRepositorio.Obter(id);
            
            Assert.AreEqual(novoNomeParaContato,contatoAlterado.Nome);
        }

        [TestMethod]
        public void DeveRemoverUmRegistro()
        {
            var id = "5a36e056fbc82207d05eae53";
            contatoRepositorio.Remover(id);

            Assert.IsNull(contatoRepositorio.Obter(id));
        }
    }
}