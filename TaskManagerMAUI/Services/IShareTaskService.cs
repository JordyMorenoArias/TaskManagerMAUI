using Task = System.Threading.Tasks.Task;

namespace TaskManagerMAUI.Services
{
    public interface IShareTaskService
    {
        Task ShareTaskAsync(Models.Task task);
    }
}