using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TaskManagerMAUI.Services
{
    class LoadTaskService : ILoadTaskService
    {
        public async Task<Models.Task?> LoadTask()
        {
            var fileResult = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a Task JSON File",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.iOS, new[] { "public.json" } },
                        { DevicePlatform.Android, new[] { "application/json" } },
                        { DevicePlatform.WinUI, new[] { ".json" } },
                        { DevicePlatform.Tizen, new[] { "application/json" } },
                        { DevicePlatform.macOS, new[] { "public.json" } }
                    })
            });

            if (fileResult == null) 
                return null;

            using var stream = await fileResult.OpenReadAsync();
            using var reader = new StreamReader(stream);
            var taskJson = await reader.ReadToEndAsync();

            return JsonConvert.DeserializeObject<Models.Task>(taskJson);
        }
    }
}
