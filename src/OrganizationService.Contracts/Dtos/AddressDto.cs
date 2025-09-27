namespace OrganizationService.Contracts.Dtos
{
    public record AddressDto(
        string Country,
        string City,
        string Street,
        string House);
}
