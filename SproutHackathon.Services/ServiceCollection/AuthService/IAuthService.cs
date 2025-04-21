namespace SproutHackathon.Services.ServiceCollection.AuthService
{
    public interface IAuthService
    {
        Task<string> GetAccessTokenAsync();
    }
}