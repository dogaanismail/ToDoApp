using System.Linq;
using ToDoApp.Core.Entities;

namespace ToDoApp.Core.DataAccess.Abstract
{
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}
