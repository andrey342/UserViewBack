namespace UserViewBack.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        // Clave foránea para Address
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public string Phone { get; set; }
        public string Website { get; set; }

        // Clave foránea para Company
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }

    public class Address
    {
        public int Id { get; set; } // Clave primaria
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        // Clave foránea para Geo
        public int GeoId { get; set; }
        public Geo Geo { get; set; }
    }

    public class Geo
    {
        public int Id { get; set; } // Clave primaria
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class Company
    {
        public int Id { get; set; } // Clave primaria
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
