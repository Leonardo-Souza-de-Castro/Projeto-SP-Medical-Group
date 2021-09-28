using Senai_SpMedical_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SpMedical_webApi.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Listar todas as Consultas
        /// </summary>
        /// <returns>Uma lista de Consultas</returns>
        List<Consulta> Listar();

        /// <summary>
        /// Listar todas as consultas de um Paciente especifico
        /// </summary>
        /// <param name="id">Id do Paciente que quer ver suas consultas</param>
        /// <returns>A lista de consultas desse paciente</returns>
        List<Consulta> ListarSomentePaciente(int id);

        /// <summary>
        /// Listar todas as consultas de um Médico especifico
        /// </summary>
        /// <param name="id">Id do Médico que quer ver suas consultas</param>
        /// <returns>A lista de consultas desse médico</returns>
        List<Consulta> ListarSomenteMedico(int id);

        /// <summary>
        /// Busca uma Consulta especifica
        /// </summary>
        /// <param name="id">Id da Consulta buscada</param>
        /// <returns>A Consulta com aquele Id</returns>
        Consulta Buscar(int id);

        /// <summary>
        /// Cadastrar uma nova Consulta
        /// </summary>
        /// <param name="ConsultaNova">Dados a serem cadastrados</param>
        void Cadastrar(Consulta ConsultaNova);

        /// <summary>
        /// Atualizar uma Consulta existente
        /// </summary>
        /// <param name="ConsultaAtualizada">Dados Atualizados</param>
        /// <param name="id">Id da Consulta a ser atualizada</param>
        void Atualizar(Consulta ConsultaAtualizada, int id);

        /// <summary>
        /// Deletar uma Consulta
        /// </summary>
        /// <param name="id">Id da Consulta a ser deletada</param>
        void Deletar(int id);
    }
}
