using Senai_SpMedical_webApi.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webApi.Interfaces
{
    interface IStatusConsultaRepository
    {
        /// <summary>
        /// Listar todas as StatusConsultas
        /// </summary>
        /// <returns>Uma lista de StatusConsultas</returns>
        List<StatusConsulta> Listar();

        /// <summary>
        /// Busca um StatusConsulta especifica
        /// </summary>
        /// <param name="id">Id do StatusConsulta buscado</param>
        /// <returns>O StatusConsulta com aquele Id</returns>
        StatusConsulta Buscar(int id);

        /// <summary>
        /// Cadastrar um novo StatusConsulta
        /// </summary>
        /// <param name="StatusNova">Dados a serem cadastrados</param>
        void Cadastrar(StatusConsulta StatusNova);

        /// <summary>
        /// Atualizar um StatusConsulta existente
        /// </summary>
        /// <param name="StatusAtualizado">Dados Atualizados</param>
        /// <param name="id">Id do StatusConsulta a ser atualizada</param>
        void Atualizar(StatusConsulta StatusAtualizado, int id);

        /// <summary>
        /// Deletar um StatusConsulta
        /// </summary>
        /// <param name="id">Id do StatusConsulta a ser deletado</param>
        void Deletar(int id);
    }
}
