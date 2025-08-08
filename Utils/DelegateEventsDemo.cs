using LibraryManagementSystem.Core;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Utils;

public class DelegateEventsDemo
{
    public static void Run()
    {
        var book = new Book { Title = "C# Basics" };
        var member = new Member { Name = "Binh" };
        var library = new Library();

        var notify = new NotificationService();
        var advanced = new AdvancedNotificationService();

        library.OnBookBorrowed += (b, m) => notify.SendNotification($"[1] {m.Name} borrowed {b.Title}");
        library.OnBookBorrowed += (b, m) => advanced.SendNotification($"[2] {m.Name} borrowed {b.Title}");

        library.BorrowBook(book, member);
    }
}
