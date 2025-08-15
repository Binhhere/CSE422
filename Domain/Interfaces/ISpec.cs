namespace Domain.Interfaces;

public interface ISpec<T>
{
    bool IsSatisfiedBy(T item);
}
