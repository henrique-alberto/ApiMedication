using ApiMedication.Models;

namespace ApiMedication.MedicationData
{
    public class MedicationData : IMedicationData
    {
        private MedicationDbContext _context;

        public MedicationData(MedicationDbContext context)
        {
            _context = context;
        }

        public Medication AddMedication(Medication medication)
        {
            throw new NotImplementedException();
        }

        public void DeleteMedication(Medication medication)
        {
            throw new NotImplementedException();
        }

        public List<Medication> GetMedications()
        {
            throw new NotImplementedException();
        }
    }
}
