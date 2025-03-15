
namespace TaskManagerMAUI.Services
{
    internal interface ILoadTaskService
    {
        Task<Models.Task?> LoadTask();
    }
}