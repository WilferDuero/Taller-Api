using DevWorkshop.TaskAPI.Application.DTOs.Tasks;
using DevWorkshop.TaskAPI.Domain.Enums;
using TaskStatusEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskStatus;
using TaskPriorityEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskPriority;

namespace DevWorkshop.TaskAPI.Application.Interfaces;

/// <summary>
/// Interfaz para el servicio de tareas
/// </summary>
public interface ITaskService
{
    /// <summary>
    /// Obtiene todas las tareas activas
    /// </summary>
    /// <returns>Lista de tareas</returns>
    Task<IEnumerable<TaskDto>> GetAllTasksAsync();

    /// <summary>
    /// Obtiene las tareas de un usuario específico
    /// </summary>
    /// <param name="userId">ID del usuario</param>
    /// <returns>Lista de tareas del usuario</returns>
    Task<IEnumerable<TaskDto>> GetTasksByUserIdAsync(int userId);

    /// <summary>
    /// Obtiene una tarea por su ID
    /// </summary>
    /// <param name="taskId">ID de la tarea</param>
    /// <returns>Tarea encontrada o null</returns>
    Task<TaskDto?> GetTaskByIdAsync(int taskId);

    /// <summary>
    /// Obtiene tareas filtradas por estado
    /// </summary>
    /// <param name="status">Estado de las tareas</param>
    /// <returns>Lista de tareas con el estado especificado</returns>
    Task<IEnumerable<TaskDto>> GetTasksByStatusAsync(TaskStatusEnum status);

    /// <summary>
    /// Obtiene tareas filtradas por prioridad
    /// </summary>
    /// <param name="priority">Prioridad de las tareas</param>
    /// <returns>Lista de tareas con la prioridad especificada</returns>
    Task<IEnumerable<TaskDto>> GetTasksByPriorityAsync(TaskPriorityEnum priority);

    /// <summary>
    /// Crea una nueva tarea
    /// </summary>
    /// <param name="createTaskDto">Datos de la tarea a crear</param>
    /// <param name="createdByUserId">ID del usuario que crea la tarea</param>
    /// <returns>Tarea creada</returns>
    Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto, int createdByUserId);

    /// <summary>
    /// Actualiza una tarea existente
    /// </summary>
    /// <param name="taskId">ID de la tarea a actualizar</param>
    /// <param name="updateTaskDto">Datos a actualizar</param>
    /// <returns>Tarea actualizada o null si no existe</returns>
    Task<TaskDto?> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto);

    /// <summary>
    /// Marca una tarea como completada
    /// </summary>
    /// <param name="taskId">ID de la tarea</param>
    /// <returns>True si se marcó como completada</returns>
    Task<bool> CompleteTaskAsync(int taskId);

    /// <summary>
    /// Elimina una tarea (soft delete)
    /// </summary>
    /// <param name="taskId">ID de la tarea a eliminar</param>
    /// <returns>True si se eliminó correctamente</returns>
    Task<bool> DeleteTaskAsync(int taskId);
}
