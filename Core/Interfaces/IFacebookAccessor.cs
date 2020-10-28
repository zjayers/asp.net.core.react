using System.Threading.Tasks;
using Core.UserProfiles.Facebook;

namespace Core.Interfaces
{
    public interface IFacebookAccessor
    {
        Task<FacebookUserInfo> FacebookLogin(string accessToken);
    }
}
