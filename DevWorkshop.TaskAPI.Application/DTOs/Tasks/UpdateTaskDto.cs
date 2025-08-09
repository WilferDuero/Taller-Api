using DevWorkshop.TaskAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using TaskStatusEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskStatus;
using TaskPriorityEnum = DevWorkshop.TaskAPI.Domain.Enums.TaskPriority;

namespace DevWorkshop.TaskAPI.Application.DTOs.Tasks;

/// <summary>
/// DTO para actualizar una tarea existente
/// </summary>
public class UpdateTaskDto
{
    /// <summary>
    /// Título de la tarea
    /// </summary>
    [StringLength(200, ErrorMessage = "El título no puede exceder 200 caracteres")]
    public string? Title { get; set; }

    /// <summary>
    /// Descripción de la tarea
    /// </summary>
    [StringLength(1000, ErrorMessage = "La descripción no puede exceder 1000 caracteres")]
    public string? Description { get; set; }

    /// <summary>
    /// Estado de la tarea
    /// </summary>
    public TaskStatusEnum? Status { get; set; }

    /// <summary>
    /// Prioridad de la tarea
    /// </summary>
    public TaskPriorityEnum? Priority { get; set; }

    /// <summary>
    /// Fecha límite de la tarea
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Indica si la tarea está activa
    /// </summary>
    public bool? IsActive { get; set; }
}
