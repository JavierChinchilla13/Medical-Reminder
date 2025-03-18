using System;
using System.Collections.Generic;

namespace ProyectoMedicamento.Models
{
    public partial class Calendario
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public TimeSpan Schedule { get; set; }
        public int Dose { get; set; }
        public DateTime Date { get; set; }
    }
}
