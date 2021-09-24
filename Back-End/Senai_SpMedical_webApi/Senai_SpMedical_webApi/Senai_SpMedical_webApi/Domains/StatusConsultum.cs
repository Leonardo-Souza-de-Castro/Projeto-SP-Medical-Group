﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webApi.Domains
{
    public partial class StatusConsultum
    {
        public StatusConsultum()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdStatus { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}