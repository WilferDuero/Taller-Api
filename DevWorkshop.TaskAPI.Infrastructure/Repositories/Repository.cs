using System.Linq.Expressions;
using DevWorkshop.TaskAPI.Application.Interfaces;
using DevWorkshop.TaskAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevWorkshop.TaskAPI.Infrastructure.Repositories;

/// <summary>
/// Implementación genérica del patrón Repository
/// </summary>
/// <typeparam name="T">Tipo de entidad</typeparam>
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    /// <summary>
    /// Obtiene todas las entidades
    /// </summary>
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Obtiene una entidad por su ID
    /// </summary>
    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <summary>
    /// Busca entidades que cumplan una condición
    /// </summary>
    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    /// <summary>
    /// Busca la primera entidad que cumpla una condición
    /// </summary>
    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    /// <summary>
    /// Agrega una nueva entidad
    /// </summary>
    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    /// <summary>
    /// Agrega múltiples entidades
    /// </summary>
    public virtual async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    /// <summary>
    /// Actualiza una entidad existente
    /// </summary>
    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    /// <summary>
    /// Elimina una entidad
    /// </summary>
    public virtual void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    /// <summary>
    /// Elimina múltiples entidades
    /// </summary>
    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    /// <summary>
    /// Cuenta el número de entidades que cumplen una condición
    /// </summary>
    public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        if (predicate == null)
            return await _dbSet.CountAsync();
        
        return await _dbSet.CountAsync(predicate);
    }

    /// <summary>
    /// Verifica si existe alguna entidad que cumpla una condición
    /// </summary>
    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }
}
