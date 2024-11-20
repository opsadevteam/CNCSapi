using CNCSproject.Models;

namespace CNCSproject.Interface
{
    public interface ITransaction
    {
        ICollection<Transactions> GetTransactions();
        Transactions GetTransaction(int id);
        bool TransactionExists(int transactionId);
        bool CreateTransaction(Transactions transaction);
        bool UpdateTransaction(Transactions transaction);
        bool DeleteTransaction(Transactions transaction);
        bool Save();


    }
}
