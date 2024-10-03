using DataAccess.dbContext_Access;
using DataAccess.Repos;
using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Task<bool> ChangePasswordAsync(string oldPassword, string newPassword, Guid Id)
        {
            throw new NotImplementedException();
        }

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

        public Task<bool> DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FindExistUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetEveryUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailOnlyAsync(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<User> LoginAuthenitcateAsync(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserrAsync(Guid id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
