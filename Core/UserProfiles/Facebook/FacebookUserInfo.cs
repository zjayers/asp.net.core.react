namespace Core.UserProfiles.Facebook
{
    public class FacebookUserInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public FacebookPictureData ImageData { get; set; }
    }
}
