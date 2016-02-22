using System;
using System.Collections.Generic;

namespace SourceMed.DIP.Storage
{
    public class SurgeryPatientStore
    {
        private Dictionary<Guid, SurgeryPatient> _sugeryPatients;

        public SurgeryPatientStore()
        {
            _sugeryPatients = new Dictionary<Guid, SurgeryPatient>();
        }

        public void AddPatient(SurgeryPatient patient)
        {
            if (!_sugeryPatients.ContainsKey(patient.Id))
            {
                _sugeryPatients.Add(patient.Id, patient);
            }
            else
            {
                throw new Exception("Patient already exists");
            }
        }

        public void DeletePatient(string id)
        {
            if (_sugeryPatients.ContainsKey(new Guid(id)))
            {
                _sugeryPatients.Remove(new Guid(id));
            }
            else
            {
                throw new Exception("The patient does not exist");
            }
        }

        public void UpdatePatient(SurgeryPatient patient)
        {
            if (_sugeryPatients.ContainsKey(patient.Id))
            {
                _sugeryPatients[patient.Id] = patient;
            }
            else
            {
                throw new Exception("The patient does not exist");
            }
        }

        public SurgeryPatient GetPatient(string id)
        {
            if (_sugeryPatients.ContainsKey(new Guid(id)))
            {
                return _sugeryPatients[new Guid(id)];
            }
            else
            {
                return null;
            }
        }
    }
}
