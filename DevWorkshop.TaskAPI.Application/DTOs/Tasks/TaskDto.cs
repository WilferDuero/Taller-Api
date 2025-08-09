using DevWorkshop.TaskAPI.Domain.Enums;
using TaskStatusEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskStatus;
using TaskPriorityEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskPriority;

namespace DevWorkshop.TaskAPI.Application.DTOs.Tasks;

/// <summary>
/// DTO para mostrar información de una tarea
/// </summary>
public class TaskDto
{
    /// <summary>
    /// Identificador único de la tarea
    /// </summary>
    public int TaskId { get; set; }

    /// <summary>
    /// Título de la tarea
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Descripción de la tarea
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Estado de la tarea
    /// </summary>
    public TaskStatusEnum Status { get; set; }

    /// <summary>
    /// Prioridad de la tarea
    /// </summary>
    public TaskPriorityEnum Priority { get; set; }

    /// <summary>
    /// Fecha límite de la tarea
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Fecha de creación
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Fecha de actualización
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Fecha de finalización
    /// </summary>
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// ID del usuario que creó la tarea
    /// </summary>
    public int CreatedByUserId { get; set; }

    /// <summary>
    /// Nombre del usuario que creó la tarea
    /// </summary>
    public string CreatedByUserName { get; set; } = string.Empty;

    /// <summary>
    /// Indica si la tarea está activa
    /// </summary>
    public bool IsActive { get; set; }
}
