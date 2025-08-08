using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Models;

public class Member : IPrintable, IMemberActions
{
    public string MemberID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"ID: {MemberID}, Name: {Name}, Email: {Email}");
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
