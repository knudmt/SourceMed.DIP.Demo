using System;

namespace SourceMed.DIP
{
    public class SurgeryPatient
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public DateTime AppointmentDate { get; set; }
    }
}
