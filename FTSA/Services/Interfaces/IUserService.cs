using Entities;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User user);
        // Các phương thức khác nếu cần
    }
}
