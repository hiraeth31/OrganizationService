using CSharpFunctionalExtensions;

namespace OrganizationService.Domain.LocationManagement.ValueObjects
{
    public record Address
    {
        private Address(string country, string city, string street, string house)
        {
            Country = country;
            City = city;
            Street = street;
            House = house;
        }
        public string Country { get; }
        public string City { get; }
        public string Street { get; }
        public string House { get; }

        public static Result<Address> Create(string country, string city, string street, string house)
        {
            if (string.IsNullOrWhiteSpace(country))
                return Result.Failure<Address>("Не может быть пустым.");

            if (string.IsNullOrWhiteSpace(city))
                return Result.Failure<Address>("Не может быть пустым.");

            if (string.IsNullOrWhiteSpace(street))
                return Result.Failure<Address>("Не может быть пустым.");

            if (string.IsNullOrWhiteSpace(house))
                return Result.Failure<Address>("Не может быть пустым.");

            return Result.Success(new Address(country, city, street, house));
        }
    }
}
