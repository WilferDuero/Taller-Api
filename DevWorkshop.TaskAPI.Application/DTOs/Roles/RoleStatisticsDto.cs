namespace DevWorkshop.TaskAPI.Application.DTOs.Roles;

/// <summary>
/// DTO para estadísticas de roles
/// </summary>
public class RoleStatisticsDto
{
    /// <summary>
    /// Número total de roles en el sistema
    /// </summary>
    public int TotalRoles { get; set; }

    /// <summary>
    /// Número total de usuarios en el sistema
    /// </summary>
    public int TotalUsers { get; set; }

    /// <summary>
    /// Número de usuarios que tienen un rol asignado
    /// </summary>
    public int UsersWithRole { get; set; }

    /// <summary>
    /// Número de usuarios sin rol asignado
    /// </summary>
    public int UsersWithoutRole { get; set; }

    /// <summary>
    /// Porcentaje de usuarios con rol asignado
    /// </summary>
    public double PercentageUsersWithRole => TotalUsers > 0 ? (double)UsersWithRole / TotalUsers * 100 : 0;
}
