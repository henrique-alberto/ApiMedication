using System.ComponentModel.DataAnnotations;

namespace ApiMedication.Dto
{
    public class MedicationCreateDto
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100, ErrorMessage = "Name can only be 100 charecteres long", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity is required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Quantity { get; set; }
    }
}
