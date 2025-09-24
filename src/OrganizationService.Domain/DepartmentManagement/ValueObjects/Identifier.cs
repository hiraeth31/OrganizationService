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

        public static Result<Identifier> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Identifier>("Не может быть пустым.");

            if (value.Length is < Constants.MIN_DEPARTMENT_IDENTIFIER_LENGTH or > Constants.MAX_DEPARTMENT_IDENTIFIER_LENGTH)
                return Result.Failure<Identifier>("Длина должна быть от 3 до 150 символов.");

            if (!value.All(char.IsAsciiLetter))
                return Result.Failure<Identifier>("Разрешены только латинские буквы.");

            return Result.Success(new Identifier(value));
        }
    }
}
