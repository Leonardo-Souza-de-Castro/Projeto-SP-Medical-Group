using Senai_SpMedical_webApi.Context;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai_SpMedical_webApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SPContext ctx = new SPContext();

        public void Atualizar(Paciente PacienteAtualizado, int id)
        {
            Paciente pacientebuscado = Buscar(id);

            if (PacienteAtualizado.Nome != null)
            {
                pacientebuscado.Nome = PacienteAtualizado.Nome;
            }
            if (PacienteAtualizado.Endereco != null)
            {
                pacientebuscado.Endereco = PacienteAtualizado.Endereco;
            }
            if (PacienteAtualizado.Telefone != null)
            {
                pacientebuscado.Telefone = PacienteAtualizado.Telefone;
            }
            if (PacienteAtualizado.Rg != null)
            {
                pacientebuscado.Rg = PacienteAtualizado.Rg;
            }
            if (PacienteAtualizado.Cpf != null)
            {
                pacientebuscado.Cpf = PacienteAtualizado.Cpf;
            }
            if (PacienteAtualizado.DataNascimento != null)
            {
                pacientebuscado.DataNascimento = PacienteAtualizado.DataNascimento;
            }

            ctx.Pacientes.Update(pacientebuscado);

            ctx.SaveChanges();
        }

        public Paciente Buscar(int id)
        {
            return ctx.Pacientes.FirstOrDefault(P => P.IdProntuario == id);
        }

        public void Cadastrar(Paciente PacienteNovo)
        {
            ctx.Pacientes.Add(PacienteNovo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Paciente pacientebuscado = Buscar(id);

            ctx.Pacientes.Remove(pacientebuscado);

            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
