using NugetAnalyzer.BLL.Models;
using NugetAnalyzer.Domain;

namespace NugetAnalyzer.BLL.Converters
{
    internal class UserConverter
    {
        internal static User ConvertProfileToUser(Profile profile)
        {
            return profile == null ? null : new User
            {
                UserName = profile.UserName,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Email = profile.Email,
                GitHubId = profile.GitHubId,
                GitHubUrl = profile.GitHubUrl,
                AvatarUrl = profile.AvatarUrl
            };
        }
    }
}