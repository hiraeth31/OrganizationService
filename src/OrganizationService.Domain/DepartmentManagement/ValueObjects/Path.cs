using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace OrganizationService.Domain.DepartmentManagement.ValueObjects
{
    public record Path
    {
        private Path(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public static Result<Path> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Path>("Не может быть пустым.");

            return Result.Success(new Path(value));
        }
    }
}
