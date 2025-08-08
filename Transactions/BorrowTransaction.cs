using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Transactions;

public class BorrowTransaction : Transaction
{
    public Book BookBorrowed { get; set; }

    public override void Execute()
    {
        Console.WriteLine($"{Member.Name} borrowed {BookBorrowed.Title}");
    }
}
