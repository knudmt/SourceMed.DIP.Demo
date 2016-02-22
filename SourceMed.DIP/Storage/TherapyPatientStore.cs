using System;
using System.Collections.Generic;

namespace SourceMed.DIP.Storage
{
    public class TherapyPatientStore
    {
        private Dictionary<Guid, TherapyPatient> _therapyPatients;

        public TherapyPatientStore()
        {
            _therapyPatients = new Dictionary<Guid, TherapyPatient>();
        }

        public bool AddPatient(TherapyPatient patient)
        {
            if (!_therapyPatients.ContainsKey(patient.Id))
            {
                _therapyPatients.Add(patient.Id, patient);
                return true;
            }
            else
            {
                return false;
            }
        }

        public TherapyPatient GetPatient(string id)
        {
            if (_therapyPatients.ContainsKey(new Guid(id)))
            {
                return _therapyPatients[new Guid(id)];
            }
            else
            {
                return null;
            }
        }

        public bool DeletePatient(string id)
        {
            if (_therapyPatients.ContainsKey(new Guid(id)))
            {
                _therapyPatients.Remove(new Guid(id));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePatient(TherapyPatient patient)
        {
            if (_therapyPatients.ContainsKey(patient.Id))
            {
                _therapyPatients[patient.Id] = patient;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
