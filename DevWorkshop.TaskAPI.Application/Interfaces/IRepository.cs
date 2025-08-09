using System.Linq.Expressions;

namespace DevWorkshop.TaskAPI.Application.Interfaces;

/// <summary>
/// Interfaz genérica para el patrón Repository
/// </summary>
/// <typeparam name="T">Tipo de entidad</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Obtiene todas las entidades
    /// </summary>
    /// <returns>Lista de entidades</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Obtiene una entidad por su ID
    /// </summary>
    /// <param name="id">ID de la entidad</param>
    /// <returns>Entidad encontrada o null</returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Busca entidades que cumplan una condición
    /// </summary>
    /// <param name="predicate">Condición de búsqueda</param>
    /// <returns>Lista de entidades que cumplen la condición</returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Busca la primera entidad que cumpla una condición
    /// </summary>
    /// <param name="predicate">Condición de búsqueda</param>
    /// <returns>Primera entidad que cumple la condición o null</returns>
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Agrega una nueva entidad
    /// </summary>
    /// <param name="entity">Entidad a agregar</param>
    /// <returns>Entidad agregada</returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Agrega múltiples entidades
    /// </summary>
    /// <param name="entities">Entidades a agregar</param>
    Task AddRangeAsync(IEnumerable<T> entities);

    /// <summary>
    /// Actualiza una entidad existente
    /// </summary>
    /// <param name="entity">Entidad a actualizar</param>
    void Update(T entity);

    /// <summary>
    /// Elimina una entidad
    /// </summary>
    /// <param name="entity">Entidad a eliminar</param>
    void Remove(T entity);

    /// <summary>
    /// Elimina múltiples entidades
    /// </summary>
    /// <param name="entities">Entidades a eliminar</param>
    void RemoveRange(IEnumerable<T> entities);

    /// <summary>
    /// Cuenta el número de entidades que cumplen una condición
    /// </summary>
    /// <param name="predicate">Condición de conteo</param>
    /// <returns>Número de entidades</returns>
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    /// <summary>
    /// Verifica si existe alguna entidad que cumpla una condición
    /// </summary>
    /// <param name="predicate">Condición de existencia</param>
    /// <returns>True si existe al menos una entidad</returns>
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
}
