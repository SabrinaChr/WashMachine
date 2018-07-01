using System.Threading.Tasks;
using WashMachine.Core.Models;

namespace WashMachine.Core
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetUserByEmail(string email);
    }
}
