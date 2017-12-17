using DotNet.Mongo.Repository.Enumeradores;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotNet.Mongo.Repository.Entidades
{
    public class Telefone
    {
        public ushort Ddd { get; set; }
        public ulong Numero { get; set; }
        [BsonRepresentation(BsonType.String)]
        public TipoTelefone Tipo { get; set; }
    }
}
