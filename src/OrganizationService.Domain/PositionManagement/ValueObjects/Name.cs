using CSharpFunctionalExtensions;
using OrganizationService.Domain.Common;

namespace OrganizationService.Domain.PositionManagement.ValueObjects
{
    public record Name
    {
        private Name(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public static Result<Name, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Errors.General.ValueIsRequired("Name");

            if (value.Length is < Constants.MIN_POSITION_NAME_LENGTH or > Constants.MAX_POSITION_NAME_LENGTH)
                return Errors.General.ValueIsRequired("Name");

            return new Name(value);
        }
    }
}
