using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int? IdProntuario { get; set; }
        public int? IdMedico { get; set; }
        public int? IdStatus { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdProntuarioNavigation { get; set; }
        public virtual StatusConsulta IdStatusNavigation { get; set; }
    }
}
