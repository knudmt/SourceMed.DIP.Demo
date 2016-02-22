using System;
using SourceMed.DIP.Inverted.Demo.Interfaces;

namespace SourceMed.DIP.Inverted.Demo
{
    public class ScheduleEngine
    {
        private readonly IPatientStore _patientStore;
        
        public ScheduleEngine(IPatientStore store)
        {
            _patientStore = store;
        }

        public void AddPatient(IPatient patient)
        {
            if (patient == null || string.IsNullOrEmpty(patient.FirstName) || string.IsNullOrEmpty(patient.LastName))
            {
                throw new ArgumentNullException("You must provide a first name and last name of patient");
            }

            if (!_patientStore.CreateNewPatient(patient))
            {
                throw new Exception("Could not create new patient");
            }
        }

        public void DeletePatient(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("You must provide a patient id");
            }

            if (!_patientStore.DeletePatient(id))
            {
                throw new Exception("Could not delete patient");
            }
        }

        public void UpdatePatient(IPatient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException("You must provide a valid patient object");
            }

            if (!_patientStore.UpdatePatient(patient))
            {
                throw new Exception("Could not update patient");
            }
        }

        public IPatient GetPatient(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("You must provide a patient id");
            }

            try
            {
                return _patientStore.GetPatient(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
