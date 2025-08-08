using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Transactions;

public abstract class Transaction
{
    public string TransactionID { get; set; }
    public DateTime TransactionDate { get; set; }
    public Member Member { get; set; }

    public abstract void Execute();
}
