using System;
using System.Collections.Generic;
using SourceMed.DIP.Inverted.Demo.Interfaces;

namespace SourceMed.DIP.Inverted.Demo.Storage
{
    internal class PatientStore : IPatientStore
    {
        private readonly Dictionary<Guid, IPatient> _patients;

        public PatientStore()
        {
            _patients = new Dictionary<Guid, IPatient>();
        } 

        public bool CreateNewPatient(IPatient patient)
        {
            if (PatientExists(patient.Id))
            {
                return false;
            }
            else
            {
                _patients.Add(patient.Id, patient);
                return true;
            }
        }

        public bool DeletePatient(string patientId)
        {
            if (PatientExists(new Guid(patientId)))
            {
                _patients.Remove(new Guid(patientId));
                return true;
            }
            return false;
        }

        public bool UpdatePatient(IPatient patient)
        {
            if (!PatientExists(patient.Id))
            {
                return false;
            }
            _patients[patient.Id] = patient;
            return true;
        }

        public IPatient GetPatient(string patientId)
        {
            if (PatientExists(new Guid(patientId)))
            {
                return _patients[new Guid(patientId)];
            }
            else
            {
                throw new KeyNotFoundException("Patient not found");
            }
        }

        private bool PatientExists(Guid key)
        {
            if (_patients.ContainsKey(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
