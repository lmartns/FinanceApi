namespace finance_api.Entities
{
    public class Transaction
    {
        private Guid Id { get; init; }
        private string type;
        private double Amount { get; set; }
        private DateTime DateTime { get; set; }
        private Account Account { get; set; }
    }
}