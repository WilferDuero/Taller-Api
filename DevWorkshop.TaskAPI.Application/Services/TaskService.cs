using DevWorkshop.TaskAPI.Application.DTOs.Tasks;
using DevWorkshop.TaskAPI.Application.Interfaces;
using DevWorkshop.TaskAPI.Domain.Enums;
using TaskStatusEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskStatus;
using TaskPriorityEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskPriority;

namespace DevWorkshop.TaskAPI.Application.Services;

/// <summary>
/// Servicio para la gestión de tareas
/// </summary>
public class TaskService : ITaskService
{
    // TODO: ESTUDIANTE - Inyectar dependencias necesarias (DbContext, AutoMapper, Logger)
    
    public TaskService()
    {
        // TODO: ESTUDIANTE - Configurar las dependencias inyectadas
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la obtención de todas las tareas activas
    /// 
    /// Pasos a seguir:
    /// 1. Consultar la base de datos para obtener tareas donde IsActive = true
    /// 2. Incluir la información del usuario que creó la tarea (Include)
    /// 3. Mapear las entidades TaskItem a TaskDto usando AutoMapper
    /// 4. Retornar la lista de tareas
    /// </summary>
    public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la obtención de tareas por usuario
    /// 
    /// Pasos a seguir:
    /// 1. Filtrar tareas por CreatedByUserId y IsActive = true
    /// 2. Incluir información del usuario creador
    /// 3. Mapear y retornar las tareas
    /// </summary>
    public async Task<IEnumerable<TaskDto>> GetTasksByUserIdAsync(int userId)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la búsqueda de tarea por ID
    /// 
    /// Pasos a seguir:
    /// 1. Buscar la tarea por TaskId
    /// 2. Verificar que existe y está activa
    /// 3. Incluir información del usuario creador
    /// 4. Mapear y retornar la tarea
    /// </summary>
    public async Task<TaskDto?> GetTaskByIdAsync(int taskId)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar filtrado por estado
    /// 
    /// Pasos a seguir:
    /// 1. Filtrar tareas por Status y IsActive = true
    /// 2. Incluir información del usuario creador
    /// 3. Mapear y retornar las tareas
    /// </summary>
    public async Task<IEnumerable<TaskDto>> GetTasksByStatusAsync(TaskStatusEnum status)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar filtrado por prioridad
    /// 
    /// Pasos a seguir:
    /// 1. Filtrar tareas por Priority y IsActive = true
    /// 2. Incluir información del usuario creador
    /// 3. Mapear y retornar las tareas
    /// </summary>
    public async Task<IEnumerable<TaskDto>> GetTasksByPriorityAsync(TaskPriorityEnum priority)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la creación de tareas
    /// 
    /// Pasos a seguir:
    /// 1. Crear una nueva entidad TaskItem con los datos del DTO
    /// 2. Establecer CreatedByUserId, CreatedAt, IsActive = true
    /// 3. Establecer Status = TaskStatus.Pending por defecto
    /// 4. Guardar en la base de datos
    /// 5. Mapear y retornar la tarea creada
    /// </summary>
    public async Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto, int createdByUserId)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la actualización de tareas
    /// 
    /// Pasos a seguir:
    /// 1. Buscar la tarea existente por ID
    /// 2. Verificar que existe y está activa
    /// 3. Actualizar solo los campos que no sean null en el DTO
    /// 4. Establecer UpdatedAt = DateTime.UtcNow
    /// 5. Si se cambia a Completed, establecer CompletedAt
    /// 6. Guardar cambios y retornar la tarea actualizada
    /// </summary>
    public async Task<TaskDto?> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar marcar tarea como completada
    /// 
    /// Pasos a seguir:
    /// 1. Buscar la tarea por ID
    /// 2. Verificar que existe y está activa
    /// 3. Cambiar Status a TaskStatus.Completed
    /// 4. Establecer CompletedAt = DateTime.UtcNow
    /// 5. Establecer UpdatedAt = DateTime.UtcNow
    /// 6. Guardar cambios y retornar true
    /// </summary>
    public async Task<bool> CompleteTaskAsync(int taskId)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar eliminación lógica de tareas
    /// 
    /// Pasos a seguir:
    /// 1. Buscar la tarea por ID
    /// 2. Verificar que existe
    /// 3. Establecer IsActive = false (soft delete)
    /// 4. Establecer UpdatedAt = DateTime.UtcNow
    /// 5. Guardar cambios y retornar true
    /// </summary>
    public async Task<bool> DeleteTaskAsync(int taskId)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }
}
