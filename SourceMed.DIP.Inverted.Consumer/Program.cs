using System;
using SourceMed.DIP.Inverted.Demo;

namespace SourceMed.DIP.Inverted.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ScheduleFacade facade = new ScheduleFacade();

            var patientId = Guid.NewGuid();
            facade.AddPatient(new SurgeryPatient() { AppointmentDate = DateTime.Now, FirstName = "Matthew", LastName = "Knudsen", Id = patientId });

            var patient = facade.GetPatient(patientId.ToString());

        }
    }
}
