namespace Core.Interfaces
{
    public interface IEmailVerificationRequest
    {
        string Email { get; set; }
        string Origin { get; set; }
    }
}
