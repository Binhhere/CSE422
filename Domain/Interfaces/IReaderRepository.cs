using Domain.Entities;
namespace Domain.Interfaces;
public interface IReaderRepository
{
    void Add(Reader reader);
    Reader? GetById(string id);
    IEnumerable<Reader> GetAll();            // add
}