using Senai_SpMedical_webApi.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webApi.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Método responsavel por listar todos os médicos
        /// </summary>
        /// <returns>Uma lista de médicos</returns>
        List<Medico> Listar();

        /// <summary>
        /// Método responsavel por buscar um médico por um id especifico
        /// </summary>
        /// <param name="id">Id do médico a ser buscado</param>
        /// <returns>Medico encontrado</returns>
        Medico Buscar(int id);

        /// <summary>
        /// Método responsavel por cadastrar um novo médico
        /// </summary>
        /// <param name="mediconovo">Objeto do tipo Médico a ser cadastrado</param>
        void Cadastrar(Medico mediconovo);

        /// <summary>
        /// Método responsavel pela atualização de algum cadastro de médico
        /// </summary>
        /// <param name="medicoatualizado">Dados Atualizados</param>
        /// <param name="id">Id do médico a ser atualizado</param>
        void Atualizar(Medico medicoatualizado, int id);

        /// <summary>
        /// Método responsavel por deletar um médico
        /// </summary>
        /// <param name="id">Id do médico a ser deletado</param>
        void Deletar(int id);
    }
}
