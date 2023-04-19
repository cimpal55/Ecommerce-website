using RepairEquipment.Client.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Client.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly SqlDataAccess _conn;

        public string GetUserByEmail(string? email)
        {
            _conn
                .Users
                .Where(x => )
        }
    }
}
