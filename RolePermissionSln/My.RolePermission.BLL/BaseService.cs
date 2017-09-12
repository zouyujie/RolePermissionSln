using My.RolePermission.DALSessionFactory;
using My.RolePermission.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace My.RolePermission.BLL
{
    public abstract class BaseService<T> where T : class,new()
    {
        public IDBSession GetCurrentDbSession
        {
            get
            {
                return DBSessionFactory.CreateDbSession();
            }

        }
        public IDAL.IBaseRepository<T> CurrentRepository { get; set; }
        public abstract void SetCurretnRepository();
        public BaseService()
        {
            SetCurretnRepository();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentRepository.LoadEntities(whereLambda);
        }

        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <typeparam name="model">实体对象</typeparam>
        /// <param name="pageIdex">页码</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="toalCount">总记录数</param>
        /// <param name="whereLambda">条件表达式</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="isAsc">是否升序（true:表示升序, false：降序）</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount, Expression<Func<T, bool>> whereLambda, string orderby, bool? isAsc)
        {
            return CurrentRepository.LoadPageEntities<s>(pageIdex, pageSize, out toalCount, whereLambda, orderby, isAsc);
        }
        public bool DeleteEntity(T entity)
        {
            CurrentRepository.DeleteEntity(entity);
            return this.GetCurrentDbSession.SaveChanges();
        }
        public bool EditEntity(T entity)
        {
            CurrentRepository.EditEntity(entity);
            return this.GetCurrentDbSession.SaveChanges();
        }
        public T AddEntity(T entity)
        {
            CurrentRepository.AddEntity(entity);
            this.GetCurrentDbSession.SaveChanges();
            return entity;
        }
    }
}
