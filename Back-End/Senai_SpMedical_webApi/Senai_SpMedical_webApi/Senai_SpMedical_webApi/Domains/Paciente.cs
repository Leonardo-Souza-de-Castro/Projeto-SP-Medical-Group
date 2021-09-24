using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdProntuario { get; set; }
        public int? IdTipo { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public virtual TipoUsuario IdTipoNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
