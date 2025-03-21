using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Service;

namespace Todo.Controller;


[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{

    private readonly TaskService _taskService;

    public TodoController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public ActionResult<TaskModel> CreateTask([FromBody]TaskModel task)
    {
        var createdTask = _taskService.CreateTask(task);
        return createdTask;
    }

    [HttpGet]
    public ActionResult<List<TaskModel>> GetAllTasks()
    {
        return _taskService.GetTasks();
    }

    [HttpGet("{id}")]
    public ActionResult<TaskModel> GetTaskById(int id)
    {
        TaskModel task = _taskService.GetTaskById(id);
        if (task == null)
        {
            return NotFound();
        }
        return task;
    }
    
    [HttpPut("{id}")]
    public ActionResult<TaskModel> UpdateTask (int id, [FromBody] TaskModel task)
    {
        TaskModel updatedTask = _taskService.UpdateTask(id, task); 
        if (updatedTask == null)
        {
            return NotFound();
        }
        return updatedTask;
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteTask(int id)
    {
        _taskService.DeleteTask(id);
        return NoContent();
    }

}
