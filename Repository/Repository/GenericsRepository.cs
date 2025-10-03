using Database.Data;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Linq.Expressions;

namespace LibraryAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly LibraryManagementDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(LibraryManagementDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Add entity
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        // Update entity
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        // Delete entity
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        // Find by predicate
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        // Get all entities
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        // Get by Id (assumes int primary key)
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Delete by Id (optional)
        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                Delete(entity);
        }

        // Save changes to database
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
