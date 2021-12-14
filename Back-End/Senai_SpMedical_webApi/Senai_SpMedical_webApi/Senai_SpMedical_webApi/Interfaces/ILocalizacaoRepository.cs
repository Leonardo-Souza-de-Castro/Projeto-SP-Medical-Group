using Senai_SpMedical_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SpMedical_webApi.Interfaces
{
    interface ILocalizacaoRepository
    {
        void Cadastrar(Localizacao novaLocalizacao);

        List<Localizacao> ListarTodas();
    }
}
