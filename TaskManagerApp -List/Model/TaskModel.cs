using System.ComponentModel.DataAnnotations;

namespace TaskMangerApp.Model;

public  sealed  class TaskModel
{
    [Required(ErrorMessage = "Task Name is Reqiured")]
    [StringLength(30, ErrorMessage = "Task Name is Longer than 30 Characters")]
    public string? TaskName { get; set; }

    [Required(ErrorMessage = "Task Descption is Reqiured")]
    [StringLength(255,ErrorMessage = "Task Name is Longer than 255 Characters")]
    public string? TaskDescription { get; set; }

    [Required(ErrorMessage = "Task Deadline Date is Reqiured")]
    
    public DateTime TaskDeadline { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Task Priority Level is Reqiured")]
    public  string? TaskPriorityLevel { get; set; }

    [Required]
    [StringLength(255,ErrorMessage = "Task Name is Longer than 255 Characters")]
    public string? TaskCategories { get; set; }
}
