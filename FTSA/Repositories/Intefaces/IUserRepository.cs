using Entities;
using Repositories.Intefaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<User> GetUserByIdAsync(Guid userId);
        Task<User> GetUserByEmailAndResetTokenAsync(string email, string resetToken);
        Task<IEnumerable<User>> FindAllAsync(); // New method to retrieve all users
        Task UpdateUserAsync(User user); // Ensure this line is present

    }
}
