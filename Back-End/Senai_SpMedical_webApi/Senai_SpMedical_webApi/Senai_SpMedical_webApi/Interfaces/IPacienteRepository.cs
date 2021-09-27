using Senai_SpMedical_webApi.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webApi.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Listar todos os pacientes
        /// </summary>
        /// <returns>Uma lista de pacientes</returns>
        List<Paciente> Listar();

        /// <summary>
        /// Buscar um paciente especifico
        /// </summary>
        /// <param name="id">Id do paciente buscado</param>
        /// <returns>Pacinete com o id buscado</returns>
        Paciente Buscar(int id);

        /// <summary>
        /// Cadastrar novos pacientes
        /// </summary>
        /// <param name="PacienteNovo">Dados a serem cadastrados</param>
        void Cadastrar(Paciente PacienteNovo);

        /// <summary>
        /// Atualizar os dados dos pacientes
        /// </summary>
        /// <param name="PacienteAtualizado">Dados atualizados</param>
        /// <param name="id">Id do Paciente a ser atualizado</param>
        void Atualizar(Paciente PacienteAtualizado, int id);

        /// <summary>
        /// Deletar dados de pacientes
        /// </summary>
        /// <param name="id">Id do Paciente a ser deletado</param>
        void Deletar(int id);
    }
}
