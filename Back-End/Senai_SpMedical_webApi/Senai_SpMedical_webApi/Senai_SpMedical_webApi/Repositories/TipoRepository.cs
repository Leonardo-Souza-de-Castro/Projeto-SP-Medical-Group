using Senai_SpMedical_webApi.Context;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SpMedical_webApi.Repositories
{
    public class TipoRepository : ITipoRepository
    {
        SPContext ctx = new SPContext();

        public void Atualizar(TipoUsuario TipoAtualizado, int id)
        {
            TipoUsuario TipoBuscado = Buscar(id);

            if (TipoAtualizado.NomeTipo != null)
            {
                TipoBuscado.NomeTipo = TipoAtualizado.NomeTipo;
            }
        }

        public TipoUsuario Buscar(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(T => T.IdTipo == id);
        }

        public void Cadastrar(TipoUsuario TipoNovo)
        {
            ctx.TipoUsuarios.Add(TipoNovo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario TipoBuscado = Buscar(id);

            ctx.TipoUsuarios.Remove(TipoBuscado);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
