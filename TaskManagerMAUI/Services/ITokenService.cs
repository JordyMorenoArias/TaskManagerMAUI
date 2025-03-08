
namespace TaskManagerMAUI.Services
{
    internal interface ITokenService
    {
        Task<string?> GetTokenAsync();
        Task RemoveTokenAsync();
        Task SaveTokenAsync(string token);
    }
}