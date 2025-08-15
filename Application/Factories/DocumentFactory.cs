using Domain.Entities;
using Domain.Interfaces;

namespace Application.Factories
{
    public static class DocumentFactory
    {
        public static IDocument Create(string type)
        {
            return type.ToLower() switch
            {
                "book" => new ConcreteBook(),
                "magazine" => new Magazine(),
                "newspaper" => new Newspaper(),
                _ => throw new ArgumentException("Unsupported document type.")
            };
        }
    }
}
