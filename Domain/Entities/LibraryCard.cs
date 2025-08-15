namespace Domain.Entities;

public class LibraryCard
{
    public string CardNumber { get; }
    public Reader Owner { get; set; }
    public DateTime IssueDate { get; private set; }

    public LibraryCard(string cardNumber, Reader owner)
    {
        CardNumber = cardNumber;
        Owner = owner;
        IssueDate = DateTime.Now;
    }

    public void RenewCard()
    {
        IssueDate = DateTime.Now;
    }
}
