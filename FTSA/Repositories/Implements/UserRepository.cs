using Entities;
using Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implements
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(TutorWebContext dataContext) : base(dataContext)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await FindByCondition(u => u.Email == email, false).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await FindByCondition(u => u.Email == email && u.Password == password, false).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await FindByCondition(u => u.UserId == userId, false).FirstOrDefaultAsync();
        }

        public async Task AddUserAsync(User user)
        {
            Create(user);
            await SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            Update(user);
            await SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndResetTokenAsync(string email, string resetToken)
        {
            return await FindByCondition(u => u.Email == email && u.ResetToken == resetToken, false).FirstOrDefaultAsync();
        }

        // New method to retrieve all users
        public async Task<IEnumerable<User>> FindAllAsync()
        {
            return await FindAll(trackChanges: false).ToListAsync();
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
