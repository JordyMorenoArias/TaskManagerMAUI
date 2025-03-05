using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManagerMAUI.Models
{
    public class HomeModelViewData
    {
        public IEnumerable<Task>? Tasks { get; set; } = new List<Task>();
    }
}
