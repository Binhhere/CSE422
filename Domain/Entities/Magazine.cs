using Domain.Interfaces;

namespace Domain.Entities
{
    public class Magazine : IDocument
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; } = "Magazine";
        public DateTime PublicationDate { get; set; }

        public IDocument Clone() => (IDocument)this.MemberwiseClone();
    }
}
