using CSharpFunctionalExtensions;
using OrganizationService.Domain.Common;

namespace OrganizationService.Domain.DepartmentManagement.ValueObjects
{
    public record Identifier
    {
        private Identifier(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Identifier, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Errors.General.ValueIsRequired("Identifier");

            if (value.Length is < Constants.MIN_DEPARTMENT_IDENTIFIER_LENGTH or > Constants.MAX_DEPARTMENT_IDENTIFIER_LENGTH)
                return Errors.General.ValueIsRequired("Identifier");

            if (!value.All(char.IsAsciiLetter))
                return Errors.General.ValueIsRequired("Identifier");

            return new Identifier(value);
        }
    }
}
