using Taxana.Backend.Enums;
using Taxana.Backend.Extensions;

namespace Taxana.Backend.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string AccountNumber { get; set; }
        public VATRate VATRate { get; set; }
        public bool IsPrivate { get; set; }

        public decimal VATAmount => Amount * VATRate.ToDecimal();
        public decimal TotalAmount => Amount + VATAmount;

        public Transaction(DateTime date, string description, decimal amount, string accountNumber, VATRate vatRate, bool isPrivate)
        {
            Id = Guid.NewGuid();
            Date = date;
            Description = description;
            Amount = amount;
            AccountNumber = accountNumber;
            VATRate = vatRate;
            IsPrivate = isPrivate;
        }
    }
}