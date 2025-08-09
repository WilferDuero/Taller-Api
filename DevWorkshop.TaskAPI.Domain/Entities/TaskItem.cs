using DevWorkshop.TaskAPI.Domain.Enums;
using TaskStatusEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskStatus;
using TaskPriorityEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskPriority;

namespace DevWorkshop.TaskAPI.Domain.Entities;

/// <summary>
/// Entidad que representa una tarea en el sistema
/// </summary>
public class TaskItem
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
    /// Descripción detallada de la tarea
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Estado actual de la tarea
    /// </summary>
    public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Pending;

    /// <summary>
    /// Prioridad de la tarea
    /// </summary>
    public TaskPriorityEnum Priority { get; set; } = TaskPriorityEnum.Medium;

    /// <summary>
    /// Fecha límite para completar la tarea
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Fecha de creación de la tarea
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Fecha de última actualización
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Fecha de finalización de la tarea
    /// </summary>
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// Indica si la tarea está activa (no eliminada)
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// ID del usuario que creó la tarea
    /// </summary>
    public int CreatedByUserId { get; set; }

    /// <summary>
    /// Usuario que creó la tarea (navegación)
    /// </summary>
    public User? CreatedByUser { get; set; }
}
