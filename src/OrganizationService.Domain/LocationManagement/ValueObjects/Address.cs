using CSharpFunctionalExtensions;
using OrganizationService.Domain.Common;

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

        public static Result<Address, Error> Create(string country, string city, string street, string house)
        {
            if (string.IsNullOrWhiteSpace(country))
                return Errors.General.ValueIsRequired("country");

            if (string.IsNullOrWhiteSpace(city))
                return Errors.General.ValueIsRequired("city");

            if (string.IsNullOrWhiteSpace(street))
                return Errors.General.ValueIsRequired("street");

            if (string.IsNullOrWhiteSpace(house))
                return Errors.General.ValueIsRequired("house");

            return new Address(country, city, street, house);
        }
    }
}
