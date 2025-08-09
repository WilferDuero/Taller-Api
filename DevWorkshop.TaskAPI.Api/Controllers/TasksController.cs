using DevWorkshop.TaskAPI.Application.DTOs.Common;
using DevWorkshop.TaskAPI.Application.DTOs.Tasks;
using DevWorkshop.TaskAPI.Application.Interfaces;
using DevWorkshop.TaskAPI.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskStatusEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskStatus;
using TaskPriorityEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskPriority;

namespace DevWorkshop.TaskAPI.Api.Controllers;

/// <summary>
/// Controlador para la gestión de tareas
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize] // Todas las operaciones de tareas requieren autenticación
public class TasksController : ControllerBase
{
    // TODO: ESTUDIANTE - Inyectar ITaskService y ILogger
    
    public TasksController()
    {
        // TODO: ESTUDIANTE - Configurar las dependencias inyectadas
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la obtención de todas las tareas
    /// 
    /// Pasos a seguir:
    /// 1. Llamar al servicio para obtener todas las tareas
    /// 2. Retornar ApiResponse con la lista de tareas
    /// 3. Manejar excepciones
    /// </summary>
    [HttpGet("getAll")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<TaskDto>>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<IEnumerable<TaskDto>>>> GetAllTasks()
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la obtención de una tarea por ID
    /// 
    /// Pasos a seguir:
    /// 1. Validar que el ID sea válido
    /// 2. Llamar al servicio para buscar la tarea
    /// 3. Retornar NotFound si no existe
    /// 4. Retornar Ok con la tarea si existe
    /// </summary>
    [HttpGet("getById/{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<TaskDto>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 404)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<TaskDto>>> GetTaskById(int id)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la obtención de tareas del usuario actual
    /// 
    /// Pasos a seguir:
    /// 1. Obtener el UserId del token JWT
    /// 2. Llamar al servicio para obtener tareas del usuario
    /// 3. Retornar la lista de tareas
    /// </summary>
    [HttpGet("my-tasks")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<TaskDto>>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<IEnumerable<TaskDto>>>> GetMyTasks()
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar filtrado de tareas por estado
    /// 
    /// Pasos a seguir:
    /// 1. Validar que el estado sea válido
    /// 2. Llamar al servicio para filtrar por estado
    /// 3. Retornar las tareas filtradas
    /// </summary>
    [HttpGet("by-status/{status}")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<TaskDto>>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<IEnumerable<TaskDto>>>> GetTasksByStatus(TaskStatusEnum status)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar filtrado de tareas por prioridad
    /// 
    /// Pasos a seguir:
    /// 1. Validar que la prioridad sea válida
    /// 2. Llamar al servicio para filtrar por prioridad
    /// 3. Retornar las tareas filtradas
    /// </summary>
    [HttpGet("by-priority/{priority}")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<TaskDto>>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<IEnumerable<TaskDto>>>> GetTasksByPriority(TaskPriorityEnum priority)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la creación de una nueva tarea
    /// 
    /// Pasos a seguir:
    /// 1. Validar el modelo CreateTaskDto
    /// 2. Obtener el UserId del token JWT
    /// 3. Llamar al servicio para crear la tarea
    /// 4. Retornar Created con la tarea creada
    /// </summary>
    [HttpPost("create")]
    [ProducesResponseType(typeof(ApiResponse<TaskDto>), 201)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<TaskDto>>> CreateTask([FromBody] CreateTaskDto createTaskDto)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la actualización de una tarea
    /// 
    /// Pasos a seguir:
    /// 1. Validar que el ID sea válido
    /// 2. Validar el modelo UpdateTaskDto
    /// 3. Verificar que la tarea existe
    /// 4. Llamar al servicio para actualizar
    /// 5. Retornar Ok con la tarea actualizada
    /// </summary>
    [HttpPut("update/{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<TaskDto>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 404)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<TaskDto>>> UpdateTask(int id, [FromBody] UpdateTaskDto updateTaskDto)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar marcar tarea como completada
    /// 
    /// Pasos a seguir:
    /// 1. Validar que el ID sea válido
    /// 2. Llamar al servicio para completar la tarea
    /// 3. Retornar Ok si se completó correctamente
    /// 4. Retornar NotFound si no existe
    /// </summary>
    [HttpPatch("complete/{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<object>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 404)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<object>>> CompleteTask(int id)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la eliminación de una tarea
    /// 
    /// Pasos a seguir:
    /// 1. Validar que el ID sea válido
    /// 2. Verificar que la tarea existe
    /// 3. Llamar al servicio para eliminar (soft delete)
    /// 4. Retornar NoContent si se eliminó correctamente
    /// </summary>
    [HttpDelete("delete/{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<object>), 204)]
    [ProducesResponseType(typeof(ApiResponse<object>), 404)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<object>>> DeleteTask(int id)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }
}
