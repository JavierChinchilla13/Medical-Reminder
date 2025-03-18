using System;
using System.Collections.Generic;

namespace ProyectoMedicamento.Models
{
    public partial class LogMed
    {
        public int Id { get; set; }
        public int IdLog { get; set; }
        public int IdMed { get; set; }

        public virtual Log IdLogNavigation { get; set; } = null!;
        public virtual Med IdMedNavigation { get; set; } = null!;
    }
}
