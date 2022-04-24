using ApiMedication.Dto;
using ApiMedication.MedicationData;
using ApiMedication.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApiMedication.Controllers
{
    [Route("api/medication")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    public class MedicationController : ControllerBase
    {
        private IMedicationData _medicationData;
        private IMapper _mapper;

        public MedicationController(IMedicationData medicationData, IMapper mapper)
        {
            _medicationData = medicationData;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMedications([FromQuery]MedicationParams medicationParams)
        {
            try
            {
                return Ok(_medicationData.GetMedications(medicationParams));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("/{id}")]
        public IActionResult GetMedicationById(Guid id)
        {
            try
            {
                Medication medication = _medicationData.GetMedicationById(id);
                
                if (medication != null)
                {
                    return Ok(medication);
                }
                
                return NotFound($"Medication with Id: {id} was not found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddMedication([FromBody]MedicationCreateDto dto)
        {
            try
            {
                Medication medication = _mapper.Map<Medication>(dto);
                _medicationData.AddMedication(medication);
                return CreatedAtAction(nameof(GetMedicationById), new { id = medication.Id}, medication);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("/{id}")]
        public IActionResult DeleteMedication(Guid id)
        {
            try
            {
                Medication medication = _medicationData.GetMedicationById(id);
                if (medication != null)
                {
                    _medicationData.DeleteMedication(medication);
                    return NoContent();
                }
                return NotFound($"Medication with Id: {id} was not found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
