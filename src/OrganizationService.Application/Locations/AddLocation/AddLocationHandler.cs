using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using OrganizationService.Domain.Common;
using OrganizationService.Domain.LocationManagement;
using OrganizationService.Domain.LocationManagement.ValueObjects;

namespace OrganizationService.Application.Locations.AddLocation
{
    public class AddLocationHandler
    {
        private readonly ILocationsRepository _locationsRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILogger<AddLocationHandler> _logger;

        public AddLocationHandler(
            ILocationsRepository locationsRepository,
            IDateTimeProvider dateTimeProvider,
            ILogger<AddLocationHandler> logger)
        {
            _locationsRepository = locationsRepository;
            _dateTimeProvider = dateTimeProvider;
            _logger = logger;
        }

        public async Task<Result<Guid, ErrorList>> Handle(
            AddLocationCommand command,
            CancellationToken cancellationToken)
        {

            var locationId = new LocationId(Guid.NewGuid());

            var nameResult = LocationName.Create(command.Name);
            if (nameResult.IsFailure)
                return Errors.General.ValueIsInvalid(command.Name).ToErrorList();

            var timezoneResult = LocationTimezone.Create(command.Timezone);
            if (timezoneResult.IsFailure)
                return Errors.General.ValueIsInvalid(command.Timezone).ToErrorList();

            var addressesResult = command.Addresses
                .Select(ad => Address.Create(
                    ad.Country,
                    ad.City,
                    ad.Street,
                    ad.House));
            if (addressesResult.Any(x => x.IsFailure))
                return Errors.General.ValueIsInvalid().ToErrorList();

            var adresses = addressesResult.Select(x=> x.Value).ToList();

            var location = new Location(
                locationId,
                nameResult.Value,
                timezoneResult.Value,
                adresses,
                _dateTimeProvider.UtcNow,
                _dateTimeProvider.UtcNow);

            await _locationsRepository.Add(location, cancellationToken);

            _logger.LogInformation("Added location with id {LocationId}", location.Id.Value);

            return location.Id.Value;
        }
    }
}
