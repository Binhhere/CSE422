using Application.Policies;
using Domain.Entities;
using Domain.Interfaces;
using Application.Policies;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class LoanService
{
    private readonly IBookRepository _books;
    private readonly IReaderRepository _readers;
    private readonly MaxBooksPolicy _policy;

    public LoanService(IBookRepository books, IReaderRepository readers, MaxBooksPolicy policy)
    {
        _books = books;
        _readers = readers;
        _policy = policy;
    }

    public event Action<Book, Reader>? BookBorrowed; // tùy chọn dùng cho demo events

    public void Lend(string readerId, string isbn)
    {
        var reader = _readers.GetById(readerId) ?? throw new Exception("Reader not found");
        var book = _books.GetById(isbn) ?? throw new Exception("Book not found");

        if (book.CopiesAvailable <= 0) throw new Exception("Out of stock");
        if (reader.Borrowed.Count(l => l.ReturnDate == null) >= _policy.Limit)
            throw new Exception("Borrowing limit reached");

        reader.Borrowed.Add(new Loan { BookId = book.ISBN, ReaderId = reader.Id });
        book.CopiesAvailable--;

        BookBorrowed?.Invoke(book, reader);
    }

    public void Return(string readerId, string isbn)
    {
        var reader = _readers.GetById(readerId) ?? throw new Exception("Reader not found");
        var book = _books.GetById(isbn) ?? throw new Exception("Book not found");

        var loan = reader.Borrowed.LastOrDefault(l => l.BookId == isbn && l.ReturnDate == null)
                   ?? throw new Exception("No active loan");

        loan.ReturnDate = DateTime.Now;
        book.CopiesAvailable++;
    }
}
