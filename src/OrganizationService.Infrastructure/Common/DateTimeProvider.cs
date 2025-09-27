using OrganizationService.Domain.Common;

namespace OrganizationService.Infrastructure.Common
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
