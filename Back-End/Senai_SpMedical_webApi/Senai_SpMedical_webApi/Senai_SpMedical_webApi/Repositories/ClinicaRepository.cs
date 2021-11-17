using Senai_SpMedical_webApi.Contexts;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai_SpMedical_webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {

        SPContext ctx = new SPContext();

        public void Atualizar(Clinica ClinicaAtualizada, int id)
        {
            Clinica clinicabuscada = Buscar(id);

            if (ClinicaAtualizada.Endereco != null)
            {
                clinicabuscada.Endereco = ClinicaAtualizada.Endereco;
            }
            if (ClinicaAtualizada.Cnpj != null)
            {
                clinicabuscada.Cnpj = ClinicaAtualizada.Cnpj;
            }
            if (ClinicaAtualizada.NomeFantasia != null)
            {
                clinicabuscada.NomeFantasia = ClinicaAtualizada.NomeFantasia;
            }
            if (ClinicaAtualizada.HoraAbertura != TimeSpan.Parse("01:01"))
            {
                clinicabuscada.HoraAbertura = ClinicaAtualizada.HoraAbertura;
            }
            if (ClinicaAtualizada.HoraFechamento != TimeSpan.Parse("01:01"))
            {
                clinicabuscada.HoraFechamento = ClinicaAtualizada.HoraFechamento;
            }
            if (ClinicaAtualizada.RazaoSocial != null)
            {
                clinicabuscada.RazaoSocial = ClinicaAtualizada.RazaoSocial;
            }

            ctx.Clinicas.Update(clinicabuscada);

            ctx.SaveChanges();
        }

        public Clinica Buscar(int id)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }

        public void Cadastrar(Clinica ClinicaNova)
        {
            ctx.Clinicas.Add(ClinicaNova);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Clinica Clinicabuscada = Buscar(id);

            ctx.Clinicas.Remove(Clinicabuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
