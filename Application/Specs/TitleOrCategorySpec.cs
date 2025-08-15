using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Application.Specs;

public class TitleOrCategorySpec : ISpec<Book>
{
    private readonly string _query;

    public TitleOrCategorySpec(string query)
    {
        _query = query.ToLower();
    }

    public bool IsSatisfiedBy(Book book)
    {
        return book.Title.ToLower().Contains(_query) ||
               book.Category?.ToLower().Contains(_query) == true;
    }
}
