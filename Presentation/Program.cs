using Application.Policies;
using Application.Services;
using Application.Specs;
using Application.Factories;
using Application.Builders;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.InMemory;

namespace Presentation;

class Program
{
    static void Main()
    {
        // ---------------- LAB 4 FLOW ----------------
        var books = new BookRepository();
        var readers = new ReaderRepository();
        var policy = new MaxBooksPolicy();
        var loan = new LoanService(books, readers, policy);
        var report = new ReportService(readers, books);

        books.Add(new PhysicalBook { ISBN = "111", Title = "C# OOP", Author = "John Smith", Year = 2023, CopiesAvailable = 2 });
        books.Add(new PhysicalBook { ISBN = "222", Title = "Design Patterns", Author = "GoF", Year = 1994, CopiesAvailable = 1 });
        readers.Add(new Reader { Id = "R1", Name = "Alice", Email = "alice@example.com" });

        loan.Lend("R1", "111");
        loan.Return("R1", "111");
        loan.Lend("R1", "222");

        var spec = new TitleOrCategorySpec("Design");
        foreach (var b in books.Search(spec))
            Console.WriteLine($"Found: {b.Title}");

        Console.WriteLine(report.GenerateReaderLoans());

        // ---------------- LAB 5 ----------------
        Console.WriteLine("\n=== LAB 5: Design Pattern Flow ===");

        // Factory
        IDocument doc = DocumentFactory.Create("book");
        doc.Title = "Refactoring";
        doc.Author = "Martin Fowler";
        doc.PublicationDate = new DateTime(2018, 11, 20);

        // Builder
        var builder = new AcquisitionRecordBuilder();
        var acquisition = builder
            .SetSupplier("BinhBooks Ltd.")
            .SetDate(DateTime.Today)
            .SetPrice(200000)
            .Build();

        // Add Singleton
        LibraryDatabase.Instance.Documents.Add(doc);

        Console.WriteLine("Created document:");
        Console.WriteLine($"{doc.Type} - {doc.Title} by {doc.Author}");

        Console.WriteLine("Acquisition Info:");
        Console.WriteLine(acquisition);

        // === PROTOTYPE_START ===
        Console.WriteLine("\nCloning the previous document to create a new edition...");

        IDocument cloned = doc.Clone();
        cloned.Title = doc.Title + " (2nd Edition)";
        cloned.PublicationDate = doc.PublicationDate.AddYears(1);

        LibraryDatabase.Instance.Documents.Add(cloned);

        Console.WriteLine("Cloned document:");
        Console.WriteLine($"{cloned.Type} - {cloned.Title} by {cloned.Author} ({cloned.PublicationDate:yyyy})");

        // === PROTOTYPE_END ===
        Console.WriteLine("\nCurrent Documents in Library:");
        foreach (var d in LibraryDatabase.Instance.Documents)
        {
            Console.WriteLine($"{d.Type} - {d.Title} ({d.PublicationDate:yyyy})");
        }
    }
}
