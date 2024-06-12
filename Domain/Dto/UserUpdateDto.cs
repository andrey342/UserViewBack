using System.ComponentModel.DataAnnotations;

namespace UserViewBack.Domain.Dto
{
    public class UserUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public string? Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public AddressUpdateDto Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        [Required(ErrorMessage = "Company is required.")]
        public CompanyUpdateDto Company { get; set; }
    }

    public class AddressUpdateDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Geo is required.")]
        public GeoUpdateDto Geo { get; set; }
    }

    public class GeoUpdateDto
    {
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class CompanyUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
