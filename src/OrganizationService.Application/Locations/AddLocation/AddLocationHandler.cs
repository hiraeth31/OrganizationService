using OrganizationService.Domain.Common;
using OrganizationService.Domain.LocationManagement;
using OrganizationService.Domain.LocationManagement.ValueObjects;

namespace OrganizationService.Application.Locations.AddLocation
{
    public class AddLocationHandler
    {
        private readonly ILocationsRepository _locationsRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AddLocationHandler(
            ILocationsRepository locationsRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _locationsRepository = locationsRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Guid> Handle(
            AddLocationCommand command,
            CancellationToken cancellationToken)
        {

            var locationId = new LocationId(Guid.NewGuid());

            var name = LocationName.Create(command.Name).Value;

            var timezone = LocationTimezone.Create(command.Timezone).Value;

            var addresses = command.Addresses
                .Select(ad => Address.Create(
                    ad.Country,
                    ad.City,
                    ad.Street,
                    ad.House)
                .Value);

            var location = new Location(
                locationId,
                name,
                timezone,
                addresses,
                _dateTimeProvider,
                _dateTimeProvider);

            await _locationsRepository.Add(location, cancellationToken);

            return location.Id.Value;
        }
    }
}
