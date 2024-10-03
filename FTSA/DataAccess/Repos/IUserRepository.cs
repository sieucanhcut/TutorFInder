using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<bool> UpdateUserrAsync(Guid id, User user);
        Task<bool> DeleteUserAsync(Guid id);
        Task<User> GetUserAsync(Guid id);
        Task<IEnumerable<User>> GetEveryUsersAsync();
        Task<bool> FindExistUserAsync(Guid id);

        Task<User> LoginAuthenitcateAsync(string Email, string Password);
        Task<User> GetUserByEmailOnlyAsync(string Email);
        Task<bool> CheckPasswordAsync(string password, User user);
        Task<bool> ChangePasswordAsync(string oldPassword, string newPassword, Guid Id);

    }
}
