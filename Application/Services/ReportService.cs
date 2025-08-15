using Domain.Interfaces;
using System.Text;

namespace Application.Services;
public class ReportService
{
    private readonly IReaderRepository _readers;
    private readonly IBookRepository _books;
    public ReportService(IReaderRepository readers, IBookRepository books)
    {
        _readers = readers; _books = books;
    }
    public string GenerateReaderLoans()
    {
        var sb = new StringBuilder();
        foreach (var r in _readers.GetAll())
        {
            sb.AppendLine($"Reader: {r.Name}");
            var active = r.Borrowed
              .Where(l => l.ReturnDate == null)
              .Select(l => _books.GetById(l.BookId)?.Title ?? l.BookId);
            sb.AppendLine("  Borrowed: " + string.Join(", ", active));
        }
        return sb.ToString();
    }
}
