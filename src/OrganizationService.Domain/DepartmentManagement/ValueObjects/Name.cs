using CSharpFunctionalExtensions;
using OrganizationService.Domain.Common;

namespace OrganizationService.Domain.DepartmentManagement.ValueObjects
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

            if (value.Length is < Constants.MIN_DEPARTMENT_NAME_LENGTH or > Constants.MAX_DEPARTMENT_NAME_LENGTH)
                return Errors.General.ValueIsRequired("Name");

            return new Name(value);
        }
    }
}
