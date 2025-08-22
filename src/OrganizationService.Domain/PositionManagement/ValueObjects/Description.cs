using CSharpFunctionalExtensions;

namespace OrganizationService.Domain.PositionManagement.ValueObjects
{
    public record Description
    {
        private const int MAX_LENGTH = 1000;
        private Description(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public static Result<Description> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Description>("Не может быть пустым.");

            if (value.Length >= MAX_LENGTH)
                return Result.Failure<Description>("Не может быть более 1000 символов.");

            return Result.Success(new Description(value));
        }
    }
}
