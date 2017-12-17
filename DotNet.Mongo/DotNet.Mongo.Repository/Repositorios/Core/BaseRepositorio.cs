using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Mongo.Repository.Repositorios
{
    public class BaseRepositorio<TColecao>
    {

        protected static IMongoClient Client => new MongoClient(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        protected static IMongoDatabase Db => Client.GetDatabase(ConfigurationManager.AppSettings["database"]);
        protected static IMongoCollection<TColecao> Colecao;
        

        public BaseRepositorio(string colecao)
        {
            Colecao = Db.GetCollection<TColecao>(colecao);
        }

        /// <summary>
        /// Obter por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TColecao Obter(string id)
        {
            return Colecao.Find(FiltroPorId(id)).FirstOrDefault();
        }

        public virtual IQueryable<TColecao> Obter()
        {
            return Colecao.AsQueryable();
        }

        /// <summary>
        /// Inserir varios registros
        /// </summary>
        /// <param name="modelo"></param>
        public virtual void Inserir(IList<TColecao> modelo)
        {
            Colecao.InsertMany(modelo);
        }

        /// <summary>
        /// Inserir um registro
        /// </summary>
        /// <param name="modelo"></param>
        public virtual void Inserir(TColecao modelo)
        {
            Colecao.InsertOne(modelo);
        }

        public virtual async Task InserirAsync(IList<TColecao> modelo)
        {
            await Colecao.InsertManyAsync(modelo);
        }

        public virtual async Task InserirAsync(TColecao modelo)
        {
            await Colecao.InsertOneAsync(modelo);
        }

        public virtual void Atualizar(TColecao modelo)
        {
            Colecao.ReplaceOne(FiltroPorId(BsonTypeMapper.MapToDotNetValue(modelo.ToBsonDocument().GetElement("_id").Value).ToString()), modelo);
        }

        public virtual void Remover(string id)
        {
            Colecao.DeleteOne(FiltroPorId(id));
        }

        protected FilterDefinition<TColecao> FiltroPorId(string id)
        {
            return Builders<TColecao>.Filter.Eq("_id", new ObjectId(id));
        }
    }
}
