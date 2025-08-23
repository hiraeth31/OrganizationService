using CSharpFunctionalExtensions;

namespace OrganizationService.Domain.LocationManagement.ValueObjects
{
    public record Name
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 120;
        private Name(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public static Result<Name> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Name>("Не может быть пустым.");

            if (value.Length is < MIN_LENGTH or > MAX_LENGTH)
                return Result.Failure<Name>("Длина должна быть от 3 до 120 символов.");

            return Result.Success(new Name(value));
        }
    }
}
