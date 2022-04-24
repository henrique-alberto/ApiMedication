using ApiMedication.MedicationData;
using ApiMedication.Models;
using System;

namespace TestMedication
{
    public class DbTestMock
    {
        public DbTestMock()
        {
        }

        public void Seed(MedicationDbContext context)
        {

            context.Medication.Add(
                new Medication {Id = Guid.NewGuid(), Name = "Medication 1", Quantity = 3, CreatedDate = DateTime.Now });

            context.Medication.Add(
                new Medication { Id = Guid.NewGuid(), Name = "Medication 2", Quantity = 10, CreatedDate = DateTime.Now });

            context.Medication.Add(
                new Medication { Id = Guid.NewGuid(), Name = "Medication 3", Quantity = 13, CreatedDate = DateTime.Now });
        }

    }
}
