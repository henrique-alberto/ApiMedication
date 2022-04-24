using ApiMedication.Controllers;
using ApiMedication.Dto;
using ApiMedication.Dto.Mappings;
using ApiMedication.MedicationData;
using ApiMedication.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestMedication
{
    public class MedicationControllerTest
    {
        private IMedicationData medicationData;
        private IMapper mapper;
        private MedicationController controller;

        public static DbContextOptions<MedicationDbContext> dbContextOptions { get; }

        public static string connectionString = "Server=localhost;Database=MedicationTestDb;User Id=sa;Password=1q2w3e4r@#$;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;";

        static MedicationControllerTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<MedicationDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public MedicationControllerTest()
        {
            var map = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MedicationMapping());
            });

            mapper = map.CreateMapper();

            var context = new MedicationDbContext(dbContextOptions);

            DbTestMock db = new DbTestMock();
            db.Seed(context);

            medicationData = new MedicationData(context);
            controller = new MedicationController(medicationData, mapper);
        }

        [Fact]
        public void GetMedications_OkResult()
        {
            var data = controller.GetMedications(GetMedicationParams());

            var okObjectResult = data as OkObjectResult;
            Assert.True(okObjectResult.StatusCode.Equals(200));
            Assert.NotNull(okObjectResult.Value as List<Medication>);
        }

        [Fact]
        public void AddMedication_CreatedAtActionResult()
        {
            MedicationCreateDto medication = new MedicationCreateDto();
            medication.Quantity = 1;
            medication.Name = "Teste 10";
            
            var data = controller.AddMedication(medication);
            Assert.True((data as CreatedAtActionResult).StatusCode.Equals(201));
        }

        [Fact]
        public void DeleteMedication_NoContentResult()
        {
            var data = controller.GetMedications(GetMedicationParams());
            var okObjectResult = data as OkObjectResult;
            List<Medication> medications = okObjectResult.Value as List<Medication>;
            var id = medications[0].Id;

            var delete = controller.DeleteMedication(id);
            Assert.True((delete as NoContentResult).StatusCode.Equals(204));
        }

        private MedicationParams GetMedicationParams()
        {
            MedicationParams medicationParams = new MedicationParams();
            medicationParams.PageSize = 10;
            medicationParams.PageNumer = 1;

            return medicationParams;
        }
    }
}
