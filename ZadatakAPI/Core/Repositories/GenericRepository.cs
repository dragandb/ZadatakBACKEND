using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZadatakAPI.Data;

namespace ZadatakAPI.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected ZadatakAPIDBContext _context;
        internal DbSet<T> _dbSet;
        protected ILogger _logger;
        protected IMapper _mapper;

        public GenericRepository(ZadatakAPIDBContext context, ILogger logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            this._dbSet = _context.Set<T>();
        }

        

        public virtual async Task<IEnumerable<T>> ALL()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}
