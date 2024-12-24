using Domain.Entities;

namespace UseCases
{
    // Transaction Service Implementation
    // Implementering av Transaktionstjänst
    public class TransactionService : ITransactionService
    {
        // In-memory list of transactions (temporary solution)
        // Lista över transaktioner i minnet (tillfällig lösning)
        private readonly List<Transaction> _transactions = new List<Transaction>();

        // Create a new transaction
        // Skapa en ny transaktion
        public Task<Guid> CreateTransactionAsync(Transaction transaction)
        {
            _transactions.Add(transaction);
            return Task.FromResult(transaction.Id);
        }

        // Get recent transactions
        // Hämta senaste transaktioner
        public Task<List<Transaction>> GetRecentTransactionsAsync(int count)
        {
            var recentTransactions = _transactions
                .OrderByDescending(t => t.Date)
                .Take(count)
                .ToList();
            return Task.FromResult(recentTransactions);
        }
    }
}
