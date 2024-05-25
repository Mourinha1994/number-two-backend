using Microsoft.EntityFrameworkCore;
using NumberTwo.Core.Interfaces;
using NumberTwo.Infrastructure.Data;

namespace NumberTwo.Infrastructure.Repositories;

public class Repository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    public Repository(ApplicationDbContext context) => _context = context;
    
    public async Task AddAsync(T entity)
        => await _context.Set<T>().AddAsync(entity);

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _context.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);

    public async Task UpdateAsync(T entity)
        => _context.Set<T>().Update(entity);
}