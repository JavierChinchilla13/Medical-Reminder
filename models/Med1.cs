using System;
using System.Collections.Generic;

namespace ProyectoMedicamento.Models
{
    public partial class Med1
    {
        public string NameM { get; set; } = null!;
        public string TypeM { get; set; } = null!;
        public string ScheduleM { get; set; } = null!;
        public int DoseM { get; set; }
        public string DateM { get; set; } = null!;
    }
}
