using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    //Controler Responsavel pela publicação e Consulta de imagens publicadas
    [Authorize]
    public class PerfilController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public PerfilController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método responsavel por publicar as imagens do tipo jpg ou png
        /// </summary>
        /// <param name="foto"> A foto a ser publicada</param>
        [HttpPost("imagem")]
        public IActionResult PublicarFoto(IFormFile foto)
        {
            try
            {
                if (foto.Length > 5000)
                {
                    return BadRequest(new  { mensagem = "O Tamanho do arquivo excedeu o limite, tente novamente com um arquivo mais leve" });
                }

                string extensao = foto.FileName.Split('.').Last();

                if (extensao == "png")
                {
                    int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                    _UsuarioRepository.SalvarPerfilDirPNG(foto, IdUsuario);

                    return Ok();
                }
                else if (extensao == "jpg")
                {
                    int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                    _UsuarioRepository.SalvarPerfilDirJPG(foto, IdUsuario);

                    return Ok();
                }

                return BadRequest(new { mensagem = "Formato de imagem invalido"});

                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método Responsavel por Mostrar a fotos publicadas por um usuario
        /// </summary>
        /// <returns>A foto publicada</returns>
        [HttpGet("Imagem")]
        public IActionResult VerFoto()
        {
            try
            {
               int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _UsuarioRepository.ConsultarPerfilDir(IdUsuario);

                return Ok(base64);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
