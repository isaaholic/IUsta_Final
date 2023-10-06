using Application.Repositories;
using Application.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        private AppDbContext context;

        public Repository(AppDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            _logger.LogInformation("Start AddAsync()");
            var entry = await Table.AddAsync(entity);
            _logger.LogInformation("End AddAsync()");
            return entry.State == EntityState.Added;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            _logger.LogInformation("Start AddRangeAsync()");
            await Table.AddRangeAsync(entities);
            _logger.LogInformation("End AddRangeAsync()");
        }

        public IEnumerable<T?> GetAll(bool tracking = true)
        {
            _logger.LogInformation("Start GetAll()");
            if (tracking)
            {
                _logger.LogInformation("End GetAll()");

                return Table.ToList();
            }

            _logger.LogInformation("End GetAll()");
            return Table.AsNoTracking().ToList();
        }

        public async Task<T?> GetAsync(string id)
        {
            _logger.LogInformation("Done GetAsync()");

            return await Table.FirstOrDefaultAsync(e => e.Id == Guid.Parse(id));
        }
        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression) => await Table.FirstOrDefaultAsync(expression);

        public IEnumerable<T?> GetWhere(Expression<Func<T, bool>> expression) => Table.Where(expression);

        public bool Remove(T entity)
        {
            var entry = Table.Remove(entity);
            return entry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            _logger.LogInformation("Start RemoveAsync()");

            T? model = await Table.FindAsync(Guid.Parse(id));
            var entry = Table.Remove(model);

            _logger.LogInformation("End RemoveAsync()");

            return entry.State == EntityState.Deleted;
        }

        public async Task<int> SaveChangesAsync()
        {
            _logger.LogInformation("Done SaveChangesAsync()");


            return await _context.SaveChangesAsync();
        }
        public bool Update(T entity)
        {
            _logger.LogInformation("Start Update()");

            var entry = Table.Update(entity);
            _logger.LogInformation("End Update()");
            return entry.State == EntityState.Modified;
        }
    }
}
