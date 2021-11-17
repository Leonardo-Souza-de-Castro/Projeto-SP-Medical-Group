using Microsoft.AspNetCore.Http;
using Senai_SpMedical_webApi.Contexts;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Senai_SpMedical_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SPContext ctx = new SPContext();

        public void Atualizar(Usuario Usuarioatualizado, int id)
        {
            Usuario UsuarioBuscado = Buscar(id);

            if (Usuarioatualizado.Email != null)
            {
                UsuarioBuscado.Email = Usuarioatualizado.Email;
            }
            if (Usuarioatualizado.Senha != null)
            {
                UsuarioBuscado.Senha = Usuarioatualizado.Senha;
            }
            if (Usuarioatualizado.IdTipo != null)
            {
                UsuarioBuscado.IdTipo = Usuarioatualizado.IdTipo;
            }
        }

        public Usuario Buscar(int id)
        {
            return ctx.Usuarios
                .Select(U => new Usuario()
                {
                    Email = U.Email,
                    IdTipoNavigation = new TipoUsuario()
                    {
                        NomeTipo = U.IdTipoNavigation.NomeTipo
                    }
                })
                .FirstOrDefault(U => U.IdUsuario == id);
        }

        public void Cadastrar(Usuario Usuarionovo)
        {
            ctx.Usuarios.Add(Usuarionovo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario UsuarioBuscado = Buscar(id);

            ctx.Usuarios.Remove(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios
                .Select(U => new Usuario()
                {
                    Email = U.Email,
                    IdTipoNavigation = new TipoUsuario()
                    {
                        NomeTipo = U.IdTipoNavigation.NomeTipo
                    }
                })
                .ToList();
        }

        public Usuario Login(string Email, string Senha)
        {
            return ctx.Usuarios.FirstOrDefault(U => U.Email == Email && U.Senha == Senha);
        }

        public string ConsultarPerfilDir(int id_usuario)
        {
            string nome_imagem = id_usuario.ToString() + ".png";
            string caminho = Path.Combine("Perfil", nome_imagem);

            string nome_imagem_jpg = id_usuario.ToString() + ".jpg";
            string caminho_jpg = Path.Combine("Perfil", nome_imagem_jpg);

            //Esse primeiro if ve se a imagem é do tipo png e se for mostra ela
            if (File.Exists(caminho))
            {
                byte[] byteArquivos = File.ReadAllBytes(caminho);

                return Convert.ToBase64String(byteArquivos);
            }

            //Esse else if ve se a imagem é do tipo jpg e se for mostra ela
            else if (File.Exists(caminho_jpg))
            {
                byte[] byteArquivos = File.ReadAllBytes(caminho_jpg);

                return Convert.ToBase64String(byteArquivos);
            }

            //Caso não seja de nenhum destes tipos retorna nulo
            return null;
        }

        public void SalvarPerfilDirPNG(IFormFile foto, int id_usuario)
        {
            string nome_foto = id_usuario.ToString() + ".png";

            using (var stream = new FileStream(Path.Combine("Perfil", nome_foto), FileMode.Create))
            {
                foto.CopyTo(stream);
            }
        }

        public void SalvarPerfilDirJPG(IFormFile foto, int id_usuario)
        {
            string nome_foto = id_usuario.ToString() + ".jpg";

            using (var stream = new FileStream(Path.Combine("Perfil", nome_foto), FileMode.Create))
            {
                foto.CopyTo(stream);
            }
        }
    }
}
