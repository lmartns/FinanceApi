namespace finance_api.Entities
{
    public class Account
    {
        public Guid Id { get; init; }
        public string? AccountNumber { get; set; }
        public double? Balance { get; set; }
        public Customer? Costumer { get; set; }
    }
}