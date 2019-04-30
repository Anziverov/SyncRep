using System.Threading.Tasks;
using NugetAnalyzer.BLL.Models;

namespace NugetAnalyzer.BLL.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(Profile profile);

        Task<Profile> GetProfileByIdAsync(int userId);
    }
}
