using Senai_SpMedical_webApi.Context;
using Senai_SpMedical_webApi.Domains;
using Senai_SpMedical_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai_SpMedical_webApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SPContext ctx = new SPContext();

        public void Atualizar(Especialidade EspeAtualizada, int id)
        {
            Especialidade Especialidadebuscada = Buscar(id);

            if (EspeAtualizada.NomeEspecialidade != null)
            {
                Especialidadebuscada.NomeEspecialidade = EspeAtualizada.NomeEspecialidade;
            }

            ctx.Especialidades.Update(Especialidadebuscada);

            ctx.SaveChanges();
        }

        public Especialidade Buscar(int id)
        {
            return ctx.Especialidades.FirstOrDefault(E => E.IdEspecialidade == id);
        }

        public void Cadastrar(Especialidade EspeNova)
        {
            ctx.Especialidades.Add(EspeNova);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Especialidade Especialidadebuscada = Buscar(id);

            ctx.Especialidades.Remove(Especialidadebuscada);

            ctx.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return ctx.Especialidades.ToList();
        }
    }
}
