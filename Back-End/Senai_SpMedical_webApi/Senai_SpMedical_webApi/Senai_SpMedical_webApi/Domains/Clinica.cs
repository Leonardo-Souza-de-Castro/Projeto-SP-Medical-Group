﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Consulta = new HashSet<Consulta>();
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }
        public string Endereco { get; set; }
        public TimeSpan HoraAbertura { get; set; }
        public TimeSpan HoraFechamento { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
