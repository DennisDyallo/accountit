// UseCases/AddTransaction.cs

using Infrastructure;
using System.Text.Json;
using Domain.Entities;

namespace UseCases
{
    namespace UseCases
    {
        public class AddTransaction
        {
            private readonly LocalStorageAccessor _localStorageAccessor;

            public AddTransaction(LocalStorageAccessor localStorageAccessor)
            {
                _localStorageAccessor = localStorageAccessor;
            }

            public async Task Run(Transaction transaction)
            {
                string transactionJson = JsonSerializer.Serialize(transaction);
                await _localStorageAccessor.SetValueAsync(transaction.Id.ToString(), transactionJson);
            }
        }
    }
}