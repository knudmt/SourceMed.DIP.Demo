using System;
using SourceMed.DIP.Inverted.Demo.Interfaces;

namespace SourceMed.DIP.Contracts
{
    public class TherapyPatient : IPatient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Guid Id { get; set; }
    }
}
