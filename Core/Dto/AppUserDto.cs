using System.Linq;
using System.Text.Json.Serialization;
using Core.Interfaces;
using Domain;

namespace Core.Dto
{
    public class AppUserDto
    {
        public AppUserDto(AppUser user, IJwtGenerator jwtGenerator, string refreshToken)
        {
            UserName = user.UserName;
            DisplayName = user.DisplayName;
            Token = jwtGenerator.CreateToken(user);
            Image = user.Photos.FirstOrDefault(x => x.IsAvatar)?.Url;
            RefreshToken = refreshToken;
        }

        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public string Image { get; set; }

        // Do not return the refresh token with the request
        // This item will be set as a cookie that is then returned to the client
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
