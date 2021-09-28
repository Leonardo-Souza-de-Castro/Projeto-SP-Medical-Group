using Microsoft.EntityFrameworkCore;
using Senai_SpMedical_webApi.Context;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SpMedical_webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {

        SPContext ctx = new SPContext();

        public void Atualizar(Consulta ConsultaAtualizada, int id)
        {
            Consulta ConsultaBuscada = Buscar(id);

            if (ConsultaAtualizada.DataConsulta != Convert.ToDateTime(01-01-0001))
            {
                ConsultaBuscada.DataConsulta = ConsultaAtualizada.DataConsulta;
            }
            if (ConsultaAtualizada.IdMedico != null)
            {
                ConsultaBuscada.IdMedico = ConsultaAtualizada.IdMedico;
            }
            if (ConsultaBuscada.IdProntuario != null)
            {
                ConsultaBuscada.IdProntuario = ConsultaAtualizada.IdProntuario;
            }
            if (ConsultaAtualizada.IdStatus != null)
            {
                ConsultaBuscada.IdStatus = ConsultaAtualizada.IdStatus;
            }
        }

        public Consulta Buscar(int id)
        {
            return ctx.Consulta.Include(C => C.IdClinicaNavigation).Include(C => C.IdMedicoNavigation).Include(C => C.IdProntuarioNavigation).Include(C => C.IdStatusNavigation).FirstOrDefault(C => C.IdConsulta == id);
        }

        public void Cadastrar(Consulta ConsultaNova)
        {
            ctx.Consulta.Add(ConsultaNova);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consulta ConsultaBuscada = Buscar(id);

            ctx.Consulta.Remove(ConsultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consulta.Include(C => C.IdClinicaNavigation).Include(C => C.IdMedicoNavigation).Include(C => C.IdProntuarioNavigation).Include(C => C.IdStatusNavigation).ToList();
        }

        public List<Consulta> ListarSomenteMedico(int id)
        {
            return ctx.Consulta.Include(C => C.IdClinicaNavigation).Include(C => C.IdMedicoNavigation).Include(C => C.IdProntuarioNavigation).Include(C => C.IdStatusNavigation).Where(M => M.IdMedico == id).ToList();
        }

        public List<Consulta> ListarSomentePaciente(int id)
        {
            return ctx.Consulta.Include(C => C.IdClinicaNavigation).Include(C => C.IdMedicoNavigation).Include(C => C.IdProntuarioNavigation).Include(C => C.IdStatusNavigation).Where(P => P.IdProntuario == id).ToList();
        }
    }
}
