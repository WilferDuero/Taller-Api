using DevWorkshop.TaskAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace DevWorkshop.TaskAPI.Application.DTOs.Tasks;

/// <summary>
/// DTO para crear una nueva tarea
/// </summary>
public class CreateTaskDto
{
    /// <summary>
    /// Título de la tarea
    /// </summary>
    [Required(ErrorMessage = "El título es obligatorio")]
    [StringLength(200, ErrorMessage = "El título no puede exceder 200 caracteres")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Descripción de la tarea
    /// </summary>
    [StringLength(1000, ErrorMessage = "La descripción no puede exceder 1000 caracteres")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Prioridad de la tarea
    /// </summary>
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;

    /// <summary>
    /// Fecha límite de la tarea
    /// </summary>
    public DateTime? DueDate { get; set; }
}
