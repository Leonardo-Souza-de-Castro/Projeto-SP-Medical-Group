using Senai_SpMedical_webApi.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webApi.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Listar todas as Clinicas
        /// </summary>
        /// <returns>Uma lista de clinicas</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Buscar uma clinica por Id
        /// </summary>
        /// <param name="id">Id da clinica buscada</param>
        /// <returns>Clinica com o id buscada</returns>
        Clinica Buscar(int id);

        /// <summary>
        /// Cadastrar uma nova clinica
        /// </summary>
        /// <param name="ClinicaNova">Dados a serem cadastrados</param>
        void Cadastrar(Clinica ClinicaNova);

        /// <summary>
        /// Atualizar os dados de uma clinica
        /// </summary>
        /// <param name="ClinicaAtualizada">Dados atualizados</param>
        /// <param name="id">Id da clinica a ser atualizada</param>
        void Atualizar(Clinica ClinicaAtualizada, int id);

        /// <summary>
        /// Deletar uma clinica existente
        /// </summary>
        /// <param name="id">Id da clinica a ser deletada</param>
        void Deletar(int id);
    }
}
