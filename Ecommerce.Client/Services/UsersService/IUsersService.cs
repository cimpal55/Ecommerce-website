using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Server.Services.UsersService
{
    public interface IUsersService
    {
        Task InsertUserAsync(UsersRecord user);
        Task DeleteUserAsync(UsersRecord user);
        Task UpdateUserAsync(UsersRecord user);
        Task<UsersRecord> GetUserByEmailAsync(string? email);
        Task<UsersRecord> GetUserByIdAsync(int? id);
    }
}
