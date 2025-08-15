using Domain.Entities;

namespace Application.Transactions;

public abstract class Transaction
{
    public string TransactionID { get; set; }
    public DateTime TransactionDate { get; set; }
    public Reader Member { get; set; }

    public abstract void Execute();
}
