namespace finance_api.Entities
{
    public class Account
    {
        private Guid Id { get; init; }
        private string? AccountNumber { get; set; }
        private double? Balance { get; set; }
        private Customer? Costumer { get; set; }
    }
}