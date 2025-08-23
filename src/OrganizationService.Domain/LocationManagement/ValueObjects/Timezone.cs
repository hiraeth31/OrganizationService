using CSharpFunctionalExtensions;
using NodaTime;

namespace OrganizationService.Domain.LocationManagement.ValueObjects
{
    public record Timezone
    {
        private static readonly IReadOnlyCollection<string> IanaZoneIds = DateTimeZoneProviders.Tzdb.Ids;

        private Timezone(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public static Result<Timezone> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Timezone>("Не может быть пустым.");

            if (!IanaZoneIds.Contains(value))
                return Result.Failure<Timezone>("Значение не является валидным IANA-кодом часового пояса.");

            return Result.Success(new Timezone(value));
        }
    }
}
