using System.Threading.Tasks;
using NugetAnalyzer.BLL.Models;

namespace NugetAnalyzer.BLL.Interfaces
{
    public interface IUserService
    {
        void CreateUserAsync(Profile profile);

        Profile GetProfileByUserName(string userName);
        Profile GetProfileByGitHubId(int gitHubId);
    }
}
