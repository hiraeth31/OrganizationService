using OrganizationService.Application.Locations.AddLocation;
using OrganizationService.Application.Dtos;

namespace OrganizationService.Contracts.Requests
{
    public record AddLocationRequest(
        string Name,
        string Timezone,
        IEnumerable<AddressDto> Addresses)
    {
        public AddLocationCommand ToCommand() =>
            new AddLocationCommand(
                Name, 
                Timezone, 
                Addresses);
    }
}
