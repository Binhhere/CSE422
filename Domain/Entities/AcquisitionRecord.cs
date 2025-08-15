namespace Domain.Entities
{
    public class AcquisitionRecord
    {
        public string Supplier { get; set; } = "";
        public DateTime AcquisitionDate { get; set; } = DateTime.Now;
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Supplier: {Supplier}, Date: {AcquisitionDate:yyyy-MM-dd}, Price: {Price:C}";
        }
    }
}
