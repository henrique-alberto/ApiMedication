using ApiMedication.Models;
using AutoMapper;

namespace ApiMedication.Dto.Mappings
{
    public class MedicationMapping : Profile
    {
        public MedicationMapping()
        {
            CreateMap<Medication, MedicationCreateDto>().ReverseMap();
        }
    }
}
