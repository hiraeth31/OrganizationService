using CSharpFunctionalExtensions;

namespace OrganizationService.Domain.DepartmentManagement.ValueObjects
{
    public record Identifier
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 150;
        private Identifier(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Identifier> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Identifier>("Не может быть пустым.");

            if (value.Length is < MIN_LENGTH or > MAX_LENGTH)
                return Result.Failure<Identifier>("Длина должна быть от 3 до 150 символов.");

            if (!value.All(char.IsAsciiLetter))
                return Result.Failure<Identifier>("Разрешены только латинские буквы.");

            return Result.Success(new Identifier(value));
        }
    }
}
