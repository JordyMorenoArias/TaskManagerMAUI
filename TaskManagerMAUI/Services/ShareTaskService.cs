using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using TaskManagerMAUI.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskManagerMAUI.Services
{
    public class ShareTaskService : IShareTaskService
    {
        public async Task ShareTaskAsync(Models.Task task)
        {
            var shareModelViewData = new ShareModelViewData
            {
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                DueDate = task.DueDate
            };

            var taskData = JsonConvert.SerializeObject(shareModelViewData);

            var filePath = Path.Combine(FileSystem.CacheDirectory, $"{task.Title.Replace(" ", "-")}_TaskManagerMAUI.json");

            await File.WriteAllTextAsync(filePath, taskData);

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                var shareFile = new ShareFile(filePath, "application/json");
                var shareMessage = new ShareFileRequest
                {
                    Title = "Share Task",
                    File = shareFile
                };

                Share.Default.RequestAsync(shareMessage);
            });
        }
    }
}
