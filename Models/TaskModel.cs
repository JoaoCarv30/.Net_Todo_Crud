using System.ComponentModel.DataAnnotations;

namespace Todo.Models;

public class TaskModel
{
    
    
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required]
    public String Title { get; set; }
    
    [Required]
    public bool IsCompleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    
    
}