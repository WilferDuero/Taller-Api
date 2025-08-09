using DevWorkshop.TaskAPI.Application.Interfaces;
using DevWorkshop.TaskAPI.Domain.Entities;
using DevWorkshop.TaskAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace DevWorkshop.TaskAPI.Infrastructure.Repositories;

/// <summary>
/// Implementación del patrón Unit of Work
/// Coordina el trabajo de múltiples repositorios y mantiene una transacción única
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction? _transaction;

    // Repositorios lazy-loaded
    private IRepository<User>? _users;
    private IRepository<Role>? _roles;
    private IRepository<TaskItem>? _tasks;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Repositorio para la entidad User
    /// </summary>
    public IRepository<User> Users
    {
        get { return _users ??= new Repository<User>(_context); }
    }

    /// <summary>
    /// Repositorio para la entidad Role
    /// </summary>
    public IRepository<Role> Roles
    {
        get { return _roles ??= new Repository<Role>(_context); }
    }

    /// <summary>
    /// Repositorio para la entidad TaskItem
    /// </summary>
    public IRepository<TaskItem> Tasks
    {
        get { return _tasks ??= new Repository<TaskItem>(_context); }
    }

    /// <summary>
    /// Guarda todos los cambios realizados en la unidad de trabajo
    /// </summary>
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Inicia una nueva transacción
    /// </summary>
    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    /// <summary>
    /// Confirma la transacción actual
    /// </summary>
    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    /// <summary>
    /// Revierte la transacción actual
    /// </summary>
    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    /// <summary>
    /// Libera los recursos utilizados
    /// </summary>
    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
