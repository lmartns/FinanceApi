namespace finance_api.DTO.AccountAllDtos
{
    public record AccountAddDto(Guid CustomerId, int AccountNumber, double Balance);
}