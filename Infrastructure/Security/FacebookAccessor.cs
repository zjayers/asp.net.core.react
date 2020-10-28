using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.UserProfiles.Facebook;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.Security
{
    public class FacebookAccessor : IFacebookAccessor
    {
        private readonly IOptions<FacebookAppSettings> _config;
        private readonly HttpClient _httpClient;

        public FacebookAccessor(IOptions<FacebookAppSettings> config)
        {
            _config = config;

            _httpClient = new HttpClient()
            {
                BaseAddress = new System.Uri("https://graph.facebook.com/")
            };

            _httpClient.DefaultRequestHeaders
                .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<FacebookUserInfo> FacebookLogin(string accessToken)
        {
            // Verify the token is valid
            var verifyToken = await _httpClient.GetAsync(
                $"debug_token?input_token={accessToken}&access_token={_config.Value.AppId}|{_config.Value.AppSecret}");

            if (!verifyToken.IsSuccessStatusCode)
            {
                return null;
            }

            var result = await GetAsync<FacebookUserInfo>(accessToken, "me", "fields=name,email,picture.width(100).heigth(100)");

            return result;
        }

        private async Task<T> GetAsync<T>(string accessToken, string endpoint, string fields)
        {
            var response = await _httpClient.GetAsync($"{endpoint}?access_token={accessToken}&{fields}");

            if (!response.IsSuccessStatusCode) return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
