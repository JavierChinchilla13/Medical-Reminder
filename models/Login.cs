using System;
using System.Collections.Generic;

namespace ProyectoMedicamento.Models
{
    public partial class Login
    {
        public string Users { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public int Edad { get; set; }
    }
}
