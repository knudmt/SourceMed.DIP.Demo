
namespace SourceMed.DIP.Inverted.Demo.Interfaces
{
    public interface IPatientStore
    {
        bool CreateNewPatient(IPatient patient);

        bool DeletePatient(string patientId);

        bool UpdatePatient(IPatient patient);

        IPatient GetPatient(string id);
    }
}
