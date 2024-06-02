namespace FinanceApi.Entities
{
    public class Operation
    {
        public Guid Id { get; init; }
        public string type;
        public double Amount { get; set; }
        public Account sourceAccount { get; set; }
        public Account targetAccount { get; set; }
    }
}