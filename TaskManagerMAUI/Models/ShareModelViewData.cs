using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerMaui.Constants;

namespace TaskManagerMAUI.Models
{
    class ShareModelViewData
    {
        [Required]
        public string? Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
    }
}
