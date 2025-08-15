using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.InMemory;

public class BookRepository : IBookRepository
{
    private readonly Dictionary<string, Book> _db = new();

    public void Add(Book book) => _db[book.ISBN] = book;

    public Book? GetById(string id) =>
        _db.TryGetValue(id, out var book) ? book : null;

    public IEnumerable<Book> Search(ISpec<Book> spec) =>
        _db.Values.Where(spec.IsSatisfiedBy);
    public IEnumerable<Book> GetAll() => _db.Values;
}
