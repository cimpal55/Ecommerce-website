using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponseRecord<int>> Register(UsersRecord user, string password);
        Task<bool> UserExists(string email);
        Task<ServiceResponseRecord<string>> Login(string email, string password);
        Task<ServiceResponseRecord<bool>> ChangePassword(int userId, string newPassword);
        int GetUserId();
        string GetUserEmail();
        Task<UsersRecord> GetUserByEmail(string email);
    }
}
