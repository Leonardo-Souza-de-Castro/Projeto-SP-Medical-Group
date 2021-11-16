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

    // Controler Responsavel pelo CRUD de Clinicas
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _ClinicaRepository { get; set; }

        public ClinicaController()
        {
            _ClinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Listar todas as Clinicas
        /// </summary>
        /// <returns>Uma lista de clinicas</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_ClinicaRepository.Listar());
        }

        /// <summary>
        /// Buscar uma clinica por Id
        /// </summary>
        /// <param name="id">Id da clinica buscada</param>
        /// <returns>Clinica com o id buscada</returns>
        [Authorize]
        [HttpGet ("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_ClinicaRepository.Buscar(id));
        }

        /// <summary>
        /// Cadastrar uma nova clinica
        /// </summary>
        /// <param name="ClinicaNova">Dados a serem cadastrados</param>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica ClinicaNova)
        {
            _ClinicaRepository.Cadastrar(ClinicaNova);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar os dados de uma clinica
        /// </summary>
        /// <param name="ClinicaAtualizada">Dados atualizados</param>
        /// <param name="id">Id da clinica a ser atualizada</param>
        [Authorize(Roles = "1")]
        [HttpPut ("{id}")]
        public IActionResult Atualizar(Clinica ClinicaAtualizada, int id)
        {
            _ClinicaRepository.Atualizar(ClinicaAtualizada, id);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar uma clinica existente
        /// </summary>
        /// <param name="id">Id da clinica a ser deletada</param>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _ClinicaRepository.Deletar(id);

            return StatusCode(203);
        }
    }
}
