namespace finance_api.Entities
{
    public class Customer(Guid id, string name, string email)
    {
        public Guid Id { get; init; } = id;
        private string Name { get; set; } = name;
        private string Email { get; set; } = email;
    }
}