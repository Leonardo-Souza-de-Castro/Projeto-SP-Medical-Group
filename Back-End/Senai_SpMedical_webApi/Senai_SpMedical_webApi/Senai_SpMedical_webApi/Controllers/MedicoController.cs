using Microsoft.AspNetCore.Mvc;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using Senai_SpMedical_webApi.Repositories;

namespace Senai_SpMedical_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    //Controler Responsavel pelo CRUD de Medicos
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _MedicoRepository { get; set; }

        public MedicoController()
        {
            _MedicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Método responsavel por listar todos os médicos
        /// </summary>
        /// <returns>Uma lista de médicos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_MedicoRepository.Listar());
        }

        /// <summary>
        /// Método responsavel por buscar um médico por um id especifico
        /// </summary>
        /// <param name="id">Id do médico a ser buscado</param>
        /// <returns>Medico encontrado</returns>
        [HttpGet ("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_MedicoRepository.Buscar(id));
        }

        /// <summary>
        /// Método responsavel por cadastrar um novo médico
        /// </summary>
        /// <param name="MedicoNovo">Objeto do tipo Médico a ser cadastrado</param>
        [HttpPost]
        public IActionResult Cadastrar(Medico MedicoNovo)
        {
            _MedicoRepository.Cadastrar(MedicoNovo);

            return StatusCode(201);
        }

        /// <summary>
        /// Método responsavel pela atualização de algum cadastro de médico
        /// </summary>
        /// <param name="MedicoAtualizado">Dados Atualizados</param>
        /// <param name="id">Id do médico a ser atualizado</param>
        [HttpPut ("{id}")]
        public IActionResult Atualizar(Medico MedicoAtualizado, int id)
        {
            _MedicoRepository.Atualizar(MedicoAtualizado, id);

            return StatusCode(204);
        }

        /// <summary>
        /// Método responsavel por deletar um médico
        /// </summary>
        /// <param name="id">Id do médico a ser deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _MedicoRepository.Deletar(id);

            return StatusCode(203);
        }
    }
}
