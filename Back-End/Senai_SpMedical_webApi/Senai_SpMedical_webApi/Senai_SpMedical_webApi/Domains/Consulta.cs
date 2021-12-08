using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SpMedical_webApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        [Required(ErrorMessage = "O campo Paciente é obrigatório!")]
        public int? IdProntuario { get; set; }
        [Required(ErrorMessage = "O campo Medico é obrigatório!")]
        public int? IdMedico { get; set; }
        public int? IdStatus { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdProntuarioNavigation { get; set; }
        public virtual StatusConsulta IdStatusNavigation { get; set; }
    }
}
