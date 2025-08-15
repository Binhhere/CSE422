namespace Domain.Entities;

public class Loan
{
    public string BookId { get; set; }
    public string ReaderId { get; set; }
    public DateTime BorrowDate { get; set; } = DateTime.Now;
    public DateTime? ReturnDate { get; set; }
}
