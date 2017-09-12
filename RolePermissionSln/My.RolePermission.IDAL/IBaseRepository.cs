using System;
using System.Linq;
using System.Linq.Expressions;

namespace My.RolePermission.IDAL
{
    public interface IBaseRepository<T> where T : class,new()
    {
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadPageEntities<model>(int pageIdex, int pageSize, out int toalCount, Expression<Func<T, bool>> whereLambda, string orderby, bool? isAsc);
        bool DeleteEntity(T entity);
        bool EditEntity(T entity);
        T AddEntity(T entity);

        IQueryable<T> LoadEntitiesAll(string entity);
    }
}
