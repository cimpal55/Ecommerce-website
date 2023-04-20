using Ecommerce.Data;
using LinqToDB.Mapping;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Shared.Models.Data
{
    [Table(Tables.Users)]
    public sealed record UsersRecord
    {
        [Column(Users.Id, IsPrimaryKey =true)]
        public int Id { get; set; }

        [Column(Users.Email, CanBeNull = false)]
        public string Email { get; set; } = string.Empty;

        [Column(Users.PasswordHash, CanBeNull = false)]
        public byte[] PasswordHash { get; set; }
        
        [Column(Users.PasswordSalt, CanBeNull = false)]
        public byte[] PasswordSalt { get; set; }

        [Column(Users.Created, CanBeNull = false)]
        public DateTime Created { get; set; } = DateTime.Now;

        [Column(Users.PhoneNumber, CanBeNull = false)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column(Users.Address, CanBeNull = false)]
        public UserAddressesRecord Address { get; set; } = new();

        [Column(Users.Role, CanBeNull = false)]
        public string Role { get; set; } = "Customer";

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool Editing { get; set; } = false;

    }
}
