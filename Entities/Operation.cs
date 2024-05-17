namespace finance_api.Entities
{
    public class Operation
    {
        private Guid Id { get; init; }
        private string type;
        private double Amount { get; set; }
        private Account sourceAccount { get; set; }
        private Account targetAccount { get; set; }
    }
}