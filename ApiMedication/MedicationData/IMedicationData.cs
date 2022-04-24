using ApiMedication.Models;

namespace ApiMedication.MedicationData
{
    public interface IMedicationData
    {
        List<Medication> GetMedications();
        Medication AddMedication(Medication medication);
        void DeleteMedication(Medication medication);
    }
}
