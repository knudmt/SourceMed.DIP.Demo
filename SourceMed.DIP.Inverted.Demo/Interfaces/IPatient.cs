using System;

namespace SourceMed.DIP.Inverted.Demo.Interfaces
{
    public interface IPatient
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        DateTime AppointmentDate { get; set; }

        Guid Id { get; set; }
    }
}
