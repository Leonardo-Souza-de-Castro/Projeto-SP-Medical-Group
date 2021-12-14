using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Senai_SpMedical_webApi.Domains
{
    public class Localizacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string Latitude { get; set; }

        [BsonRequired]
        public string Longitude { get; set; }
    }
}
