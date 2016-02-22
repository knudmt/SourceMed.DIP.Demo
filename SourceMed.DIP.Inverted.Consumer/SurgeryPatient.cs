using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceMed.DIP.Inverted.Demo.Interfaces;

namespace SourceMed.DIP.Inverted.Consumer
{
    public class SurgeryPatient : IPatient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Guid Id { get; set; }
    }
}
