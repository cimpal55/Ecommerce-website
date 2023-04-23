using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponseRecord<int>> Register(UserRegisterRecord request);
        Task<ServiceResponseRecord<string>> Login(UserLoginRecord request);
        Task<ServiceResponseRecord<bool>> ChangePassword(UserChangePasswordRecord request);
        Task<bool> IsUserAuthenticated();
    }
}
