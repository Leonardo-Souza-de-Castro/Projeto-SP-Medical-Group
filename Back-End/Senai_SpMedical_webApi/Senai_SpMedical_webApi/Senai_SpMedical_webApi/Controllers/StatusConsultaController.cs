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

    // COntroller Respopnsavel pelo CRUD de StatusConsulta
    public class StatusConsultaController : ControllerBase
    {
        private IStatusConsultaRepository _StatusConsultaRepository { get; set; }

        public StatusConsultaController()
        {
            _StatusConsultaRepository = new StatusConsultaRepository();
        }

        /// <summary>
        /// Listar todas as StatusConsultas
        /// </summary>
        /// <returns>Uma lista de StatusConsultas</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_StatusConsultaRepository.Listar());
        }

        /// <summary>
        /// Busca um StatusConsulta especifica
        /// </summary>
        /// <param name="id">Id do StatusConsulta buscado</param>
        /// <returns>O StatusConsulta com aquele Id</returns>
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_StatusConsultaRepository.Buscar(id));
        }

        /// <summary>
        /// Cadastrar um novo StatusConsulta
        /// </summary>
        /// <param name="StatusNovo">Dados a serem cadastrados</param>
        [HttpPost]
        public IActionResult Cadastrar(StatusConsulta StatusNovo)
        {
            _StatusConsultaRepository.Cadastrar(StatusNovo);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar um StatusConsulta existente
        /// </summary>
        /// <param name="StatusAtualizado">Dados Atualizados</param>
        /// <param name="id">Id do StatusConsulta a ser atualizada</param>
        [HttpPut("{id}")]
        public IActionResult Atualizar(StatusConsulta StatusAtualizado, int id)
        {
            _StatusConsultaRepository.Atualizar(StatusAtualizado, id);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar um StatusConsulta
        /// </summary>
        /// <param name="id">Id do StatusConsulta a ser deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _StatusConsultaRepository.Deletar(id);

            return StatusCode(203);
        }
    }
}
