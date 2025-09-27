namespace OrganizationService.Application.Dtos
{
    public record AddressDto(
        string Country,
        string City,
        string Street,
        string House);
}
