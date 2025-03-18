using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoMedicamento.Models
{
    public partial class Log
    {
        public Log()
        {
            LogMeds = new HashSet<LogMed>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; } 
        public string Users { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public int Edad { get; set; }

        public virtual ICollection<LogMed> LogMeds { get; set; }
    }
}
