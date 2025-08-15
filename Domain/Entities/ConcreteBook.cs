using Domain.Interfaces;

namespace Domain.Entities
{
    public class ConcreteBook : Book, IDocument
    {
        public string Type { get; set; } = "Book";
        public DateTime PublicationDate { get; set; }

        public IDocument Clone()
        {
            return (IDocument)this.MemberwiseClone();
        }
    }
}
