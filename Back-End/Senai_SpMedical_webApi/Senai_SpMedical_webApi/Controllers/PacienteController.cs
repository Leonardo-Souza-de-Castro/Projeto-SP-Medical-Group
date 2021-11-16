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

    //Controler Responsavel pelo CRUD de Pacientes
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _PacienteRepository { get; set; }
        public PacienteController()
        {
            _PacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Listar todos os pacientes
        /// </summary>
        /// <returns>Uma lista de pacientes</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_PacienteRepository.Listar());
        }

        /// <summary>
        /// Buscar um paciente especifico
        /// </summary>
        /// <param name="id">Id do paciente buscado</param>
        /// <returns>Pacinete com o id buscado</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_PacienteRepository.Buscar(id));
        }

        /// <summary>
        /// Cadastrar novos pacientes
        /// </summary>
        /// <param name="PacienteNovo">Dados a serem cadastrados</param>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Paciente PacienteNovo)
        {
            _PacienteRepository.Cadastrar(PacienteNovo);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar os dados dos pacientes
        /// </summary>
        /// <param name="PacienteAtualizado">Dados atualizados</param>
        /// <param name="id">Id do Paciente a ser atualizado</param>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Paciente PacienteAtualizado, int id)
        {
            _PacienteRepository.Atualizar(PacienteAtualizado,id);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar dados de pacientes
        /// </summary>
        /// <param name="id">Id do Paciente a ser deletado</param>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _PacienteRepository.Deletar(id);

            return StatusCode(203);
        }
    }
}
