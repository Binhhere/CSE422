using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Core;

public class Library
{
    public string LibraryName { get; set; }
    public List<Book> Books { get; set; }
    public List<Member> Members { get; set; }

    public event Action<Book, Member> OnBookBorrowed;

    public Library()
    {
        LibraryName = "Default Library";
        Books = new List<Book>();
        Members = new List<Member>();
    }

    public Library(string name, List<Book> books)
    {
        LibraryName = name;
        Books = new List<Book>(books);
        Members = new List<Member>();
    }

    public Library(Library other)
    {
        LibraryName = other.LibraryName;
        Books = new List<Book>(other.Books);
        Members = new List<Member>(other.Members);
    }

    public void BorrowBook(Book book, Member member)
    {
        Console.WriteLine($"{member.Name} borrowed {book.Title} via library");
        OnBookBorrowed?.Invoke(book, member);
    }

    public void DisplayLibraryInfo()
    {
        Console.WriteLine($"Library: {LibraryName}, Books: {Books.Count}, Members: {Members.Count}");
    }
}
