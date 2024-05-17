namespace finance_api.Entities
{
    public class Customer(string name, string email)
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
    }
}