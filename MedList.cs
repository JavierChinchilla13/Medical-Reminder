using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedicamento
{
    internal class MedList
    {
        private String name;
        private String type;
        private String schedule;
        private String dose;

        public MedList(string name, string type, string schedule, string dose)
        {
            this.name = name;
            this.type = type;
            this.schedule = schedule;
            this.dose = dose;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        public String Schedule
        {
            get { return schedule; }
            set { schedule = value; }
        }
        public String Dose
        {
            get { return dose; }
            set { dose = value; }
        }
    }
}
