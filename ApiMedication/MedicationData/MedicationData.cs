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
            medication.Id = Guid.NewGuid();
            medication.CreatedDate = DateTime.Now;
            _context.Medication.Add(medication);
            _context.SaveChanges();
            return medication;
        }

        public void DeleteMedication(Medication medication)
        {
            _context.Medication.Remove(medication);
            _context.SaveChanges();
        }

        public Medication GetMedicationById(Guid id)
        {
            return _context.Medication.Find(id);
        }

        public List<Medication> GetMedications(MedicationParams medicationParams)
        {
            return _context.Medication.OrderBy(on => on.Name)
                .Skip((medicationParams.PageNumer - 1) * medicationParams.PageSize)
                .Take(medicationParams.PageSize)
                .ToList();
        }
    }
}
