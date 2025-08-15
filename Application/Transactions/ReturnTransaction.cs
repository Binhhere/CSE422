using Domain.Entities;

namespace Application.Transactions;

public class ReturnTransaction : Transaction
{
    public Book BookReturned { get; set; }

    public override void Execute()
    {
        Console.WriteLine($"{Member.Name} returned {BookReturned.Title}");
    }
}
