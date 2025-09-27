
using OrganizationService.Application.Dtos;

namespace OrganizationService.Application.Locations.AddLocation
{
    public record AddLocationCommand(
        string Name,
        string Timezone,
        IEnumerable<AddressDto> Addresses);
}
