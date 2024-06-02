namespace finance_api.DTO.AccountDtos
{
    public record AccountAddDto(Guid CustomerId, int AccountNumber, double Balance);
}