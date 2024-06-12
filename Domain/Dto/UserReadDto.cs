using System.ComponentModel.DataAnnotations;

namespace UserViewBack.Domain.Dto
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string? Name { get; set; }

        public int AddressId { get; set; }
        public AddressReadDto Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public int CompanyId { get; set; }
        public CompanyReadDto Company { get; set; }
    }

    public class AddressReadDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        public int GeoId { get; set; }
        public GeoReadDto Geo { get; set; }
    }

    public class GeoReadDto
    {
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class CompanyReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
