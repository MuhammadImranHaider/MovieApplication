using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Interfaces;
using System.Linq.Expressions;

namespace MovieApp.Data;

public class Repository<T> : IRepository<T> where T : class
{
    private MovieDbContext _context;

    private DbSet<T> table;

    public Repository()
    {
        this._context = new MovieDbContext();
        table = _context.Set<T>();
    }
    public Repository(MovieDbContext _context)
    {
        this._context = _context;
        table = _context.Set<T>();
    }

    public IQueryable<T> FindAll()
        => _context.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        =>
        _context.Set<T>().Where(expression);

    public void Create(T entity)
    {
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.table.Add(entity);
            this._context.SaveChanges();
        }
        catch (Exception ex) {
            throw new Exception("An error occurred while creating the entity in the database.", ex);
        }
    }

    public void Update(T entity)
    {
        try
        {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity), "The entity parameter cannot be null.");
            }
            this.table.Update(entity);
            this._context.SaveChanges();
        }
        catch (Exception ex) {
            throw new Exception("An error occurred while updating the entity in the database.", ex);
        }
    }

    public void Delete(int id)
    {
        try {
            T? entity = table.Find(id);
            if (entity == null) 
            {
                throw new ArgumentNullException(nameof(entity), "The entity parameter cannot be null.");
            }
            this.table.Remove(entity);
            this._context.SaveChanges();
        }
        catch (Exception ex) {
            throw new Exception("An error occurred while deleting the entity from the database.", ex);
        }
    }
}
