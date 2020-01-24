using System.Data.Entity;
using System.Linq;
using ToDoApp.Core.DataAccess.Abstract;
using ToDoApp.Core.Entities;

namespace ToDoApp.Core.DataAccess.Concrete.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        private IDbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<T> Table => this.Entities;

        protected virtual IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }
    }
}
