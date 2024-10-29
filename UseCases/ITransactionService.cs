using Domain.Entities;

namespace UseCases
{
    // Transaction Service Interface
    // Gränssnitt för Transaktionstjänst
    public interface ITransactionService
    {
        // Create a new transaction
        // Skapa en ny transaktion
        Task<Guid> CreateTransactionAsync(Transaction transaction);

        // Get recent transactions
        // Hämta senaste transaktioner
        Task<List<Transaction>> GetRecentTransactionsAsync(int count);
    }
}
