using Senai_SpMedical_webApi.Context;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SpMedical_webApi.Repositories
{
    public class StatusConsultaRepository : IStatusConsultaRepository
    {
        SPContext ctx = new SPContext();

        public void Atualizar(StatusConsulta StatusAtualizado, int id)
        {
            StatusConsulta StatusBuscado = Buscar(id);

            if (StatusAtualizado.Descricao != null)
            {
                StatusBuscado.Descricao = StatusAtualizado.Descricao;
            }
        }

        public StatusConsulta Buscar(int id)
        {
            return ctx.StatusConsulta.FirstOrDefault(S => S.IdStatus == id);
        }

        public void Cadastrar(StatusConsulta StatusNova)
        {
            ctx.StatusConsulta.Add(StatusNova);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            StatusConsulta StatusBuscado = Buscar(id);

            ctx.StatusConsulta.Remove(StatusBuscado);

            ctx.SaveChanges();
        }

        public List<StatusConsulta> Listar()
        {
            return ctx.StatusConsulta.ToList();
        }
    }
}
