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
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_PacienteRepository.Buscar(id));
        }

        /// <summary>
        /// Cadastrar novos pacientes
        /// </summary>
        /// <param name="PacienteNovo">Dados a serem cadastrados</param>
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
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _PacienteRepository.Deletar(id);

            return StatusCode(203);
        }
    }
}
