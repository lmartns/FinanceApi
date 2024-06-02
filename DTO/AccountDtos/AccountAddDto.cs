namespace FinanceApi.DTO.AccountDtos
{
    public record AccountAddDto(Guid CustomerId, int AccountNumber, double Balance);
}