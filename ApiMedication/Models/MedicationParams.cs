namespace ApiMedication.Models
{
    public class MedicationParams
    {
        public int maxPageSize = 50;
        public int PageNumer { get; set; }
        public int _pageSize = 10;

        public int PageSize 
        {
            get 
            { 
                return _pageSize; 
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
