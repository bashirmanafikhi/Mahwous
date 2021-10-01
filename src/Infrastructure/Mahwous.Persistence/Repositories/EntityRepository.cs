using Mahwous.Application.Interfaces;
using Mahwous.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MahwousWeb.Persistent.Repositories
{
    public partial class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public EntityRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            //T entity = new T() { Id = id };
            //_context.Set<T>().Attach(entity);
            //_context.Set<T>().Remove(entity);
            //await _context.SaveChangesAsync();

            var entity = await _context.Set<T>().FirstAsync(x => x.Id == id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
