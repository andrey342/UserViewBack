using System.ComponentModel.DataAnnotations;

namespace UserViewBack.Domain.Dto
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public string? Name { get; set; }

        public AddressCreateDto Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public CompanyCreateDto Company { get; set; }
    }

    public class AddressCreateDto
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public GeoCreateDto Geo { get; set; }
    }

    public class GeoCreateDto
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class CompanyCreateDto
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
