using Domain.Interfaces;

namespace Domain.Entities;

public class Reader : IPrintable, IMemberActions
{
    public string Id { get; set; } // renamed from MemberID to Id for consistency
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Loan> Borrowed { get; } = new();

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Email: {Email}");
    }

    public void PrintDetails()
    {
        DisplayInfo();
    }

    public virtual void BorrowBook(Book book)
    {
        Console.WriteLine($"{Name} borrowed {book.Title}");
    }

    public virtual void ReturnBook(Book book)
    {
        Console.WriteLine($"{Name} returned {book.Title}");
    }
}
