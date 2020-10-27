using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProfileReader
    {
        Task<UserProfiles.UserProfile> ReadProfile(string username);
    }
}
