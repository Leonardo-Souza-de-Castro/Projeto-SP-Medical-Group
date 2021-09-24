using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdMedico { get; set; }
        public int? IdEspecialidade { get; set; }
        public int? IdTipo { get; set; }
        public int? IdClinica { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public string Email { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual TipoUsuario IdTipoNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
