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

        public static Result<Name> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Name>("Не может быть пустым.");

            if (value.Length is < Constants.MIN_DEPARTMENT_NAME_LENGTH or > Constants.MAX_DEPARTMENT_NAME_LENGTH)
                return Result.Failure<Name>("Длина должна быть от 3 до 150 символов.");

            return Result.Success(new Name(value));
        }
    }
}
