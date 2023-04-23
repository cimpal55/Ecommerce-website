using Ecommerce.Shared.Models.Data;
using LinqToDB;
using Ecommerce.Client.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Server.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly SqlDataAccess _conn;
        public UsersService(SqlDataAccess conn)
        {
            _conn = conn;
        }

        public async Task DeleteUserAsync(UsersRecord user) =>
            await _conn
                .DeleteAsync(user)
                .ConfigureAwait(false);
        public async Task InsertUserAsync(UsersRecord user) =>
            await _conn
                .InsertAsync(user)
                .ConfigureAwait(false);
        public async Task UpdateUserAsync(UsersRecord user) =>
            await _conn
                .UpdateAsync(user)
                .ConfigureAwait(false);
        public async Task<UsersRecord> GetUserByEmailAsync(string? email) =>
            await _conn
                .Users
                .Where(x => x.Email.ToLower().Equals(email.ToLower()))
                .FirstOrDefaultAsync();
        public async Task<UsersRecord> GetUserByIdAsync(int? id) =>
            await _conn
                .Users
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

    }
}
