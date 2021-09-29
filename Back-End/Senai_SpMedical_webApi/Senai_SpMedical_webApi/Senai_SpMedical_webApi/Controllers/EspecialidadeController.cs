using Microsoft.AspNetCore.Mvc;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using Senai_SpMedical_webApi.Repositories;

namespace Senai_SpMedical_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    
    // Controler Responsavel pelo CRUD de Especialidades
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _EspecialidadeRepository { get; set; }
        public EspecialidadeController()
        {
            _EspecialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Listar todas as especialidades
        /// </summary>
        /// <returns>Uma lista de Especialidades</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_EspecialidadeRepository.Listar());
        }

        /// <summary>
        /// Busca uma especialidade especifica
        /// </summary>
        /// <param name="id">Id da Especialidade buscada</param>
        /// <returns>A Especialidade com aquele Id</returns>
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_EspecialidadeRepository.Buscar(id));
        }
        /// <summary>
        /// Cadastrar uma nova especialidade
        /// </summary>
        /// <param name="EspecialidadeNova">Dados a serem cadastrados</param>
        [HttpPost]
        public IActionResult Cadastrar(Especialidade EspecialidadeNova)
        {
            _EspecialidadeRepository.Cadastrar(EspecialidadeNova);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar uma especialidade existente
        /// </summary>
        /// <param name="EspecialidadeAtualizada">Dados Atualizados</param>
        /// <param name="id">Id da Especialidade a ser atualizada</param>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Especialidade EspecialidadeAtualizada, int id)
        {
            _EspecialidadeRepository.Atualizar(EspecialidadeAtualizada, id);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar uma Especialidade
        /// </summary>
        /// <param name="id">Id da especialidade a ser deletada</param>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _EspecialidadeRepository.Deletar(id);

            return StatusCode(203);
        }
    }
}
