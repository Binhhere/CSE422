using Application.Policies;
using Application.Services;
using Domain.Entities;
using Infrastructure.InMemory;
using Application.Policies;

namespace Presentation;

public class DelegateEventsDemo
{
    public static void Run()
    {
        var books = new BookRepository();
        var readers = new ReaderRepository();
        var loan = new LoanService(books, readers, new MaxBooksPolicy());

        var notify = new NotificationService();
        var advanced = new AdvancedNotificationService();

        loan.BookBorrowed += (b, m) => notify.SendNotification($"[1] {m.Name} borrowed {b.Title}");
        loan.BookBorrowed += (b, m) => advanced.SendNotification($"[2] {m.Name} borrowed {b.Title}");

        var book = new PhysicalBook { ISBN = "999", Title = "C# Basics", Author = "Anon", Year = 2024, CopiesAvailable = 1 };
        var member = new Reader { Id = "R1", Name = "Binh", Email = "b@example.com" };

        books.Add(book);
        readers.Add(member);

        loan.Lend("R1", "999");
    }
}
