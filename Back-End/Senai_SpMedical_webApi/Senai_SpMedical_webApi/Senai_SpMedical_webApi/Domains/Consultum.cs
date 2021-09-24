﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webApi.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public int? IdProntuario { get; set; }
        public int? IdMedico { get; set; }
        public int? IdStatus { get; set; }
        public int? IdClinica { get; set; }
        public DateTime DataConsulta { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdProntuarioNavigation { get; set; }
        public virtual StatusConsultum IdStatusNavigation { get; set; }
    }
}
