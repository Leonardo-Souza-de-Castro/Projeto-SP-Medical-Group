using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using Senai_SpMedical_webApi.Repositories;

namespace Senai_SpMedical_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    //Controler responsavel pelo CRUD de Tipos de Usuarios
    public class TipoController : ControllerBase
    {
        private ITipoRepository _TipoRepository { get; set; }

        public TipoController()
        {
            _TipoRepository = new TipoRepository();
        }

        /// <summary>
        /// Listar todos os TipoUsuarios
        /// </summary>
        /// <returns>Uma lista de TipoUsuarios</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_TipoRepository.Listar());
        }

        /// <summary>
        /// Busca um TipoUsuario especifico
        /// </summary>
        /// <param name="id">Id do TipoUsuario buscado</param>
        /// <returns>O TipoUsuario com aquele Id</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_TipoRepository.Buscar(id));
        }

        /// <summary>
        /// Cadastrar um novo TipoUsuario
        /// </summary>
        /// <param name="TipoNovo">Dados a serem cadastrados</param>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario TipoNovo)
        {
            _TipoRepository.Cadastrar(TipoNovo);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar um TipoUsuario existente
        /// </summary>
        /// <param name="TipoAtualizado">Dados Atualizados</param>
        /// <param name="id">Id do TipoUsuario a ser atualizada</param>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(TipoUsuario TipoAtualizado, int id)
        {
            _TipoRepository.Atualizar(TipoAtualizado, id);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar um TipoUsuario
        /// </summary>
        /// <param name="id">Id do TipoUsuario a ser deletado</param>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _TipoRepository.Deletar(id);

            return StatusCode(203);
        }
    }
}
