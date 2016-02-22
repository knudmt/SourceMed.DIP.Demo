using System;
using SourceMed.DIP.Storage;

namespace SourceMed.DIP.Engines
{
    public class TherapyScheduleEngine
    {
        private TherapyPatientStore _patientStore;

        public TherapyScheduleEngine()
        {
            _patientStore = new TherapyPatientStore();
        }

        public void AddPatient(TherapyPatient patient)
        {
            if (patient == null || string.IsNullOrEmpty(patient.FirstName) || string.IsNullOrEmpty(patient.LastName))
            {
                throw new ArgumentNullException("you must provide a first and last name");
            }

            _patientStore.AddPatient(patient);
        }

        public TherapyPatient GetPatient(string id)
        {
            return _patientStore.GetPatient(id);
        }

        public void DeletePatient(string id)
        {
            _patientStore.DeletePatient(id);
        }

        public void UpdatePatient(TherapyPatient patient)
        {
            _patientStore.UpdatePatient(patient);
        }
    }
}
