using DevWorkshop.TaskAPI.Domain.Entities;

namespace DevWorkshop.TaskAPI.Application.Interfaces;

/// <summary>
/// Interfaz para el patrón Unit of Work
/// Coordina el trabajo de múltiples repositorios y mantiene una lista de objetos
/// afectados por una transacción de negocio y coordina la escritura de cambios
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Repositorio para la entidad User
    /// </summary>
    IRepository<User> Users { get; }

    /// <summary>
    /// Repositorio para la entidad Role
    /// </summary>
    IRepository<Role> Roles { get; }

    /// <summary>
    /// Repositorio para la entidad TaskItem
    /// </summary>
    IRepository<TaskItem> Tasks { get; }

    /// <summary>
    /// Guarda todos los cambios realizados en la unidad de trabajo
    /// </summary>
    /// <returns>Número de entidades afectadas</returns>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Inicia una nueva transacción
    /// </summary>
    Task BeginTransactionAsync();

    /// <summary>
    /// Confirma la transacción actual
    /// </summary>
    Task CommitTransactionAsync();

    /// <summary>
    /// Revierte la transacción actual
    /// </summary>
    Task RollbackTransactionAsync();
}
