using Senai_SpMedical_webApi.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Listar todas as especialidades
        /// </summary>
        /// <returns>Uma lista de Especialidades</returns>
        List<Especialidade> Listar();

        /// <summary>
        /// Busca uma especialidade especifica
        /// </summary>
        /// <param name="id">Id da Especialidade buscada</param>
        /// <returns>A Especialidade com aquele Id</returns>
        Especialidade Buscar(int id);

        /// <summary>
        /// Cadastrar uma nova especialidade
        /// </summary>
        /// <param name="EspeNova">Dados a serem cadastrados</param>
        void Cadastrar(Especialidade EspeNova);

        /// <summary>
        /// Atualizar uma especialidade existente
        /// </summary>
        /// <param name="EspeAtualizada">Dados Atualizados</param>
        /// <param name="id">Id da Especialidade a ser atualizada</param>
        void Atualizar(Especialidade EspeAtualizada, int id);

        /// <summary>
        /// Deletar uma Especialidade
        /// </summary>
        /// <param name="id">Id da especialidade a ser deletada</param>
        void Deletar(int id);
    }
}
