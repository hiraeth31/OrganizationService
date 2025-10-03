using CSharpFunctionalExtensions;
using OrganizationService.Domain.Common;

namespace OrganizationService.Domain.PositionManagement.ValueObjects
{
    public record Description
    {
        private Description(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public static Result<Description, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Errors.General.ValueIsRequired("Description");

            if (value.Length >= Constants.MAX_POSITION_DESCRIPTION_LENGTH)
                return Errors.General.ValueIsRequired("Description");

            return new Description(value);
        }
    }
}
