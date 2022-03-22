using Data.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hamnava.Core.PublicClasses
{
    public class GenericClasses<Tentity> where Tentity : class
    {
        private readonly Context _context;
        private DbSet<Tentity> _table;

        public GenericClasses(Context context)
        {
            _context = context;
            _table = context.Set<Tentity>();
        }

        public virtual async Task CreateAsync(Tentity entity)
        {
            await _table.AddAsync(entity);
        }

        public virtual void Update(Tentity entity)
        {
             _table.Attach(entity);
             _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<Tentity> GetByIdAsync(object id, string joinString = "")
        {
            return await _table.FindAsync(id);
        }

        public virtual void Delete(Tentity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _table.Attach(entity);
            }
            _table.Remove(entity);
        }

        public virtual async Task DeleteById(object id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public virtual void DeleteByRange(Expression<Func<Tentity, bool>> myexpression = null)
        {
            IQueryable<Tentity> query = _table;
            if (myexpression != null)
            {
                query = query.Where(myexpression);
            }
             _table.RemoveRange(query);
        }

        public virtual async Task<IEnumerable<Tentity>> GetAllAsync(
                        Expression<Func<Tentity, bool>> myexpression = null,
                        Func<IQueryable<Tentity>, IOrderedQueryable<Tentity>> myOrderby = null,
                        string joinString = "")
        {
            IQueryable<Tentity> query = _table;
            if (myexpression != null)
            {
                query = query.Where(myexpression);
            }
            if (myOrderby != null)
            {
                query = myOrderby(query);
            }
            if (joinString != "")
            {
                foreach (string item in joinString.Split(','))
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
        }
    }
}
