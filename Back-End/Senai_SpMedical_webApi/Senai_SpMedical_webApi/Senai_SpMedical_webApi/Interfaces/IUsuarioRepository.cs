using Microsoft.AspNetCore.Http;
using Senai_SpMedical_webApi.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Método responsavel por fazer login no sistema
        /// </summary>
        /// <param name="email">Email para login</param>
        /// <param name="senha">Senha para login</param>
        /// <returns>Usuario com esse email e senha</returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// Método responsavel por salvar uma nova foto no formato png em um perfil
        /// </summary>
        /// <param name="foto">Foto a ser salva</param>
        /// <param name="id_usuario">Id do Perfil que quer cadastrar uma foto</param>
        void SalvarPerfilDirPNG(IFormFile foto, int id_usuario);

        /// <summary>
        /// Método responsavel por salvar uma nova foto no formato jpg em um perfil
        /// </summary>
        /// <param name="foto">Foto a ser salva</param>
        /// <param name="id_usuario">Id do Perfil que quer cadastrar uma foto</param>
        void SalvarPerfilDirJPG(IFormFile foto, int id_usuario);

        /// <summary>
        /// Método para consultar uma foto para cadastro
        /// </summary>
        /// <param name="id_usuario">Id do usuario que vai cadastrar a foto</param>
        /// <returns>O codigo da imagem a ser cadastrada</returns>
        string ConsultarPerfilDir(int id_usuario);

        /// <summary>
        /// Método responsavel por listar todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Método responsavel por buscar um usuario por um id especifico
        /// </summary>
        /// <param name="id">Id do usuario a ser buscado</param>
        /// <returns>Usuario encontrado</returns>
        Usuario Buscar(int id);

        /// <summary>
        /// Método responsavel por cadastrar um novo usuario
        /// </summary>
        /// <param name="Usuarionovo">Objeto do tipo usuario a ser cadastrado</param>
        void Cadastrar(Usuario Usuarionovo);

        /// <summary>
        /// Método responsavel pela atualização de algum cadastro de usuario
        /// </summary>
        /// <param name="Usuarioatualizado">Dados Atualizados</param>
        /// <param name="id">Id do usuario a ser atualizado</param>
        void Atualizar(Usuario Usuarioatualizado, int id);

        /// <summary>
        /// Método responsavel por deletar um usuario
        /// </summary>
        /// <param name="id">Id do usuario a ser deletado</param>
        void Deletar(int id);
    }
}
