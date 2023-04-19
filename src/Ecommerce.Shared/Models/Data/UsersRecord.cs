using Ecommerce.Data;
using LinqToDB.Mapping;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Shared.Models.Data
{
    public class UsersRecord
    {
        [Column(Users.Id)]
        public int Id { get; set; }

        [Column(Users.Email)]
        public string Email { get; set; } = string.Empty;

        [Column(Users.PasswordHash)]
        public byte[] PasswordHash { get; set; }
        
        [Column(Users.PasswordSalt)]
        public byte[] PasswordSalt { get; set; }

        [Column(Users.Created)]
        public DateTime Created { get; set; } = DateTime.Now;

        [Column(Users.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column(Users.Address)]
        public UserAddressesRecord Address { get; set; } = new();

        [Column(Users.Role)]
        public string Role { get; set; } = "Customer";

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool Editing { get; set; } = false;

    }
}
