using DataAccess.dbContext_Access;
using DataAccess.Repos;
using DataObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly TutorWebContext _tutorWebContext;
        public UserRepository(TutorWebContext tutorWebContext)
        {
            _tutorWebContext = tutorWebContext;
        }
        public async Task<bool> ChangePasswordAsync(string oldPassword, string newPassword, Guid Id)
        {
            var existUsers = await(from user in _tutorWebContext.Users
                                   where user.UserId == Id 
                                   & user.Password == oldPassword
                                   select user).FirstOrDefaultAsync();
            if (existUsers == null) return false;
            existUsers.Password = newPassword;
            await _tutorWebContext.AddAsync(existUsers);
            return await _tutorWebContext.SaveChangesAsync() > 0;
        }

        // Need more specific cases
        public Task<bool> CheckPasswordAsync(string password, User user)
        {
            throw new NotImplementedException();
        }

        public async Task CreateUserAsync(User user)
        {
            using var transaction = await _tutorWebContext.Database.BeginTransactionAsync();
            try
            {
                var newUser = new User
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                    CitizenId = user.CitizenId,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    LocationId = user.LocationId,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumber2 = user.PhoneNumber2,
                    PlaceOfWork = user.PlaceOfWork,
                    RoleId = user.RoleId,
                    UpdateDate = DateTime.UtcNow
                };

                await _tutorWebContext.Users.AddAsync(newUser);
                await _tutorWebContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var userToDelete = await _tutorWebContext.Users.FirstAsync(p => p.UserId == id);

            if (userToDelete == null)
            {
                return false;
            }

            _tutorWebContext.Remove(userToDelete);
            return await _tutorWebContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> FindExistUserAsync(Guid id)
        {
            var existUsers = await (from user in _tutorWebContext.Users 
                               where user.UserId == id 
                               select user)
                               .ToListAsync();
            if(existUsers.IsNullOrEmpty()) return false;
            return true;
        }

        public async Task<IEnumerable<User>> GetEveryUsersAsync()
        {
            return await _tutorWebContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserAsync(Guid id)
        {
            var user = await _tutorWebContext.Users.FindAsync(id);

            if (user == null)
            {
                return default;
            }
            return user;

        }

        public async Task<User?> GetUserByEmailOnlyAsync(string Email)
        {
            var existUsers = await(from user in _tutorWebContext.Users
                                   where user.Email == Email
                                   select user).FirstOrDefaultAsync();
            if (existUsers == null) return default;
            return existUsers;
        }

        public async Task<User?> LoginAuthenitcateAsync(string Email, string Password)
        {
            var existUsers = await(from user in _tutorWebContext.Users
                                   where user.Email == Email 
                                   & user.Password == Password
                                   select user).FirstOrDefaultAsync();
            if (existUsers == null) return default;
            return existUsers;
        }

        public async Task<bool> UpdateUserrAsync(Guid id, User user)
        {
            var userToUpdate = await _tutorWebContext.Users.FindAsync(id);

            if (userToUpdate == null)
            {
                return false;
            }
            userToUpdate.UserName = user.UserName;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.PhoneNumber2 = user.PhoneNumber2;
            userToUpdate.CitizenId = user.CitizenId;
            userToUpdate.DateOfBirth = user.DateOfBirth;
            userToUpdate.PlaceOfWork = user.PlaceOfWork;
            userToUpdate.Gender = user.Gender;
            userToUpdate.Email = user.Email;
            userToUpdate.LocationId = user.LocationId;
            userToUpdate.RoleId = user.RoleId;
            userToUpdate.UpdateDate = DateTime.UtcNow;
             await _tutorWebContext.AddAsync(userToUpdate);
            return await _tutorWebContext.SaveChangesAsync() > 0;
        }
    }
}
