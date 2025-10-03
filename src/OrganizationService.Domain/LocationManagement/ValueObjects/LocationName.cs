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

        public static Result<LocationName, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Errors.General.ValueIsRequired("LocationName");

            if (value.Length is < Constants.MIN_LOCATION_NAME_LENGTH or > Constants.MAX_LOCATION_NAME_LENGTH)
                return Errors.General.ValueIsRequired("LocationName");

            return new LocationName(value);
        }
    }
}
