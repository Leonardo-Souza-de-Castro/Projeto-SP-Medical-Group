using Senai_SpMedical_webApi.Context;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SpMedical_webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {

        SPContext ctx = new SPContext();

        public void Atualizar(Clinica ClinicaAtualizada, int id)
        {
            Clinica clinicabuscada = Buscar(id);

            if (clinicabuscada.Endereco != null)
            {
                clinicabuscada.Endereco = ClinicaAtualizada.Endereco;
            }
            else if (clinicabuscada.Cnpj != null)
            {
                clinicabuscada.Cnpj = ClinicaAtualizada.Cnpj;
            }
            else if (clinicabuscada.NomeFantasia != null)
            {
                clinicabuscada.NomeFantasia = ClinicaAtualizada.NomeFantasia;
            }
            else if (clinicabuscada.HoraAbertura != TimeSpan.Parse("01:01"))
            {
                clinicabuscada.HoraAbertura = ClinicaAtualizada.HoraAbertura;
            }
            else if (clinicabuscada.HoraFechamento != TimeSpan.Parse("01:01"))
            {
                clinicabuscada.HoraFechamento = ClinicaAtualizada.HoraFechamento;
            }
            else if (clinicabuscada.RazaoSocial != null)
            {
                clinicabuscada.RazaoSocial = ClinicaAtualizada.RazaoSocial;
            }
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
