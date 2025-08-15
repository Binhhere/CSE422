using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.InMemory;

public class ReaderRepository : IReaderRepository
{
    private readonly Dictionary<string, Reader> _db = new();

    public void Add(Reader reader) => _db[reader.Id] = reader;

    public Reader? GetById(string id) =>
        _db.TryGetValue(id, out var reader) ? reader : null;
    public IEnumerable<Reader> GetAll() => _db.Values;
}
