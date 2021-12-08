using Microsoft.EntityFrameworkCore;
using Senai_SpMedical_webApi.Context;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai_SpMedical_webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {

        SPContext ctx = new SPContext();

        public void Atualizar(Consulta ConsultaAtualizada, int id)
        {
            Consulta ConsultaBuscada = Buscar(id);

            ConsultaBuscada.DataConsulta = ConsultaAtualizada.DataConsulta;
            
            if (ConsultaAtualizada.IdMedico != null)
            {
                ConsultaBuscada.IdMedico = ConsultaAtualizada.IdMedico;
            }
            if (ConsultaAtualizada.IdProntuario != null)
            {
                ConsultaBuscada.IdProntuario = ConsultaAtualizada.IdProntuario;
            }
            if (ConsultaAtualizada.Descricao != null)
            {
                ConsultaBuscada.Descricao = ConsultaAtualizada.Descricao;
            }

            ctx.Consulta.Update(ConsultaBuscada);

            ctx.SaveChanges();
        }

        public void AtualizarStatus(int id, string Status)
        {
            Consulta ConsultaBuscada = Buscar(id);

            switch (Status)
            {
                case "1":
                    ConsultaBuscada.IdStatus = 1;
                    break;
                case "2":
                    ConsultaBuscada.IdStatus = 2;
                    break;
                case "3":
                    ConsultaBuscada.IdStatus = 3;
                    break;
                default:
                    ConsultaBuscada.IdStatus = ConsultaBuscada.IdStatus;
                    break;
            }

            ctx.Consulta.Update(ConsultaBuscada);

            ctx.SaveChanges();
        }

        public Consulta Buscar(int id)
        {
            return ctx.Consulta.Include(C => C.IdMedicoNavigation).Include(C => C.IdProntuarioNavigation).Include(C => C.IdStatusNavigation).FirstOrDefault(C => C.IdConsulta == id);
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
            return ctx.Consulta.Include(C => C.IdMedicoNavigation).Include(C => C.IdProntuarioNavigation).Include(C => C.IdStatusNavigation).Include(C => C.IdMedicoNavigation.IdEspecialidadeNavigation).ToList();
        }

        public List<Consulta> ListarSomenteMedico(int id)
        {
            return ctx.Consulta.Include(C => C.IdMedicoNavigation).Include(C => C.IdProntuarioNavigation).Include(C => C.IdStatusNavigation).Where(M => M.IdMedico == id).ToList();
        }

        public List<Consulta> ListarSomentePaciente(int id)
        {
            //return ctx.Consulta.Include(c => c.IdMedicoNavigation.IdClinicaNavigation).ToList();
            return ctx.Consulta.Include(C => C.IdMedicoNavigation.IdEspecialidadeNavigation).Include(C => C.IdMedicoNavigation.IdClinicaNavigation).Include(C => C.IdProntuarioNavigation).Include(C => C.IdStatusNavigation).Where(P => P.IdProntuario == id).ToList();
        }

        public void AtualizarDescricao(int id, string descricao)
        {
            Consulta ConsultaBuscada = Buscar(id);

            ConsultaBuscada.Descricao = descricao;

            ctx.Consulta.Update(ConsultaBuscada);

            ctx.SaveChanges();
        }
    }
}
