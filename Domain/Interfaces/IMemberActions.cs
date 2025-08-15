using Domain.Entities;

namespace Domain.Interfaces;

public interface IMemberActions
{
    void BorrowBook(Book book);
    void ReturnBook(Book book);
}
