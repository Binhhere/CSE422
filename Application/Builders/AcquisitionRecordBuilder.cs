using Domain.Entities;

namespace Application.Builders
{
    public class AcquisitionRecordBuilder
    {
        private AcquisitionRecord _record = new();

        public AcquisitionRecordBuilder SetSupplier(string supplier)
        {
            _record.Supplier = supplier;
            return this;
        }

        public AcquisitionRecordBuilder SetDate(DateTime date)
        {
            _record.AcquisitionDate = date;
            return this;
        }

        public AcquisitionRecordBuilder SetPrice(decimal price)
        {
            if (price < 0) throw new ArgumentException("Price must be positive");
            _record.Price = price;
            return this;
        }

        public AcquisitionRecord Build()
        {
            if (string.IsNullOrWhiteSpace(_record.Supplier)) throw new Exception("Supplier is required");
            return _record;
        }
    }
}
