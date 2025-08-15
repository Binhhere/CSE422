namespace Domain.Interfaces
{
    public interface IDocument
    {
        IDocument Clone(); 
        string Title { get; set; }
        string Author { get; set; }
        string Type { get; set; }
        DateTime PublicationDate { get; set; }
    }
}
