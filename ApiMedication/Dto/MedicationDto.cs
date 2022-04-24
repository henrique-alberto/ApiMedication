namespace ApiMedication.Dto
{
    public class MedicationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
