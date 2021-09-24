using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdTipo { get; set; }
        public string NomeTipo { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
