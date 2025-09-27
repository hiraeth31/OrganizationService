using CSharpFunctionalExtensions;
using OrganizationService.Domain.Common;

namespace OrganizationService.Domain.LocationManagement.ValueObjects
{
    public record LocationName
    {
        private LocationName(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public static Result<LocationName> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<LocationName>("Не может быть пустым.");

            if (value.Length is < Constants.MIN_LOCATION_NAME_LENGTH or > Constants.MAX_LOCATION_NAME_LENGTH)
                return Result.Failure<LocationName>("Длина должна быть от 3 до 120 символов.");

            return Result.Success(new LocationName(value));
        }
    }
}
