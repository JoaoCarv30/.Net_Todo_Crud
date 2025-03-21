using Todo.Models;
using Todo.Data;
using Microsoft.EntityFrameworkCore;

namespace Todo.Service
{
    public class TaskService
    {
        private readonly TodoContext _context;

        public TaskService(TodoContext context)
        {
            _context = context;
        }

        // Método para criar uma tarefa
        public TaskModel CreateTask(TaskModel task)
        {
            // Adiciona a nova tarefa no banco de dados
            _context.Tasks.Add(task);
            _context.SaveChanges(); // Salva as mudanças no banco
            return task;
        }

        // Método para obter todas as tarefas
        public List<TaskModel> GetTasks()
        {
            return _context.Tasks.ToList(); // Retorna todas as tarefas no banco
        }

        // Método para obter uma tarefa pelo id
        public TaskModel GetTaskById(int id)
        {
            return _context.Tasks.Find(id); // Busca a tarefa pelo id no banco
        }

        // Método para atualizar uma tarefa
        public TaskModel UpdateTask(int id, TaskModel task)
        {
            var taskToUpdate = _context.Tasks.Find(id);
            if (taskToUpdate == null)
            {
                return null;
            }

            // Atualiza as informações da tarefa
            taskToUpdate.Title = task.Title;
            taskToUpdate.IsCompleted = task.IsCompleted;
            taskToUpdate.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges(); // Salva as mudanças no banco

            return taskToUpdate;
        }

        // Método para excluir uma tarefa
        public void DeleteTask(int id)
        {
            var taskToDelete = _context.Tasks.Find(id);
            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete); // Remove a tarefa do banco
                _context.SaveChanges(); // Salva as mudanças no banco
            }
        }
    }
}