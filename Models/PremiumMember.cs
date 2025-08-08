namespace LibraryManagementSystem.Models;

public class PremiumMember : Member
{
    public DateTime MembershipExpiry { get; set; }
    public int MaxBooksAllowed { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Expiry: {MembershipExpiry}, MaxBooks: {MaxBooksAllowed}");
    }

    public override void BorrowBook(Book book)
    {
        base.BorrowBook(book);
    }

    public override void ReturnBook(Book book)
    {
        base.ReturnBook(book);
    }
}
