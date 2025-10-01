using CSharpFunctionalExtensions;
using OrganizationService.Domain.Common;

namespace OrganizationService.Domain.DepartmentManagement.ValueObjects
{
    public record Path
    {
        private Path(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public static Result<Path, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Errors.General.ValueIsRequired("Path");

            return new Path(value);
        }
    }
}
