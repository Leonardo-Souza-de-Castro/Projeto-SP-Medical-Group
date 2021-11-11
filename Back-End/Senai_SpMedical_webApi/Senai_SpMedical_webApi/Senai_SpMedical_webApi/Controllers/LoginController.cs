using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using Senai_SpMedical_webApi.Repositories;
using Senai_SpMedical_webApi.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_SpMedical_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    //Controller Responsavel pelo método de login da aplicação
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método responsavel por fazer login no sistema
        /// </summary>
        /// <param name="login">Objeto do tipo Login com Email e Senha</param>
        /// <returns>Usuario com esse email e senha</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario UsuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (UsuarioBuscado != null)
                {
                    var MinhasClains = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipo.ToString()),
                        new Claim ("role", UsuarioBuscado.IdTipo.ToString())
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SpMeDIcalGrouPE-chave-AUTENTICACAO"));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var meuToken = new JwtSecurityToken(
                        issuer: "SpMedical_webApi",
                        audience: "SpMedical_webApi",
                        claims: MinhasClains,
                        expires: DateTime.Now.AddHours(3),
                        signingCredentials: creds
                        );

                    return Ok(new {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                        });
                }

                return BadRequest("Email ou Senha Invalidos!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
