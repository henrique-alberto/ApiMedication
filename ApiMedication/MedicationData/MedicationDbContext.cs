using ApiMedication.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMedication.MedicationData
{
    public class MedicationDbContext : DbContext
    {
        public MedicationDbContext(DbContextOptions<MedicationDbContext> dbContext)
            : base(dbContext) {}
        
        public DbSet<Medication> Medication { get; set; }
    }
}
