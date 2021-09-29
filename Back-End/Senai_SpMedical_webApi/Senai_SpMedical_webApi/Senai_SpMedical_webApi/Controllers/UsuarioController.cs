using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using Senai_SpMedical_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SpMedical_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método responsavel por listar todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_UsuarioRepository.Listar());
        }

        /// <summary>
        /// Método responsavel por buscar um usuario por um id especifico
        /// </summary>
        /// <param name="id">Id do usuario a ser buscado</param>
        /// <returns>Usuario encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_UsuarioRepository.Buscar(id));
        }

        /// <summary>
        /// Método responsavel por cadastrar um novo usuario
        /// </summary>
        /// <param name="UsuarioNovo">Objeto do tipo usuario a ser cadastrado</param>
        [HttpPost]
        public IActionResult Cadastrar(Usuario UsuarioNovo)
        {
            _UsuarioRepository.Cadastrar(UsuarioNovo);

            return StatusCode(201);
        }

        /// <summary>
        /// Método responsavel pela atualização de algum cadastro de usuario
        /// </summary>
        /// <param name="UsuarioAtualizado">Dados Atualizados</param>
        /// <param name="id">Id do usuario a ser atualizado</param>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Usuario UsuarioAtualizado, int id)
        {
            _UsuarioRepository.Atualizar(UsuarioAtualizado, id);

            return StatusCode(201);
        }

        /// <summary>
        /// Método responsavel por deletar um usuario
        /// </summary>
        /// <param name="id">Id do usuario a ser deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _UsuarioRepository.Deletar(id);

            return StatusCode(203);
        }
    }
}
