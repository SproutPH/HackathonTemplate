namespace SproutHackathon.Services.ServiceCollection.Sprout.AuthService
{
    public interface IAuthService
    {
        Task<string> GetAccessTokenAsync();
    }
}