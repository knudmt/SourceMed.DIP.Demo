using Microsoft.Practices.Unity;
using SourceMed.DIP.Inverted.Demo.Interfaces;
using SourceMed.DIP.Inverted.Demo.Storage;

namespace SourceMed.DIP.Inverted.Demo
{
    public class ScheduleFacade
    {
        private ScheduleEngine _engine;
        public ScheduleFacade()
        {
            var unityContainer = new UnityContainer();
            
            _engine = new ScheduleEngine(unityContainer.Resolve<PatientStore>());
        }

        public void AddPatient(IPatient patient)
        {
            _engine.AddPatient(patient);
        }

        public void DeletePatient(string id)
        {
            _engine.DeletePatient(id);
        }

        public void UpdatePatient(IPatient patient)
        {
            _engine.UpdatePatient(patient);
        }

        public IPatient GetPatient(string id)
        {
            return _engine.GetPatient(id);
        }
    }
}
