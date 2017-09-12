using My.RolePermission.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace My.RolePermission.IBLL
{
    public interface IBaseService<T> where T : class,new()
    {
       IDBSession GetCurrentDbSession { get; }
       IBaseRepository<T> CurrentRepository { get; set; }
       IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
       IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount, Expression<Func<T, bool>> whereLambda, string orderby, bool? isAsc);
       bool DeleteEntity(T entity);
       bool EditEntity(T entity);
       T AddEntity(T entity);
    }
}
