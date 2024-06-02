using System.ComponentModel.DataAnnotations;

namespace FinanceApi.Entities
{
    public class Account(int accountNumber, Guid customerId, double balance)
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        [Required]
        public int AccountNumber { get; set; } = accountNumber;

        public double Balance { get; set; } = balance;

        [Required]
        public Guid CustomerId { get; set; } = customerId;
    }
}
