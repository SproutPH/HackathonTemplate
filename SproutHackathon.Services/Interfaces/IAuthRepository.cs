namespace SproutHackathon.Services.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> GetAccessTokenAsync();
    }
}