using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using Senai_SpMedical_webApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Senai_SpMedical_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    //Controller Responsavel pelo CRUD e os métodos adicionais das Consultas
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _ConsultaRepository { get; set; }

        public ConsultaController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Listar todas as Consultas
        /// </summary>
        /// <returns>Uma lista de Consultas</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_ConsultaRepository.Listar());
        }

        /// <summary>
        /// Busca uma Consulta especifica
        /// </summary>
        /// <param name="id">Id da Consulta buscada</param>
        /// <returns>A Consulta com aquele Id</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_ConsultaRepository.Buscar(id));
        }

        /// <summary>
        /// Cadastrar uma nova Consulta
        /// </summary>
        /// <param name="ConsultaNova">Dados a serem cadastrados</param>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastar(Consulta ConsultaNova)
        {
            _ConsultaRepository.Cadastrar(ConsultaNova);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar uma Consulta existente
        /// </summary>
        /// <param name="ConsultaAtualizada">Dados Atualizados</param>
        /// <param name="id">Id da Consulta a ser atualizada</param>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Consulta ConsultaAtualizada, int id)
        {
            _ConsultaRepository.Atualizar(ConsultaAtualizada, id);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar uma Consulta
        /// </summary>
        /// <param name="id">Id da Consulta a ser deletada</param>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _ConsultaRepository.Deletar(id);

            return StatusCode(203);
        }

        /// <summary>
        /// Atualizar o Status de uma consulta
        /// </summary>
        /// <param name="id">Id da consulta a ser atualizada</param>
        /// <param name="status">Novo status da consulta</param>
        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult AtualizarStatus(int id, Consulta status)
        {
            try
            {
                _ConsultaRepository.AtualizarStatus(id, status.IdStatus.ToString());

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Listar todas as consultas de um Médico especifico
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpGet("Medico")]
        public IActionResult ListarSomenteMedico()
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(_ConsultaRepository.ListarSomenteMedico(id));
        }

        /// <summary>
        /// Listar todas as consultas de um Paciente especifico
        /// </summary>
        /// <returns>A lista de consultas desse paciente</returns>
        [Authorize(Roles = "3")]
        [HttpGet("Paciente")]
        public IActionResult ListarSomentePaciente()
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(_ConsultaRepository.ListarSomentePaciente(id));
        }
    }
}
