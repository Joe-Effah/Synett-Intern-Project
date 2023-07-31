
using System.ComponentModel.DataAnnotations;

namespace TaskApp.Data;


public sealed class TaskModel
{
    [Key]
    public int TaskID{get;set;}
    public string? TaskName{get;set;}
    public DateTime TaskDeadline{get;set;}  =DateTime.Now;
    public string? TaskDescription{get;set;}
    public string? TaskPriorityLevel{get;set;}
    public string? TaskCategories{get;set;}
}