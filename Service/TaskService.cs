using Todo.Models;

namespace Todo.Service;

public class TaskService
{
        
    private List<TaskModel> tasks = new List<TaskModel>();
        
    
    public TaskModel CreateTask(TaskModel task)
    {
        task.Id = tasks.Count + 1;
        tasks.Add(task);
        return task;
    }
    
    public List<TaskModel> GetTasks()
    {
        return tasks;
    }
    
    public TaskModel GetTaskById(int id)
    {
        return tasks.Find(task => task.Id == id);
    }

    public TaskModel UpdateTask(int id, TaskModel task)
    {
        TaskModel taskToUpdate = tasks.Find(task => task.Id == id);
        taskToUpdate.Title = task.Title;
        taskToUpdate.IsCompleted = task.IsCompleted;
        taskToUpdate.UpdatedAt = DateTime.Now;
        return taskToUpdate;
    }
    
    public void DeleteTask(int id)
    {
        TaskModel taskToDelete = tasks.Find(task => task.Id == id);
        tasks.Remove(taskToDelete);
    }


}