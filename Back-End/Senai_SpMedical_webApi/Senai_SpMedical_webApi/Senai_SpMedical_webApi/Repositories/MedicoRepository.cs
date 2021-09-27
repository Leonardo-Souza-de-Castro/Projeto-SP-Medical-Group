using Senai_SpMedical_webApi.Context;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SpMedical_webApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {

        SPContext ctx = new SPContext();

        public void Atualizar(Medico medicoatualizado, int id)
        {
            Medico MedicoBuscado = Buscar(id);

            if (medicoatualizado.Nome != null)
            {
                MedicoBuscado.Nome = medicoatualizado.Nome;
            }
        }

        public Medico Buscar(int id)
        {
            return ctx.Medicos.FirstOrDefault(M => M.IdMedico == id);
        }

        public void Cadastrar(Medico mediconovo)
        {
            ctx.Medicos.Add(mediconovo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Medico MedicoBuscado = Buscar(id);

            ctx.Medicos.Remove(MedicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }
    }
}
