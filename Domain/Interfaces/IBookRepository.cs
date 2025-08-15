using Domain.Entities;
namespace Domain.Interfaces;
public interface IBookRepository
{
    void Add(Book book);
    Book? GetById(string id);
    IEnumerable<Book> Search(ISpec<Book> spec);
    IEnumerable<Book> GetAll();              // add
}