using CSharpFunctionalExtensions;
using NodaTime;

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

        public static Result<LocationTimezone> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<LocationTimezone>("Не может быть пустым.");

            if (!IanaZoneIds.Contains(value))
                return Result.Failure<LocationTimezone>("Значение не является валидным IANA-кодом часового пояса.");

            return Result.Success(new LocationTimezone(value));
        }
    }
}
