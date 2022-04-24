using ApiMedication.Models;

namespace ApiMedication.MedicationData
{
    public interface IMedicationData
    {
        List<Medication> GetMedications(MedicationParams medicationParams);
        Medication GetMedicationById(Guid id);
        Medication AddMedication(Medication medication);
        void DeleteMedication(Medication medication);
    }
}
