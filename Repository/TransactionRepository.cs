using System.Transactions;
using CNCSproject.Interface;
using CNCSproject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CNCSproject.Repository
{
    public class TransactionRepository : ITransaction
    {
        private CncssystemContext _context;

        public TransactionRepository(CncssystemContext context)
        {
            _context = context;

        }

        public bool CreateTransaction(Transactions transaction)
        {
            _context.Add(transaction);

            return Save();
        }

        public bool DeleteTransaction(Transactions transaction)
        {
            _context.Remove(transaction);

            return Save();
        }

        public Transactions GetTransaction(int id)
        {
            return _context.Transactions.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Transactions> GetTransactions()
        {
            return _context.Transactions.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TransactionExists(int transactionId)
        {
            return _context.Transactions.Any(p => p.Id == transactionId);
        }

        public bool UpdateTransaction(Transactions transaction)
        {
            _context.Update(transaction);
            return Save();
        }
    }
}
