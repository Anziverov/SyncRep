using System.Threading.Tasks;
using NugetAnalyzer.BLL.Converters;
using NugetAnalyzer.BLL.Interfaces;
using NugetAnalyzer.BLL.Models;
using NugetAnalyzer.DAL.Interfaces;
using NugetAnalyzer.Domain;

namespace NugetAnalyzer.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<User> users;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            users = unitOfWork.GetRepository<User>();
        }

        public async Task<int> CreateUserAsync(Profile profile)
        {
            User user = UserConverter.ConvertProfileToUser(profile);
            users.Add(user);
            return await unitOfWork.SaveChangesAsync();
        }
    }
}
