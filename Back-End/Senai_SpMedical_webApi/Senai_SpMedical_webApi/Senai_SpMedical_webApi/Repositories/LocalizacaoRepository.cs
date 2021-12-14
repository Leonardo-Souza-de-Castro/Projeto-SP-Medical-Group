using MongoDB.Driver;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SpMedical_webApi.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
            private readonly IMongoCollection<Localizacao> _localizacoes;

            public LocalizacaoRepository()
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("SP_medical_Group");
                _localizacoes = database.GetCollection<Localizacao>("Localizacao");
            }

            public void Cadastrar(Localizacao novaLocalizacao)
            {
                _localizacoes.InsertOne(novaLocalizacao);
            }

            public List<Localizacao> ListarTodas()
            {
                return _localizacoes.Find(localizacao => true).ToList();
            }
        }
    }
