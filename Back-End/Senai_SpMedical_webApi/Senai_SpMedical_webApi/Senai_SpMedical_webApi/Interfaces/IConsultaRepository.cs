using Senai_SpMedical_webApi.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webApi.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Atualizar o Status de uma consulta
        /// </summary>
        /// <param name="id">Id da consulta a ser atualizada</param>
        /// <param name="Status">Novo status da consulta</param>
        void AtualizarStatus(int id, string Status);
        
        /// <summary>
        /// Métodod responsavel por atualizar as descrições da consulta
        /// </summary>
        /// <param name="id">Id da consulta a ser atualizada</param>
        /// <param name="descricao">Nova descrição da consulta</param>
        void AtualizarDescricao(int id, string descricao);

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
