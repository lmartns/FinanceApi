namespace FinanceApi.Entities
{
    public class Transaction
    {
        public Guid Id { get; init; }
        public string type;
        public double Amount { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}