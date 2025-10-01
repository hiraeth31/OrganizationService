using CSharpFunctionalExtensions;
using NodaTime;
using OrganizationService.Domain.Common;

namespace OrganizationService.Domain.LocationManagement.ValueObjects
{
    public record LocationTimezone
    {
        private static readonly IReadOnlyCollection<string> IanaZoneIds = DateTimeZoneProviders.Tzdb.Ids;

        private LocationTimezone(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public static Result<LocationTimezone, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Errors.General.ValueIsRequired("LocationTimezone");

            if (!IanaZoneIds.Contains(value))
                return Errors.General.ValueIsRequired("LocationTimezone");

            return new LocationTimezone(value);
        }
    }
}
