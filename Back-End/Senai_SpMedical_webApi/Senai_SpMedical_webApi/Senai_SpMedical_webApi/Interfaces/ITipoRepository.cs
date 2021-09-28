using Senai_SpMedical_webApi.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webApi.Interfaces
{
    interface ITipoRepository
    {
        /// <summary>
        /// Listar todos os TipoUsuarios
        /// </summary>
        /// <returns>Uma lista de TipoUsuarios</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Busca um TipoUsuario especifico
        /// </summary>
        /// <param name="id">Id do TipoUsuario buscado</param>
        /// <returns>O TipoUsuario com aquele Id</returns>
        TipoUsuario Buscar(int id);

        /// <summary>
        /// Cadastrar um novo TipoUsuario
        /// </summary>
        /// <param name="TipoNovo">Dados a serem cadastrados</param>
        void Cadastrar(TipoUsuario TipoNovo);

        /// <summary>
        /// Atualizar um TipoUsuario existente
        /// </summary>
        /// <param name="TipoAtualizado">Dados Atualizados</param>
        /// <param name="id">Id do TipoUsuario a ser atualizada</param>
        void Atualizar(TipoUsuario TipoAtualizado, int id);

        /// <summary>
        /// Deletar um TipoUsuario
        /// </summary>
        /// <param name="id">Id do TipoUsuario a ser deletado</param>
        void Deletar(int id);
    }
}
