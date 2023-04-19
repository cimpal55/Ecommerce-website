using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Client.Services.UsersService
{
    public interface IUsersService
    {
        string GetUserByEmail(string? email);
    }
}
